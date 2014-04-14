using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardMakerBackend.CardTypes
{
    public enum ActionType
    {
        None=0, Free, Interrupt, Reaction, Minor, Move, Standard
    }

    public enum AttackType
    {
        Melee=0, Ranged, Close_Burst, Close_Blast, Area_Blast, Area_Wall, Personal
    }

    public class Power
    {
        #region inner_types
        public enum SpellUsage
        {
            AtWill=0, Encounter, Daily
        }

        public class Element
        {
            public enum Indent
            {
                Primary=0, Secondary, Tertiary
            }

            public class ElementModel
            {
                public string Indent { get; set; }
                public string Shading { get; set; }
                public string Type { get; set; }
                public string Text { get; set; }

                public ElementModel(Element e)
                {
                    switch (e.Spacing)
                    {
                        case Element.Indent.Primary:
                            Indent = "5";
                            break;
                        case Element.Indent.Secondary:
                            Indent = "15";
                            break;
                        case Element.Indent.Tertiary:
                            Indent = "25";
                            break;
                        default: break;
                    }

                    if (!e.Shaded) Shading = "";
                    else Shading = "/Resources/Images/bg_350.jpg";

                    Type = e.Type;
                    Text = e.Text;
                }
            }

            public string Text { get; set; }
            public string Type { get; set; }
            public bool Shaded { get; set; }
            public Indent Spacing { get; set; }

            public ElementModel GetModel()
            {
                return new ElementModel(this);
            }
        }

        public class PowerModel
        {
            public string Name { get; set; }
            public string Level { get; set; }
            public string FlavourText { get; set; }
            public string Usage { get; set; }
            public string Colour { get; set; }
            public string Keywords { get; set; }
            public string Action { get; set; }
            public string Attack { get; set; }
            public string Range { get; set; }

            public PowerModel(Power p)
            {
                Name = p.Name;
                Level = p.Level;
                FlavourText = p.FlavourText;

                switch (p.Usage)
                {
                    case SpellUsage.AtWill:
                        Colour = "#407040";
                        Usage = "At Will";
                        break;
                    case SpellUsage.Encounter:
                        Colour = "#704040";
                        Usage = "Encounter";
                        break;
                    case SpellUsage.Daily:
                        Colour = "#404040";
                        Usage = "At Will";
                        break;
                }

                StringBuilder builder = new StringBuilder();
                foreach (string s in p.Keywords)
                {
                    builder.Append(s).Append(", ");
                }
                Keywords = builder.ToString().Substring(0, builder.Length - 2);

                switch (p.Action)
                {
                    case ActionType.Free:
                        Action = "Free Action";
                        break;
                    case ActionType.Interrupt:
                        Action = "Immediate Interrupt";
                        break;
                    case ActionType.Minor:
                        Action = "Minor Action";
                        break;
                    case ActionType.Move:
                        Action = "Movement Action";
                        break;
                    case ActionType.None:
                        Action = "No Action";
                        break;
                    case ActionType.Reaction:
                        Action = "Immediate Reaction";
                        break;
                    case ActionType.Standard:
                        Action = "Standard Action";
                        break;
                    default: break;
                }
                Range = p.Range;
            }
        }
        #endregion

        public Power()
        {
            Keywords = new List<string>();
            Elements = new List<Element>();
        }

        public string Name { get; set; }
        public string Level { get; set; }
        public string FlavourText { get; set; }
        public SpellUsage Usage { get; private set; }
        public List<string> Keywords;
        public ActionType Action { get; set; }
        public AttackType Attack { get; set; }
        public string Range { get; set; }
        public List<Element> Elements;

        public PowerModel GetModel()
        {
            return new PowerModel(this);
        }
    }
}
