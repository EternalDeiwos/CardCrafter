using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CardMaker
{
    [Serializable]
    public class Aura : IHTMLWriteable
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Radius { get; set; }
        public string Description { get; set; }

        private static string AURA_HTML = @"
    <div style=""background-color:#DDDDCC;padding:0px 0px 3px 5px;margin:-3px 0px 0px 0px;"">
		<div style=""margin-left:15px;text-indent:-15px;"">
			<b>@Name (@Type)</b> Aura @Radius; @Description<br />
		</div>
	</div>
        ";

        public Aura()
        {
            Name = "Default Aura";
            Radius = 1;
            Type = "Fear";
            Description = "None";
        }

        public override string ToString()
        {
            return Name;
        }

        public string ToHTML()
        {
            StringBuilder builder = new StringBuilder(AURA_HTML);

            builder.Replace("@Name", Name);
            builder.Replace("@Radius", Radius.ToString());
            builder.Replace("@Description", Description);
            builder.Replace("@Type", Type);

            return builder.ToString();
        }
    }

    [Serializable]
    public class MinionPower : IHTMLWriteable
    {
        public string Name { get; set; }
        public ActionType Action { get; set; }
        public SpellUsage Usage { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }

        private static string ATTACKS_HTML = @"
    <div style=""background-color:#CCCCBB;position:relative;padding:1px 0px 2px 5px;"">
		<img src=""http://omnichron.net/external/op/src/melee-basic.png"" style=""position:relative;top:2px;"" />
		<b>@Name</b> (@Action, @Usage) ♦ <b>@Keywords</b>
	</div>
	<div style=""background-color:#DDDDCC;padding: 1px 0px 2px 20px;"">
		@Description
	</div>
        ";

        public MinionPower()
        {
            Name = "Melee Basic";
            Action = ActionType.Standard;
            Usage = SpellUsage.AtWill;
            Keywords = "Melee";
            Description = "None";
        }

        public override string ToString()
        {
            return Name;
        }

        public string ToHTML()
        {
            StringBuilder builder = new StringBuilder(ATTACKS_HTML);

            builder.Replace("@Name", Name);
            builder.Replace("@Action", Action.ToString());
            builder.Replace("@Usage", Usage.ToString());
            builder.Replace("@Keywords", Keywords);
            builder.Replace("@Description", Description);

            return builder.ToString();
        }
    }

    [Serializable]
    public class Monster : IHTMLWriteable, ISerializable
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string Roll { get; set; }
        public string Size { get; set; }
        public string Origin { get; set; }
        public string Type { get; set; }
        public int XPValue { get; set; }
        public int Initiative { get; set; }
        public string Senses { get; set; }
        public int HP { get; set; }
        public int Bloodied { get; set; }
        public int AC { get; set; }
        public int Fort { get; set; }
        public int Ref { get; set; }
        public int Will { get; set; }
        public string SavesMod { get; set; }
        public string Resists { get; set; }
        public int Speed { get; set; }
        public string ActionPoints { get; set; }
        public string Alignment { get; set; }
        public string Languages { get; set; }
        public string Skills { get; set; }
        public string Equipment { get; set; }
        public Dictionary<ClassStuff.Attributes, int> AttributesDict;
        public List<MinionPower> Attacks;
        public List<Aura> Auras;

        public Monster()
        {
            Name = "New Monster";
            Level = 1;
            Roll = "Minion";
            Size = "Medium";
            Origin = "Natural";
            Type = "Humanoid";
            XPValue = 0;
            Initiative = 0;
            Senses = "Perception 0";
            HP = 1;
            Bloodied = 0;
            AC = 12;
            Fort = 10;
            Ref = 10;
            Will = 10;
            SavesMod = "0";
            Resists = "None";
            Speed = 6;
            ActionPoints = "None";
            Alignment = "Unaligned";
            Languages = "Common";
            Skills = "Perception 0";
            Equipment = "None";
            AttributesDict = new Dictionary<ClassStuff.Attributes, int>();
            AttributesDict[ClassStuff.Attributes.Strength] = 10;
            AttributesDict[ClassStuff.Attributes.Constitution] = 10;
            AttributesDict[ClassStuff.Attributes.Dexterity] = 10;
            AttributesDict[ClassStuff.Attributes.Intelligence] = 10;
            AttributesDict[ClassStuff.Attributes.Wisdom] = 10;
            AttributesDict[ClassStuff.Attributes.Charisma] = 10;
            Attacks = new List<MinionPower>();
            Auras = new List<Aura>();
            Attacks.Add(new MinionPower());
            Auras.Add(new Aura());
        }

        public override string ToString()
        {
            return Name;
        }

        public string ToHTML()
        {
            StringBuilder builder = new StringBuilder(MONSTER_HTML);

            //Basics
            builder.Replace("@Name", Name);
            builder.Replace("@Level", Level.ToString());
            builder.Replace("@Roll", Roll);
            builder.Replace("@Size", Size);
            builder.Replace("@Origin", Origin);
            builder.Replace("@Type", Type);
            builder.Replace("@XP", XPValue.ToString());

            //Main Body
            builder.Replace("@Initiative", Initiative.ToString());
            builder.Replace("@Senses", Senses);
            builder.Replace("@HP", HP.ToString());
            if (Bloodied <= 0) builder.Replace("@Bloodied", "NA");
            else builder.Replace("@Bloodied", Bloodied.ToString());
            builder.Replace("@Speed", Speed.ToString());
            builder.Replace("@AC", AC.ToString());
            builder.Replace("@Fort", Fort.ToString());
            builder.Replace("@Ref", Ref.ToString());
            builder.Replace("@Will", Will.ToString());
            builder.Replace("@Saves", SavesMod);
            builder.Replace("@Resists", Resists);
            builder.Replace("@ActionPoints", ActionPoints);
            builder.Replace("@Alignment", Alignment);
            builder.Replace("@Languages", Languages);
            builder.Replace("@Skills", Skills);
            builder.Replace("@Equipment", Equipment);

            //Attributes
            builder.Replace("@Attributes", ATTRIBUTES_HTML);
            builder.Replace("@Str", AttributesDict[ClassStuff.Attributes.Strength].ToString());
            builder.Replace("@Con", AttributesDict[ClassStuff.Attributes.Constitution].ToString());
            builder.Replace("@Dex", AttributesDict[ClassStuff.Attributes.Dexterity].ToString());
            builder.Replace("@Int", AttributesDict[ClassStuff.Attributes.Intelligence].ToString());
            builder.Replace("@Wis", AttributesDict[ClassStuff.Attributes.Wisdom].ToString());
            builder.Replace("@Cha", AttributesDict[ClassStuff.Attributes.Charisma].ToString());
            builder.Replace("@ModStr", GetMod(AttributesDict[ClassStuff.Attributes.Strength]).ToString());
            builder.Replace("@ModCon", GetMod(AttributesDict[ClassStuff.Attributes.Constitution]).ToString());
            builder.Replace("@ModDex", GetMod(AttributesDict[ClassStuff.Attributes.Dexterity]).ToString());
            builder.Replace("@ModInt", GetMod(AttributesDict[ClassStuff.Attributes.Intelligence]).ToString());
            builder.Replace("@ModWis", GetMod(AttributesDict[ClassStuff.Attributes.Wisdom]).ToString());
            builder.Replace("@ModCha", GetMod(AttributesDict[ClassStuff.Attributes.Charisma]).ToString());

            //Auras
            StringBuilder auras = new StringBuilder();
            foreach (Aura aura in Auras)
            {
                auras.Append(aura.ToHTML());
            }

            //Powers
            StringBuilder powers = new StringBuilder();
            foreach (MinionPower power in Attacks)
            {
                powers.Append(power.ToHTML());
            }

            builder.Replace("@Attacks", powers.ToString());
            builder.Replace("@Auras", auras.ToString());

            return builder.ToString();
        }

        public static int GetMod(int score)
        {
            return (score - 10) / 2;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        private static string ATTRIBUTES_HTML = @"
        <table style=""border-style:none;border-collapse:collapse;margin:0px 0px 0px 0px;width:344px;"">
			<tr>
				<td style=""font-size:8pt;border-style:none;padding:0px 0px 0px 0px;width:115px;""><b>Str</b> @Str (@ModStr)</td>
				<td style=""font-size:8pt;border-style:none;padding:0px 0px 0px 0px;width:115px;""><b>Dex</b> @Dex (@ModDex)</td>
				<td style=""font-size:8pt;border-style:none;padding:0px 0px 0px 0px;width:115px;""><b>Wis</b> @Wis (@ModWis)</td>
			</tr>
			<tr>
				<td style=""font-size:8pt;border-style:none;padding:0px 0px 0px 0px;width:115px;""><b>Con</b> @Con (@ModCon)</td>
				<td style=""font-size:8pt;border-style:none;padding:0px 0px 0px 0px;width:115px;""><b>Int</b> @Int (@ModInt)</td>
				<td style=""font-size:8pt;border-style:none;padding:0px 0px 0px 0px;width:115px;""><b>Cha</b> @Cha (@ModCha)</td>
			</tr>
		</table>
        ";

        private static string MONSTER_HTML = @"
<div style=""font-family:arial;font-size:8pt;width:350px;line-height:10.5pt;"">
	<div style=""background-color:#506050;color:#FFFFFF;padding:2px 5px 0px 5px;height:28px;"">
		<div style=""font-weight:bold;float:left;"">@Name</div>
		<div style=""font-weight:bold;float:right;"">Level @Level @Roll</div>
		<br />
		<div style=""float:left;font-size:7pt;"">@Size @Origin @Type</div>
		<div style=""float:right;font-size:7pt;"">XP @XP</div>
	</div>
	<div style=""background-color:#DDDDCC;padding:0px 0px 3px 5px;"">
		<b>Initiative</b> @Initiative ♦ <b>Senses</b> @Senses<br />
		<b>HP</b> @HP; <b>Bloodied</b> @Bloodied<br />
		<b>AC</b> @AC; <b>Fortitude</b> @Fort, <b>Reflex</b> @Ref, <b>Will</b> @Will<br />
		<b>Saves</b> @Saves<br />
		<b>Resists</b> @Resists<br />
		<b>Speed</b> @Speed<br />
		<b>Action Points</b> @ActionPoints<br />
	</div>
	@Auras
	@Attacks
	<div style=""background-color:#CCCCBB;padding: 1px 0px 3px 5px;"">
		<b>Alignment</b> @Alignment ♦ <b>Languages</b> @Languages<br />
		<b>Skills</b> @Skills<br />
		@Attributes
	</div>
	<div style=""background-color:#DDDDCC;padding: 2px 0px 3px 5px;"">
		<b>Equipment</b> @Equipment
	</div>
	<br />
</div>
        ";
    }
}
