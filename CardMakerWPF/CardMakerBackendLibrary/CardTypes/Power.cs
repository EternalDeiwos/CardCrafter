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

            public string Text { get; set; }
            public string Type { get; set; }
            public bool Shaded { get; set; }
            public Indent Spacing { get; set; }
        }
        #endregion

        public string Name { get; set; }
        public string Level { get; set; }
        public string FlavourText { get; set; }
        public SpellUsage Usage { get; private set; }
        public List<string> Keywords;
        public ActionType Action { get; set; }
        public AttackType Attack { get; set; }
        public string Range { get; set; }
        public List<Element> Elements;

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
            Element el1 = new Power.Element();
            Element el2 = new Power.Element();
            Element el3 = new Power.Element();
            Element el4 = new Power.Element();
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
