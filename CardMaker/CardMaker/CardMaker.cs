using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CardMaker
{
    public partial class CardMaker : Form
    {
        static int id = 0;
        Dictionary<int, IHTMLWriteable> Cards;
        string open_file = null;

        public CardMaker()
        {
            InitializeComponent();
            Cards = new Dictionary<int, IHTMLWriteable>();
            //MessageBox.Show(test());
            webBrowser.DocumentText = test();
        }

        public string test()
        {
            Power power = new AtWill();
            power.Action = ActionType.Standard;
            power.Attack = AttackType.Ranged;
            power.FlavourText = "A brilliant ray of light sears your foe with golden radiance. Sparkles of light linger around your target, guiding your ally's attack.";
            power.Keywords.Add("Divine");
            power.Keywords.Add("Implement");
            power.Keywords.Add("Radiant");
            power.LevelText = "Cleric Attack 1";
            power.Name = "Lance of Faith";
            power.Range = "5";
            Element el1 = power.NewElement();
            Element el2 = power.NewElement();
            Element el3 = power.NewElement();
            Element el4 = power.NewElement();
            el1.Indent = Indentation.Primary;
            el1.Shading = Appearance.Not_Shaded;
            el1.Type = "Target";
            el1.Text = "One Creature";

            el2.Indent = Indentation.Primary;
            el2.Shading = Appearance.Not_Shaded;
            el2.Type = "Attack";
            el2.Text = "Wisdom vs. Reflex";

            el3.Indent = Indentation.Secondary;
            el3.Shading = Appearance.Shaded;
            el3.Type = "Hit";
            el3.Text = "1d8 + Wisdom modifier radiant damage, and one ally you can see gains a +2 bonus to his or her next attack roll against the target.";

            el4.Indent = Indentation.Primary;
            el4.Shading = Appearance.Not_Shaded;
            el4.Type = "";
            el4.Text = "Increase damage to 2d8 + Wisdom Modifier at 21st level.";

            //-----------------------------------------------------------------------------------

            Item item = new Item();
            item.LevelText = "Level 4+";
            item.Name = "Fail";
            item.FlavourText = "blah";
            Item.ItemVersion itemversion = item.NewItemVersion();
            itemversion.Bonus = "+1";
            itemversion.GoldCost = "625,000";
            itemversion.Level = "Lvl 4";
            //item.ItemVersions.Add("Lvl 4\t+1\t840 gp");

            return power.ToHTML() + @"<br>" + item.ToHTML();
        }

        public static int getNewID()
        {
            return id++;
        }

        private void SaveFile()
        {
        }

        private void OpenFile()
        {
        }

        private void createPower<T>() where T : Power, new()
        {
            Power power = new T();

            power.Action = ActionType.Free;
            power.Attack = AttackType.Personal;
            power.FlavourText = "random ability";
            power.Keywords.Add("Arcane");
            power.LevelText = "Scum Utility";
            power.Name = "Scum";
            power.Range = "Weapon";
            Element el = power.NewElement();
            el.Indent = Indentation.Tertiary;
            el.Shading = Appearance.Shaded;
            el.Type = "Prerequisite";
            el.Text = "blah";

            Cards.Add(power.getID(), power);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure? Any unsaved work will be lost.", "Confirmation", MessageBoxButtons.YesNo);
            if (dr.Equals(DialogResult.Yes)) Application.Exit();
        }

        private void atWillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //createPower<AtWill>();
        }

        private void encounterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createPower<Encounter>();
        }

        private void dailyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createPower<Daily>();
        }

        private void classToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void monsterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!open_file.Equals(null)) SaveFile();
            openFileDialog1.ShowDialog();
            open_file = openFileDialog1.FileName;
            if (!open_file.Equals(null)) OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (open_file.Equals(null))
            {
                saveFileDialog1.ShowDialog();
                open_file = saveFileDialog1.FileName;
            }
            if (!open_file.Equals(null))
            {
                SaveFile();
            }
            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            open_file = saveFileDialog1.FileName;
            if (!open_file.Equals(null)) SaveFile();
        }
    }
}
