using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.StringTemplate;
using CardMakerBackend.CardTypes;

namespace CardMakerWPF
{
    public class Card
    {
        public string HTML { private set; get; }

        public Card(Power p)
        {
            Template power_template = new Template(Properties.Resources.PowerTemplate);

            switch (p.Usage)
            {
                case Power.SpellUsage.AtWill:
                    power_template.Add("Colour", "#407040");
                    power_template.Add("Usage", "At Will");
                    break;
                case Power.SpellUsage.Encounter:
                    power_template.Add("Colour", "#704040");
                    power_template.Add("Usage", "Encounter");
                    break;
                case Power.SpellUsage.Daily:
                    power_template.Add("Colour", "#404040");
                    power_template.Add("Usage", "Daily");
                    break;
            }

            power_template.Add("Name", p.Name);
            power_template.Add("Level", p.Level);
            power_template.Add("BackgroundImage", @"/Resources/Images/bg_350.jpg");
            power_template.Add("FlavourText", p.FlavourText);

            switch (p.Action)
            {
                case ActionType.Standard:
                    power_template.Add("Action", "Standard Action");
                    break;
                case ActionType.Reaction:
                    power_template.Add("Action", "Immeidiate Reaction");
                    break;
                case ActionType.None:
                    power_template.Add("Action", "No Action");
                    break;
                case ActionType.Move:
                    power_template.Add("Action", "Movement Action");
                    break;
                case ActionType.Minor:
                    power_template.Add("Action", "Minor Action");
                    break;
                case ActionType.Interrupt:
                    power_template.Add("Action", "Immediate Interrupt");
                    break;
                case ActionType.Free:
                    power_template.Add("Action", "Free Action");
                    break;
            }

            switch (p.Attack)
            {
                case AttackType.Melee:
                    power_template.Add("Attack", "Melee");
                    break;
                case AttackType.Personal:
                    power_template.Add("Attack", "Personal");
                    break;
                case AttackType.Ranged:
                    power_template.Add("Attack", "Ranged");
                    break;
                case AttackType.Close_Burst:
                    power_template.Add("Attack", "Close Burst");
                    break;
                case AttackType.Close_Blast:
                    power_template.Add("Attack", "Close Blast");
                    break;
                case AttackType.Area_Wall:
                    power_template.Add("Attack", "Area Wall");
                    break;
                case AttackType.Area_Blast:
                    power_template.Add("Attack", "Area Blast");
                    break;
            }

            power_template.Add("Range", p.Range);

            foreach (string s in p.Keywords)
            {
                power_template.Add("Keywords", s);
            }

            foreach (Power.Element e in p.Elements)
            {
                power_template.Add("Type", e.Type);
                power_template.Add("Text", e.Text);
                switch (e.Spacing)
                {
                    case Power.Element.Indent.Primary:
                        power_template.Add("Indent", "5");
                        break;
                    case Power.Element.Indent.Secondary:
                        power_template.Add("Indent", "15");
                        break;
                    case Power.Element.Indent.Tertiary:
                        power_template.Add("Indent", "25");
                        break;
                }
                if (e.Shaded)
                {
                    power_template.Add("Shading", @"/Resources/Images/bg_350.jpg");
                }
                else power_template.Add("Shading", "");
            }

            HTML = power_template.ToString();
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
    }
}
