using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CardMaker
{
    enum SpellUsage
    {
        AtWill, Daily, Encounter
    }

    enum ActionType
    {
        None, Free, Interrupt, Reaction, Minor, Move, Standard
    }

    enum AttackType
    {
        Melee, Ranged, Close_Burst, Close_Blast, Area_Blast, Area_Wall, Personal
    }

    enum Appearance
    {
        Shaded, Not_Shaded
    }

    enum Indentation
    {
        Primary, Secondary, Tertiary
    }

    class Power : IHTMLWriteable, ISerializable
    {

        static string HTML_TEMLPLATE =
    @"<div style=""font-family:arial;font-size:8pt;width:350px;line-height:10.5pt;"">
		<div style=""background-color:#407040;color:#FFFFFF;padding:1px 5px 0px 5px;width:340px;height:16px;"">
			<div style=""font-weight:bold;float:left;"">Ambush Trick</div>
			<div style=""float:right;"">Rogue Utility</div>
		</div>
		<div style=""background-color:#DDDDCC;background-image:url('http://omnichron.net/external/op/src/bg_350.jpg');font-style:italic;padding: 1px 0px 3px 5px;"">You dodge and weave, making a feint that causes your foe to turn and lose track of you.</div>
		<div style=""padding-left:5px;"">
			<span style=""font-weight:bold;"">At-Will</span> ♦ <span style=""font-weight:bold;"">Martial</span><br>
			<span style=""font-weight:bold;"">Move Action</span> ♦ <span style=""font-weight:bold;"">Personal</span> 
		</div>
		<div style=""padding:0px 0px 0px 5px;background-image:url('http://omnichron.net/external/op/src/bg_350.jpg');"">
			<span style=""font-weight:bold;"">Effect:</span>
			You move up to your speed. Until the end of your turn, you gain combat advantage against enemies that are within 5 squares of you when you attack and that have none of their allies adjacent to them.
		</div>
		<br />
	</div>";

        private int id;
        protected int e_id = 0;
        public string Name { get; set; }
        public string LevelText { get; set; }
        public string FlavourText { get; set; }
        protected static SpellUsage Usage;
        public string Keywords { get; set; }
        public ActionType Action { get; set; }
        public AttackType Attack { get; set; }
        public string Range { get; set; }
        protected Dictionary<int, Element> ElementDict;

        virtual public Power()
        {
            id = CardMaker.getNewID();
            ElementDict = new Dictionary<int, Element>();
        }

        public int getID()
        {
            return id;
        }

        private Element newElement()
        {
            Element temp = new Element(e_id++);
            ElementDict.Add(temp.GetID(), temp);
            return temp;
        }

        virtual string ToHTML();

        protected class Element : ISerializable
        {
            private int id;
            public string Type { get; set; }
            public string Text { get; set; }
            public Appearance Shading { get; set; }
            public Indentation Indent { get; set; }

            public Element(int id)
            {
                this.id = id;
            }

            public string ToString()
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(Type).Append(" ").Append(Text);
                return builder.ToString();
            }

            public int GetID()
            {
                return id;
            }
        }
    }
}
