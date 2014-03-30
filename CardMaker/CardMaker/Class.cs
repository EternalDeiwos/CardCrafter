using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace CardMaker.ClassStuff
{
    [Serializable]
    public enum Attributes
    {
        Strength=1, Constitution, Dexterity, Intelligence, Wisdom, Charisma
    }

    [Serializable]
    public enum Skills
    {
        Acrobatics=1, Arcana, Athletics, Bluff, Diplomacy, Dungeoneering, Endurance, Heal, History, Insight, Intimidate, Nature, Perception, Religion, Stealth, Streetwise, Thievery
    }

    [Serializable]
    public enum Defences
    {
        Armour_Class, Fortitude, Reflex, Will
    }

    [Serializable]
    public enum FeatureTypes
    {
        Race, Class, Feat, Background
    }

    [Serializable]
    public class Attribute : IHTMLWriteable
    {
        private static string ATTRIB_HTML = @"
        <div style=""width:232px;margin:0px 0px 8px 0px;"">
			<div style=""background-color:#666666;padding:0px 2px 1px 5px;border-style:solid;border-width:1px;border-color:#000000;height:14px;font-size:8pt;"">
				<div style=""background-color:#CCCCBB;text-align:center;padding:1px 2px 0px 0px;border-style:solid;border-width:1px;border-color:#000000;width:28px;height:17px;float:right;margin:-3px 0px 0px 0px;font-size:9pt;"">@Mod</div>
				<div style=""background-color:#FFFFEE;text-align:center;padding:1px 0px 0px 0px;border-style:solid;border-width:1px;border-color:#000000;width:30px;height:17px;float:right;margin:-3px 3px 0px 0px;font-size:10pt;font-weight:bold;"">@Score</div>
				<span style=""color:#FFFFFF; font-weight:bold;"">@Name</span>
			</div>
		</div>
        ";

        public Attributes Type { get; set; }
        public int Score { get; set; }

        public Attribute(Attributes type, int score)
        {
            Type = type;
            Score = score;
        }

        public Attribute(Attributes type)
        {
            Type = type;
            Score = 10;
        }

        public int GetMod()
        {
            return ((Score - 10) / 2);
        }

        public override string ToString()
        {
            return GetMod().ToString();
        }

        public string ToHTML()
        {
            StringBuilder builder = new StringBuilder(ATTRIB_HTML);

            builder.Replace("@Mod", GetMod().ToString());
            builder.Replace("@Score", Score.ToString());
            builder.Replace("@Name", Type.ToString());

            return builder.ToString();
        }
    }

    [Serializable]
    public class DefenceStat : IHTMLWriteable
    {
        private string DEFENCE_HTML = @"
        <div style=""width:230px;border-style:solid;border-width:1px;margin:0px 0px 8px 0px;"">
			<div style=""background-color:#666666;padding:0px 2px 1px 5px;height:15px;"">
				<div style=""background-color:#FFFFEE;text-align:center;padding:1px 0px 0px 0px;border-style:solid;border-width:1px;border-color:#000000;width:30px;height:17px;float:right;margin:-3px 0px 0px 0px;font-size:10pt;font-weight:bold;"">@Mod</div>
				<span style=""color:#FFFFFF; font-weight:bold;"">@Type</span>
			</div>
			<div style=""font-size:7pt;padding:3px 0px 4px 8px;background-color:#CCCCBB;"">
                @Modifiers
			</div>
		</div>
        ";

        public Defences Type { get; set; }
        public int Defence { get; set; }
        public string Modifiers { get; set; }

        public DefenceStat(Defences type)
        {
            Type = type;
            Defence = 10;
        }

        public string ToHTML()
        {
            StringBuilder builder = new StringBuilder(DEFENCE_HTML);

            switch (Type)
            {
                case Defences.Armour_Class:
                    builder.Replace("@Type", "Armour Class");
                    break;
                case Defences.Fortitude:
                    builder.Replace("@Type", "Fortitude");
                    break;
                case Defences.Reflex:
                    builder.Replace("@Type", "Reflex");
                    break;
                case Defences.Will:
                    builder.Replace("@Type", "Will");
                    break;
                default:
                    break;
            }
            builder.Replace("@Modifiers", Modifiers);
            builder.Replace("@Mod", Defence.ToString());

            return builder.ToString();
        }
    }

    [Serializable]
    public class Feature : IHTMLWriteable
    {
        protected static string FEATURE_INIT_HTML = @"
        <div style=""width:230px;border-style:solid;border-width:1px;margin:0px 0px 8px 0px;"">
			<div style=""background-color:#666666;color:#FFFFFF;font-weight:bold;font-size:8pt;text-align:center;padding:0px 2px 1px 5px"">@Type</div>
			@Feature
		</div>
        ";

        private static string FEATURE_HTML = @"
            <div style=""background-color:#@Colour; padding:3px 5px 4px 5px;font-size:7pt;line-height:10px;"">
				<span style=""font-size:8pt;font-weight:bold;line-height:13px;"">@Name</span><br />@Description
			</div>
        ";

        public string Name { get; set; }
        public string Description { get; set; }
        protected FeatureTypes Type;

        public FeatureTypes GetFeatureType()
        {
            return Type;
        }

        public virtual string ToHTML()
        {
            StringBuilder builder = new StringBuilder(FEATURE_HTML);

            builder.Replace("@Name", Name);
            builder.Replace("@Description", Description);

            return builder.ToString();
        }
    }

    [Serializable]
    public class RaceFeature : Feature
    {
        private static bool Colour = false;
        public RaceFeature()
        {
            Type = FeatureTypes.Race;
            Name = "Race Feature Name";
            Description = "Description";
        }

        public static string GetInitHTML()
        {
            return FEATURE_INIT_HTML.Replace("@Type", "RACE FEATURES");
        }

        public override string ToHTML()
        {
            string HTML = base.ToHTML();

            if (Colour) HTML = HTML.Replace("@Colour", Class.LIGHT_BACKGROUND_COLOUR);
            else HTML = HTML.Replace("@Colour", Class.DARK_BACKGROUND_COLOUR);
            Colour = !Colour;

            return HTML;
        }
    }

    [Serializable]
    public class ClassFeature : Feature
    {
        private static bool Colour = false;
        public ClassFeature()
        {
            Type = FeatureTypes.Class;
            Name = "Class Feature Name";
            Description = "Description";
        }

        public static string GetInitHTML()
        {
            return FEATURE_INIT_HTML.Replace("@Type", "CLASS FEATURES");
        }

        public override string ToHTML()
        {
            string HTML = base.ToHTML();

            if (Colour) HTML = HTML.Replace("@Colour", Class.LIGHT_BACKGROUND_COLOUR);
            else HTML = HTML.Replace("@Colour", Class.DARK_BACKGROUND_COLOUR);
            Colour = !Colour;

            return HTML;
        }
    }

    [Serializable]
    public class Feat : Feature
    {
        private static bool Colour = false;
        public Feat()
        {
            Type = FeatureTypes.Feat;
            Name = "Feat Name";
            Description = "Description";
        }

        public static string GetInitHTML()
        {
            return FEATURE_INIT_HTML.Replace("@Type", "FEATS");
        }

        public override string ToHTML()
        {
            string HTML = base.ToHTML();

            if (Colour) HTML = HTML.Replace("@Colour", Class.LIGHT_BACKGROUND_COLOUR);
            else HTML = HTML.Replace("@Colour", Class.DARK_BACKGROUND_COLOUR);
            Colour = !Colour;

            return HTML;
        }
    }

    [Serializable]
    public class BackgroundFeature : Feature
    {
        private static bool Colour = false;
        public BackgroundFeature()
        {
            Type = FeatureTypes.Background;
            Name = "Background Feature Name";
            Description = "Description";
        }

        public static string GetInitHTML()
        {
            return FEATURE_INIT_HTML.Replace("@Type", "BACKGROUND FEATURES");
        }

        public override string ToHTML()
        {
            string HTML = base.ToHTML();

            if (Colour) HTML = HTML.Replace("@Colour", Class.LIGHT_BACKGROUND_COLOUR);
            else HTML = HTML.Replace("@Colour", Class.DARK_BACKGROUND_COLOUR);
            Colour = !Colour;

            return HTML;
        }
    }

    [Serializable]
    public class BasicPower : IHTMLWriteable
    {
        private static string POWER_INIT_HTML = @"
        <div style=""width:230px;border-style:solid;border-width:1px;margin:0px 0px 8px 0px;"">
			<div style=""background-color:#666666;color:#FFFFFF;font-weight:bold;font-size:8pt;text-align:center;padding:0px 2px 1px 5px"">AT-WILL POWERS</div>
			@AtWill
		</div>
		<div style=""width:230px;border-style:solid;border-width:1px;margin:0px 0px 8px 0px;"">
			<div style=""background-color:#666666;color:#FFFFFF;font-weight:bold;font-size:8pt;text-align:center;padding:0px 2px 1px 5px"">ENCOUNTER POWERS</div>
			@Encounter
		</div>
		<div style=""width:230px;border-style:solid;border-width:1px;margin:0px 0px 8px 0px;"">
			<div style=""background-color:#666666;color:#FFFFFF;font-weight:bold;font-size:8pt;text-align:center;padding:0px 2px 1px 5px"">DAILY POWERS</div>
			@Daily
		</div>
        ";

        private static string POWER_HTML = @"
            <div style=""background-color:#@Colour; padding:3px 5px 4px 5px;font-size:7pt;line-height:10px;"">
				<span style=""font-size:8pt;font-weight:bold;line-height:13px;"">@PowerName</span><br />@Description
			</div>
        
        ";

        private static bool Colour = false;
        public string PowerName { get; set; }
        public string Description { get; set; }

        public BasicPower()
        {
            PowerName = "Power Name";
            Description = "Description";
        }

        public string ToHTML()
        {
            StringBuilder builder = new StringBuilder(POWER_HTML);

            builder.Replace("@PowerName", PowerName);
            builder.Replace("@Description", Description);
            if (Colour) builder.Replace("@Colour", Class.LIGHT_BACKGROUND_COLOUR);
            else builder.Replace("@Colour", Class.DARK_BACKGROUND_COLOUR);
            Colour = !Colour;
            return builder.ToString();
        }

        public static string GetInitHTML()
        {
            return POWER_INIT_HTML;
        }
    }

    [Serializable]
    public class Attack : IHTMLWriteable
    {
        private static string ATTACK_INIT_HTML = @"
        <div style=""width:230px;border-style:solid;border-width:1px;margin:0px 0px 8px 0px;"">
			<div style=""background-color:#666666;color:#FFFFFF;font-weight:bold;font-size:8pt;text-align:center;padding:0px 2px 1px 5px"">ATTACKS</div>
			@Attacks
		</div>
        ";

        private static string ATTACK_HTML = @"
            <div style=""padding:0px 5px 0px 5px;font-size:8pt;background-color:#@Colour;"">
        		<div style=""float:right;width:60px;text-align:center;"">@Damage</div>
				<div style=""float:right;width:60px;text-align:center;"">@AttackBonus vs @TargetDefence</div>
				@Name
            </div>
        ";
        private static bool Colour = false;
        public string Name { get; set; }
        public int AttackBonus { get; set; }
        public Defences TargetDefence { get; set; }
        public string Damage { get; set; }

        public Attack()
        {
            Name = "Melee Basic";
            AttackBonus = 0;
            TargetDefence = Defences.Armour_Class;
            Damage = "1d6";
        }

        public string ToHTML()
        {
            StringBuilder builder = new StringBuilder(ATTACK_HTML);

            builder.Replace("@Damage", Damage);
            builder.Replace("@AttackBonus", AttackBonus.ToString());
            switch (TargetDefence)
            {
                case Defences.Armour_Class:
                    builder.Replace("@TargetDefence", "AC");
                    break;
                case Defences.Fortitude:
                    builder.Replace("@TargetDefence", "Fort");
                    break;
                case Defences.Reflex:
                    builder.Replace("@TargetDefence", "Ref");
                    break;
                case Defences.Will:
                    builder.Replace("@TargetDefence", "Will");
                    break;
                default:
                    throw new InvalidOperationException();
            }
            builder.Replace("@Name", Name);
            if (Colour) builder.Replace("@Colour", Class.LIGHT_BACKGROUND_COLOUR);
            else builder.Replace("@Colour", Class.DARK_BACKGROUND_COLOUR);
            Colour = !Colour;

            return builder.ToString();
        }

        public static string GetInitHTML()
        {
            return ATTACK_INIT_HTML;
        }
    }

    [Serializable]
    public class BasicItem : IHTMLWriteable
    {
        private static string ITEM_INIT_HTML = @"
        <div style=""width:230px;border-style:solid;border-width:1px;margin:0px 0px 8px 0px;"">
			<div style=""background-color:#666666;color:#FFFFFF;font-weight:bold;font-size:8pt;text-align:center;padding:0px 2px 1px 5px"">EQUIPMENT</div>
			@Items
		</div>
        ";

        private static string ITEM_HTML = @"
            <div style=""background-color:#@Colour; padding:3px 5px 4px 5px;font-size:7pt;line-height:10px;"">
				<span style=""font-size:8pt;font-weight:bold;line-height:13px;"">@Name</span><br />@Description
			</div>
        ";
        private static bool Colour = false;
        public string Name { get; set; }
        public string Description { get; set; }

        public BasicItem()
        {
            Name = "Item Name";
            Description = "Description";
        }

        public string ToHTML()
        {
            StringBuilder builder = new StringBuilder(ITEM_HTML);

            builder.Replace("@Name", Name);
            builder.Replace("@Description", Description);
            if (Colour) builder.Replace("@Colour", Class.LIGHT_BACKGROUND_COLOUR);
            else builder.Replace("@Colour", Class.DARK_BACKGROUND_COLOUR);
            Colour = !Colour;
            return builder.ToString();
        }

        public static string GetInitHTML()
        {
            return ITEM_INIT_HTML;
        }
    }

    [Serializable]
    public class Money : IHTMLWriteable
    {
        private static string MONEY_HTML = @"
        <div style=""width:230px;border-style:solid;border-width:1px;margin:0px 0px 8px 0px; margin:0px 0px 13px 0px;"">
			<div style=""background-color:#666666;color:#FFFFFF;font-weight:bold;font-size:8pt;text-align:center;padding:0px 2px 1px 5px"">MONEY</div>
			<div style=""font-size:7pt;padding:3px 0px 4px 2px;background-color:#CCCCBB;height:18px;"">
				<div style=""float:left;width:56px;text-align:center;"">
					Platinum<br />
					<div style=""width:50px;height:14px;padding:1px 0px 0px 0px;margin:0px 3px 0px 3px;text-align:center;font-size:8pt;background-color:#FFFFEE;color:#000000;border-style:solid;border-width:1px;border-color:#000000;"">@Platinum</div>
				</div>
				<div style=""float:left;width:56px;text-align:center;"">
					Gold<br />
					<div style=""width:50px;height:14px;padding:1px 0px 0px 0px;margin:0px 3px 0px 3px;text-align:center;font-size:8pt;background-color:#FFFFEE;color:#000000;border-style:solid;border-width:1px;border-color:#000000;"">@Gold</div>
				</div>
				<div style=""float:left;width:56px;text-align:center;"">
					Silver<br />
					<div style=""width:50px;height:14px;padding:1px 0px 0px 0px;margin:0px 3px 0px 3px;text-align:center;font-size:8pt;background-color:#FFFFEE;color:#000000;border-style:solid;border-width:1px;border-color:#000000;"">@Silver</div>
				</div>
				<div style=""float:left;width:56px;text-align:center;"">
					Copper<br />
					<div style=""width:50px;height:14px;padding:1px 0px 0px 0px;margin:0px 3px 0px 3px;text-align:center;font-size:8pt;background-color:#FFFFEE;color:#000000;border-style:solid;border-width:1px;border-color:#000000;"">@Copper</div>
				</div>
			</div>
		</div>
        ";

        public int Copper { get; set; }
        public int Silver { get; set; }
        public int Gold { get; set; }
        public int Platinum { get; set; }

        public Money()
        {
            Copper = 0;
            Silver = 0;
            Gold = 100;
            Platinum = 0;
        }

        public string ToHTML()
        {
            StringBuilder builder = new StringBuilder(MONEY_HTML);

            builder.Replace("@Platinum", Platinum.ToString());
            builder.Replace("@Gold", Gold.ToString());
            builder.Replace("@Silver", Silver.ToString());
            builder.Replace("@Copper", Copper.ToString());

            return builder.ToString();
        }
    }

    [Serializable]
    public class Familiar : IHTMLWriteable
    {
        private static string FAMILIAR_HTML = @"
        <div style=""width:230px;border-style:solid;border-width:1px;margin:0px 0px 8px 0px;"">
			<div style=""background-color:#666666;color:#FFFFFF;font-weight:bold;font-size:8pt;text-align:left;padding:0px 2px 1px 5px;"">
				<div style=""float:right;font-weight:normal;"">@Type</div>
				@Name
			</div>
			<div style=""padding:2px 5px 2px 5px;font-size:8pt;background-color:#CCCCBB;font-style:italic;"">@Description</div>
			<div style=""padding:2px 5px 0px 5px;font-size:8pt;background-color:#FFFFEE;""><span style=""font-weight:bold;"">Senses: </span>@Senses</div>
			<div style=""padding:0px 5px 2px 5px;font-size:8pt;background-color:#FFFFEE;""><span style=""font-weight:bold;"">Speed: </span>@Speed</div>
			<div style=""padding:2px 5px 2px 5px;font-size:8pt;background-color:#CCCCBB;font-weight:bold;"">Constant Benefits</div>
			<div style=""padding:3px 5px 3px 10px;font-size:7pt;line-height:10px;background-color:#FFFFEE;"">@ConstantBenefits</div>	
			<div style=""padding:2px 5px 2px 5px;font-size:8pt;background-color:#CCCCBB;font-weight:bold;"">Active Benefits</div>
			<div style=""padding:3px 5px 3px 10px;font-size:7pt;line-height:10px;background-color:#FFFFEE;"">@ActiveBenefits</div>			
		</div>
        ";

        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Senses { get; set; }
        public string Speed { get; set; }
        public string ConstantBenefits { get; set; }
        public string ActiveBenefits { get; set; }

        public Familiar()
        {
            Name = "Boo";
            Type = "Miniture Giant Space Hamster";
            Description = "When the going gets tough... somebody hold my rodent!";
            Senses = "Low-Light Vision";
            Speed = "3";
            ConstantBenefits = "You let your familiar do the thinking, and gain +2 on Diplomacy checks.";
            ActiveBenefits = "<b>Go For The Eyes:</b> When you score a critical hit, your target is blinded (save ends).";
        }

        public string ToHTML()
        {
            StringBuilder builder = new StringBuilder(FAMILIAR_HTML);

            builder.Replace("@Name", Name);
            builder.Replace("@Type", Type);
            builder.Replace("@Description", Description);
            builder.Replace("@Senses", Senses);
            builder.Replace("@Speed", Speed);
            builder.Replace("@ConstantBenefits", ConstantBenefits);
            builder.Replace("@ActiveBenefits", ActiveBenefits);

            return builder.ToString();
        }
    }

    [Serializable]
    public class Class : IHTMLWriteable
    {
        private static bool SColour = false;
        private static bool NColour = false;
        public string Name { get; set; }
        public int Level { get; set; }
        public string Race { get; set; }
        public string CharacterClass { get; set; }
        public Dictionary<Attributes, Attribute> AttributesDict;
        public int HP { get; set; }
        public int Bloodied { get; set; }
        public int Surges { get; set; }
        public int SurgeValue { get; set; }
        public string SaveModifiers { get; set; }
        public int Inititive { get; set; }
        public string InitiativeModifiers { get; set; }
        public int Movement { get; set; }
        public string MovementModifiers { get; set; }
        public Dictionary<Skills, int> SkillsDict;
        public Dictionary<Defences, DefenceStat> DefencesDict;
        public List<RaceFeature> RaceFeatures;
        public List<ClassFeature> ClassFeatures;
        public List<Feat> Feats;
        public List<BackgroundFeature> BackgroundFeatures;
        public List<BasicPower> AtWillPowers;
        public List<BasicPower> EncounterPowers;
        public List<BasicPower> DailyPowers;
        public List<Attack> Attacks;
        public List<BasicItem> Items;
        public Money CharacterMoney;
        public Familiar CharacterFamiliar;
        public List<string> Notes;

        public Class()
        {
            Name = "New Class";
            Level = 1;
            Race = "Human";
            CharacterClass = "of no Class";
            AttributesDict = new Dictionary<Attributes, Attribute>();
            foreach (Attributes val in Enum.GetValues(typeof(Attributes)))
            {
                AttributesDict[val] = new Attribute(val);
            }
            HP = 1;
            Bloodied = 0;
            Surges = 0;
            SurgeValue = 0;
            SaveModifiers = "";
            Inititive = 0;
            InitiativeModifiers = "";
            Movement = 6;
            MovementModifiers = "";
            SkillsDict = new Dictionary<Skills, int>();
            DefencesDict = new Dictionary<Defences, DefenceStat>();
            RaceFeatures = new List<RaceFeature>();
            ClassFeatures = new List<ClassFeature>();
            Feats = new List<Feat>();
            BackgroundFeatures = new List<BackgroundFeature>();
            AtWillPowers = new List<BasicPower>();
            EncounterPowers = new List<BasicPower>();
            DailyPowers = new List<BasicPower>();
            Attacks = new List<Attack>();
            Items = new List<BasicItem>();
            Notes = new List<string>();
            CharacterMoney = new Money();
            CharacterFamiliar = new Familiar();
            foreach (Skills val in Enum.GetValues(typeof(Skills)))
            {
                SkillsDict[val] = 0;
            }
            foreach (Defences val in Enum.GetValues(typeof(Defences)))
            {
                DefencesDict[val] = new DefenceStat(val);
            }
            Attacks.Add(new Attack());
            Items.Add(new BasicItem());
            RaceFeatures.Add(new RaceFeature());
            ClassFeatures.Add(new ClassFeature());
            Feats.Add(new Feat());
            BackgroundFeatures.Add(new BackgroundFeature());
            AtWillPowers.Add(new BasicPower());
            EncounterPowers.Add(new BasicPower());
            DailyPowers.Add(new BasicPower());
            Notes.Add("Note");

        }

        public override string ToString()
        {
            return Name;
        }

        public string ToHTML()
        {
            StringBuilder builder = new StringBuilder(CLASS_HTML);
            // Name, Level, Class & Race
            builder.Replace("@Name", Name);
            builder.Replace("@Level", Level.ToString());
            builder.Replace("@Class", CharacterClass);
            builder.Replace("@Race", Race);
            
            //Attributes
            StringBuilder attrib = new StringBuilder();
            attrib.Append(AttributesDict[Attributes.Strength].ToHTML());
            attrib.Append(AttributesDict[Attributes.Constitution].ToHTML());
            attrib.Append(AttributesDict[Attributes.Dexterity].ToHTML());
            attrib.Append(AttributesDict[Attributes.Intelligence].ToHTML());
            attrib.Append(AttributesDict[Attributes.Wisdom].ToHTML());
            attrib.Append(AttributesDict[Attributes.Charisma].ToHTML());
            builder.Replace("@Attributes", attrib.ToString());

            //HP
            builder.Replace("@HP", HP_INIT_HTML);
            builder.Replace("@HitPoints", HP.ToString());
            builder.Replace("@Bloodied", Bloodied.ToString());
            builder.Replace("@Surges", Surges.ToString());
            builder.Replace("@SurgeValue", SurgeValue.ToString());

            //Saves
            builder.Replace("@SaveModifiers", SAVES_INIT_HTML);
            builder.Replace("@SaveModifiers", SaveModifiers);
            
            //Initiative
            builder.Replace("@InitiativeModifiers", INITIATIVE_INIT_HTML);
            builder.Replace("@InitiativeModifiers", InitiativeModifiers);
            builder.Replace("@Initiative", Inititive.ToString());

            //Speed
            builder.Replace("@MovementModifiers", MOVEMENT_INIT_HTML);
            builder.Replace("@MovementModifiers", MovementModifiers);
            builder.Replace("@Movement", Movement.ToString());

            //Skills
            StringBuilder skills = new StringBuilder();
            foreach (KeyValuePair<Skills, int> k in SkillsDict)
            {
                skills.Append(SKILL_HTML.Replace("@Mod", k.Value.ToString()).Replace("@Skill", k.Key.ToString()));
                if (SColour) skills.Replace("@SColour", Class.LIGHT_BACKGROUND_COLOUR);
                else skills.Replace("@SColour", Class.DARK_BACKGROUND_COLOUR);
                SColour = !SColour;
            }
            builder.Replace("@Skills", SKILL_INIT_HTML);
            builder.Replace("@Skills", skills.ToString());
            

            //DefenceStats
            StringBuilder defences = new StringBuilder();
            foreach (DefenceStat def in DefencesDict.Values)
            {
                defences.Append(def.ToHTML());
            }
            builder.Replace("@DefenceStats", defences.ToString());

            //Race Features
            builder.Replace("@RceFeatures", RaceFeature.GetInitHTML());
            StringBuilder race = new StringBuilder("");
            foreach (RaceFeature feat in RaceFeatures)
            {
                race.Append(feat.ToHTML());
            }
            builder.Replace("@Feature", race.ToString());

            //Class Features
            builder.Replace("@ClssFeatures", ClassFeature.GetInitHTML());
            StringBuilder clss = new StringBuilder("");
            foreach (ClassFeature feat in ClassFeatures)
            {
                clss.Append(feat.ToHTML());
            }
            builder.Replace("@Feature", clss.ToString());

            //Feats
            builder.Replace("@Feats", Feat.GetInitHTML());
            StringBuilder feats = new StringBuilder("");
            foreach (Feat feat in Feats)
            {
                feats.Append(feat.ToHTML());
            }
            builder.Replace("@Feature", feats.ToString());

            //Background Features
            builder.Replace("@BackgroundFeatures", BackgroundFeature.GetInitHTML());
            StringBuilder back = new StringBuilder("");
            foreach (BackgroundFeature feat in BackgroundFeatures)
            {
                back.Append(feat.ToHTML());
            }
            builder.Replace("@Feature", back.ToString());

            //Powers
            builder.Replace("@Powers", BasicPower.GetInitHTML());
            //AtWill
            StringBuilder atwill = new StringBuilder();
            foreach (BasicPower p in AtWillPowers)
            {
                atwill.Append(p.ToHTML());
            }
            builder.Replace("@AtWill", atwill.ToString());
            //Encounter
            StringBuilder enc = new StringBuilder();
            foreach (BasicPower p in EncounterPowers)
            {
                enc.Append(p.ToHTML());
            }
            builder.Replace("@Encounter", enc.ToString());
            //Daily
            StringBuilder day = new StringBuilder();
            foreach (BasicPower p in DailyPowers)
            {
                day.Append(p.ToHTML());
            }
            builder.Replace("@Daily", day.ToString());

            //Attacks
            builder.Replace("@Attacks", Attack.GetInitHTML());
            StringBuilder atk = new StringBuilder();
            foreach (Attack a in Attacks)
            {
                atk.Append(a.ToHTML());
            }
            builder.Replace("@Attacks", atk.ToString());

            //Equipment
            builder.Replace("@Equipment", BasicItem.GetInitHTML());
            StringBuilder items = new StringBuilder();
            foreach (BasicItem i in Items)
            {
                items.Append(i.ToHTML());
            }
            builder.Replace("@Items", items.ToString());

            //Money
            builder.Replace("@Money", CharacterMoney.ToHTML()); 

            //Familiar
            builder.Replace("@Familiar", CharacterFamiliar.ToHTML());

            //Notes
            if (Notes.Count != 0) { builder.Replace("@Notes", NOTES_HTML); }
            StringBuilder notes = new StringBuilder();
            foreach (string note in Notes)
            {
                notes.Append(NOTE_SINGLE_HTML.Replace("@Note", note));
                if (NColour) notes.Replace("@NColour", Class.LIGHT_BACKGROUND_COLOUR);
                else notes.Replace("@NColour", Class.DARK_BACKGROUND_COLOUR);
                NColour = !NColour;
            }
            builder.Replace("@Notes", notes.ToString());

            return builder.ToString();
        }

        public static string DARK_BACKGROUND_COLOUR = "CCCCBB";
        public static string LIGHT_BACKGROUND_COLOUR = "FFFFEE";

        private static string NOTES_HTML = @"
        <div style=""width:230px;border-style:solid;border-width:1px;margin:0px 0px 8px 0px;"">
			<div style=""background-color:#666666;color:#FFFFFF;font-weight:bold;font-size:8pt;text-align:center;padding:0px 2px 1px 5px"">CHARACTER NOTES</div>
			@Notes
		</div>
        ";

        private static string NOTE_SINGLE_HTML = @"
        <div style=""padding:0px 5px 0px 5px;font-size:8pt;background-color:#@NColour;"">@Note</div>
        ";

        private static string SKILL_HTML = @"
        <div style=""padding:0px 5px 0px 5px;font-size:8pt;background-color:#@SColour;""><div style=""float:right;"">@Mod</div>@Skill</div>
        ";

        private static string SKILL_INIT_HTML = @"
        <div style=""width:230px;border-style:solid;border-width:1px;margin:0px 0px 8px 0px;"">
			<div style=""background-color:#666666;color:#FFFFFF;font-weight:bold;font-size:8pt;text-align:center;padding:0px 2px 1px 5px"">SKILLS</div>
			@Skills
		</div>
        ";

        private static string MOVEMENT_INIT_HTML = @"
        <div style=""width:230px;border-style:solid;border-width:1px;margin:0px 0px 8px 0px;"">
			<div style=""background-color:#666666;padding:0px 2px 1px 5px;height:15px;"">
				<div style=""background-color:#FFFFEE;text-align:center;padding:1px 0px 0px 0px;border-style:solid;border-width:1px;border-color:#000000;width:30px;height:17px;float:right;margin:-3px 0px 0px 0px;font-size:10pt;font-weight:bold;"">@Movement</div>
				<span style=""color:#FFFFFF; font-weight:bold;"">Speed</span>
			</div>
			<div style=""font-size:7pt;padding:3px 0px 4px 8px;background-color:#CCCCBB;"">
                @MovementModifiers
			</div>
		</div>
        ";

        private static string INITIATIVE_INIT_HTML = @"
        <div style=""width:230px;border-style:solid;border-width:1px;margin:0px 0px 8px 0px;"">
			<div style=""background-color:#666666;padding:0px 2px 1px 5px;height:15px;"">
				<div style=""background-color:#FFFFEE;text-align:center;padding:1px 0px 0px 0px;border-style:solid;border-width:1px;border-color:#000000;width:30px;height:17px;float:right;margin:-3px 0px 0px 0px;font-size:10pt;font-weight:bold;"">@Initiative</div>
				<span style=""color:#FFFFFF; font-weight:bold;"">Initiative</span>
			</div>
			<div style=""font-size:7pt;padding:3px 0px 4px 8px;background-color:#CCCCBB;"">
                @InitiativeModifiers
			</div>
		</div>
        ";

        private static string SAVES_INIT_HTML = @"
        <div style=""width:230px;border-style:solid;border-width:1px;margin:0px 0px 8px 0px;"">
			<div style=""background-color:#666666;color:#FFFFFF;font-weight:bold;font-size:8pt;text-align:center;padding:0px 2px 1px 5px"">SAVE MODIFIERS</div>
			<div style=""padding:0px 5px 0px 5px;font-size:8pt;background-color:#CCCCBB;"">@SaveModifiers</div>
		</div>
        ";

        private static string HP_INIT_HTML = @"
        <div style=""width:230px;border-style:solid;border-width:1px;margin:0px 0px 8px 0px; margin:0px 0px 15px 0px;"">
			<div style=""background-color:#666666;color:#FFFFFF;font-weight:bold;font-size:8pt;text-align:center;padding:0px 2px 1px 5px"">HIT POINTS</div>
			<div style=""font-size:7pt;padding:3px 15px 4px 15px;background-color:#CCCCBB;height:22px;"">
				<div style=""float:left;width:50px;text-align:center;"">
					Total<br />
					<div style=""width:40px;height:18px;padding:3px 0px 0px 0px;margin:0px 6px 0px 4px;text-align:center;font-size:10pt;background-color:#FFFFEE;color:#000000;border-style:solid;border-width:1px;border-color:#000000; font-weight:bold;"">@HitPoints</div>
				</div>
				<div style=""float:left;width:50px;text-align:center;"">
					Bloodied<br />
					<div style=""width:40px;height:18px;padding:3px 0px 0px 0px;margin:0px 6px 0px 4px;text-align:center;font-size:10pt;background-color:#FFFFEE;color:#000000;border-style:solid;border-width:1px;border-color:#000000;"">@Bloodied</div>
				</div>
				<div style=""float:left;width:50px;text-align:center;"">
					Surges<br />
					<div style=""width:40px;height:18px;padding:3px 0px 0px 0px;margin:0px 6px 0px 4px;text-align:center;font-size:10pt;background-color:#FFFFEE;color:#000000;border-style:solid;border-width:1px;border-color:#000000;"">@Surges</div>
				</div>
				<div style=""float:left;width:50px;text-align:center;"">
					Value<br />
					<div style=""width:40px;height:18px;padding:3px 0px 0px 0px;margin:0px 6px 0px 4px;text-align:center;font-size:10pt;background-color:#FFFFEE;color:#000000;border-style:solid;border-width:1px;border-color:#000000;"">@SurgeValue</div>
				</div>
			</div>
		</div>
        ";

        private static string CLASS_HTML = @"
<div style=""font-family:arial;font-size:8pt;width:730px;line-height:normal;color:#000000;border-style:solid;border-width:1px;text-align:left;"">
	<div style=""color:#FFFFFF;background-color:#666666;padding:4px 8px 5px 8px;font-size:10pt;"">
		<div style=""float:right;"">Level @Level @Race @Class</div>
		<div style=""font-weight:bold;"">@Name</div>
	</div>
	<span style=""display:inline-block;width:232px;margin:8px 3px 1px 8px;vertical-align: top;"">
		@Attributes
		@HP
		@SaveModifiers
		@InitiativeModifiers
		@MovementModifiers
		@Skills
	</span>
	<span style=""display:inline-block;width:232px;margin:8px 3px 1px 3px;vertical-align: top;"">
        @DefenceStats
		@RceFeatures
        @ClssFeatures
        @Feats
        @BackgroundFeatures
	</span>
	<span style=""display:inline-block;width:232px;margin:8px 8px 1px 3px;vertical-align: top;"">
		@Powers
		@Attacks
        @Equipment
		@Money
		@Familiar
		@Notes
	</span>
</div>";
    }
}
