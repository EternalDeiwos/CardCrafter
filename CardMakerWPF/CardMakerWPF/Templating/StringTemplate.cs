using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardMakerWPF.Templating
{
    class StringTemplate
    {
        private class TemplateAttribute
        {
            public string Placeholder;
            public string Replacement;
            public int Index;
            public int Length { get { return Placeholder.Length; } private set; }
        }

        Dictionary<string, TemplateAttribute> Index;
        StringBuilder Builder;
        string Template;
        bool Compiled = false;

        public StringTemplate(string template)
        {
            Index = new Dictionary<string, TemplateAttribute>();
            Builder = new StringBuilder(template);
            Template = template;
        }

        public void AddAttribute(string attribute, string replaceValue)
        {
            if (Compiled) throw new InvalidOperationException("You cannot edit a compiled template, if you would like to edit the template then Reset() it.");
            TemplateAttribute t = new TemplateAttribute();
            t.Placeholder = attribute;
            t.Replacement = replaceValue;
            t.Index = Builder.ToString().IndexOf(replaceValue);

            Index[t.Placeholder] = t;

            Builder.Replace(t.Placeholder, t.Replacement, t.Index, t.Length);
        }

        public void ChangeAttribute(string attribute, string replaceValue)
        {
            if (Compiled) throw new InvalidOperationException("You cannot edit a compiled template, if you would like to edit the template then Reset() it.");
            TemplateAttribute t = Index[attribute];
            Builder.Replace(t.Replacement, replaceValue, t.Index, t.Replacement.Length);
            Index[attribute].Replacement = replaceValue;
        }

        public void RemoveAttribute(string attribute)
        {
            if (Compiled) throw new InvalidOperationException("You cannot edit a compiled template, if you would like to edit the template then Reset() it.");
            Index.Remove(attribute);
        }

        public void Compile()
        {
            Compiled = true;
            Builder.Clear();
            Builder.Append(Template);
            foreach (TemplateAttribute a in Index.Values)
            {
                Builder.Replace(a.Placeholder, a.Replacement, a.Index, a.Length);
            }
        }

        public void Reset()
        {
            Compiled = false;
            Builder.Clear();
            Builder.Append(Template);
        }

        public string Render()
        {
            if (!Compiled) Compile();
            return Builder.ToString();
        }

        public string Preview()
        {
            return Builder.ToString();
        }
    }
}
