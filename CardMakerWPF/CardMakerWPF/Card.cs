using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.StringTemplate;
using CardMakerBackend.CardTypes;
using System.Windows;
using Antlr4.StringTemplate.Debug;
using CardMakerWPF.Templating;

namespace CardMakerWPF
{
    public class Card
    {
        public string HTML { private set; get; }

        public Card(Power p)
        {
            StringTemplate template = new StringTemplate(Properties.Resources.PowerTemplate);
            template.AddAttribute("Name", p.Name);
            template.AddAttribute("Level", p.Level);
            template.AddAttribute("FlavourText", p.FlavourText);

            //etc.
        }

        public Card(Item i)
        {

        }

        public Card(Monster m)
        {

        }

        public Card(CharacterClass c)
        {

        }

        public override string ToString()
        {
            return HTML;
        }

        public static Power GetDemo()
        {
            Power power = new Power();
            power.Action = ActionType.Standard;
            power.Attack = AttackType.Ranged;
            power.FlavourText = "A brilliant ray of light sears your foe with golden radiance. Sparkles of light linger around your target, guiding your ally's attack.";
            power.Keywords.Add("Divine");
            power.Keywords.Add("Implement");
            power.Keywords.Add("Radiant");
            power.Level = "Cleric Attack 1";
            power.Name = "Lance of Faith";
            power.Range = "5";
            Power.Element el1 = new Power.Element();
            Power.Element el2 = new Power.Element();
            Power.Element el3 = new Power.Element();
            Power.Element el4 = new Power.Element();
            el1.Spacing = Power.Element.Indent.Primary;
            el1.Shaded = false;
            el1.Type = "Target";
            el1.Text = "One Creature";

            el1.Spacing = Power.Element.Indent.Primary;
            el1.Shaded = false;
            el2.Type = "Attack";
            el2.Text = "Wisdom vs. Reflex";

            el1.Spacing = Power.Element.Indent.Secondary;
            el1.Shaded = true;
            el3.Type = "Hit";
            el3.Text = "1d8 + Wisdom modifier radiant damage, and one ally you can see gains a +2 bonus to his or her next attack roll against the target.";

            el1.Spacing = Power.Element.Indent.Primary;
            el1.Shaded = false;
            el4.Type = "";
            el4.Text = "Increase damage to 2d8 + Wisdom Modifier at 21st level.";

            return power;
        }
    }
}
