using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CardMaker
{
    [Serializable]
    public enum SpellUsage
    {
        AtWill=0, Daily, Encounter
    }

    [Serializable]
    public enum ActionType
    {
        None=0, Free, Interrupt, Reaction, Minor, Move, Standard
    }

    [Serializable]
    public enum AttackType
    {
        Melee=0, Ranged, Close_Burst, Close_Blast, Area_Blast, Area_Wall, Personal
    }

    [Serializable]
    public abstract class Power : IHTMLWriteable
    {
        protected static string HTML_TEMLPLATE =
    @"<div style=""font-family:arial;font-size:8pt;width:350px;line-height:10.5pt;"">
		<div style=""background-color:#@Colour;color:#FFFFFF;padding:1px 5px 0px 5px;width:340px;height:16px;"">
			<div style=""font-weight:bold;float:left;"">@Name</div>
			<div style=""float:right;"">@LevelText</div>
		</div>
		<div style=""background-color:#DDDDCC;background-image:url('http://omnichron.net/external/op/src/bg_350.jpg');font-style:italic;padding: 1px 0px 3px 5px;"">@FlavourText</div>
		<div style=""padding-left:5px;"">
			<span style=""font-weight:bold;"">@SpellUsage</span> ♦ <span style=""font-weight:bold;"">@Keywords</span><br>
			<span style=""font-weight:bold;"">@ActionType</span> ♦ <span style=""font-weight:bold;"">@Range</span> 
		</div>
		@Elements
		<br />
	</div>";

        protected static string HTML_ELEMENT_TEMPLATE =
        @"<div style=""padding:0px 0px 0px @Indentation;background-image:@Appearance;"">
			<span style=""font-weight:bold;"">@Type</span>
			@Text
		</div>";

        protected static string SHADED = @"url('http://omnichron.net/external/op/src/bg_350.jpg')";
        protected static string NOT_SHADED = "none";
        protected static string PRIMARY_INDENT = "5px";
        protected static string SECONDARY_INDENT = "15px";
        protected static string TERTIARY_INDENT = "25px";
        protected static string AT_WILL_COLOUR = "407040";
        protected static string ENCOUNTER_COLOUR = "704040";
        protected static string DAILY_COLOUR = "404040";

        //protected int e_id = 0;
        public string Name { get; set; }
        public string LevelText { get; set; }
        public string FlavourText { get; set; }
        protected SpellUsage Usage;
        public List<string> Keywords;
        public ActionType Action { get; set; }
        public AttackType Attack { get; set; }
        public string Range { get; set; }
        //public Dictionary<int, Element> Elements;
        public List<Element> Elements;

        public Power()
        {
            //Elements = new Dictionary<int, Element>();
            Elements = new List<Element>();
            Keywords = new List<string>();
        }

        public Element NewElement()
        {
            Element temp = new Element();
            //Elements.Add(e_id++, temp);
            Elements.Add(temp);
            return temp;
        }

        public SpellUsage GetUsage()
        {
            return Usage;
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual string ToHTML()
        {
            StringBuilder builder = new StringBuilder(HTML_TEMLPLATE);
            // Replace Colour & Spell Usage
            switch (Usage)
            {
                case SpellUsage.AtWill:
                    builder.Replace("@Colour", AT_WILL_COLOUR);
                    builder.Replace("@SpellUsage", "At-Will");
                    break;
                case SpellUsage.Daily:
                    builder.Replace("@Colour", DAILY_COLOUR);
                    builder.Replace("@SpellUsage", "Daily");
                    break;
                case SpellUsage.Encounter:
                    builder.Replace("@Colour", ENCOUNTER_COLOUR);
                    builder.Replace("@SpellUsage", "Encounter");
                    break;
                default:
                    builder.Replace("@Colour", "FFFFFF");
                    builder.Replace("@SpellUsage", "Fail");
                    break;
            }

            // Replace Name
            builder.Replace("@Name", Name);

            // Replace Level Text
            builder.Replace("@LevelText", LevelText);

            // Replace Flavour Text
            builder.Replace("@FlavourText", FlavourText);

            // Replace Keywords
            StringBuilder keywordsBuilder = new StringBuilder();
            Keywords.Sort();
            foreach (string s in Keywords)
            {
                if (s.Equals(Keywords[0])) keywordsBuilder.Append(s);
                else keywordsBuilder.Append(", ").Append(s);
            }
            builder.Replace("@Keywords", keywordsBuilder.ToString());

            // Replace Action Type
            switch (Action)
            {
                case ActionType.Free:
                    builder.Replace("@ActionType", "Free Action");
                    break;
                case ActionType.Interrupt:
                    builder.Replace("@ActionType", "Immediate Interrupt");
                    break;
                case ActionType.Minor:
                    builder.Replace("@ActionType", "Minor Action");
                    break;
                case ActionType.Move:
                    builder.Replace("@ActionType", "Move Action");
                    break;
                case ActionType.None:
                    builder.Replace("@ActionType", "No Action");
                    break;
                case ActionType.Reaction:
                    builder.Replace("@ActionType", "Immediate Reaction");
                    break;
                case ActionType.Standard:
                    builder.Replace("@ActionType", "Standard Action");
                    break;
                default:
                    builder.Replace("@ActionType", "Fail");
                    break;
            }

            // Replace Range
            builder.Replace("@Range", Range);

            // Replace Elements
            StringBuilder elementsBuilder = new StringBuilder();

            foreach (Element e in Elements)
            {
                elementsBuilder.Append(e.ToHTML()).Append('\n');
            }
            builder.Replace("@Elements", elementsBuilder.ToString());
            return builder.ToString();
        }
    }
}
