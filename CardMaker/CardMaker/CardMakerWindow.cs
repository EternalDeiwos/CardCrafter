using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CardMaker.ClassStuff;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CardMaker
{
    public enum CardTypes
    {
        AtWill, Encounter, Daily, Item, Monster, Class
    }

    [Flags]
    public enum AnimateWindowFlags
    {
        AW_HOR_POSITIVE = 0x00000001,
	    AW_HOR_NEGATIVE = 0x00000002,
	    AW_VER_POSITIVE = 0x00000004,
	    AW_VER_NEGATIVE = 0x00000008,
	    AW_CENTER = 0x00000010,
	    AW_HIDE = 0x00010000,
	    AW_ACTIVATE = 0x00020000,
	    AW_SLIDE = 0x00040000,
	    AW_BLEND = 0x00080000
    }

    public partial class CardMakerWindow : Form
    {
        public string filename = "";

        [DllImport("user32.dll")]
        static extern bool AnimateWindow(IntPtr hWnd, int time, AnimateWindowFlags flags);

        public CardMakerWindow()
        {
            InitializeComponent();
            //cardListBox.Items.Add(lance());
            //cardListBox.Items.Add(item());
            //cardListBox.Items.Add(healers_crystal());
        }

        private IHTMLWriteable lance()
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

            return power;
        }

        //private IHTMLWriteable item()
        //{
        //    Item item = new Item();
        //    item.LevelText = "Level 4+";
        //    item.Name = "Fail";
        //    item.FlavourText = "blah";
        //    ItemVersion itemv1 = item.NewItemVersion();
        //    itemv1.Bonus = "+1";
        //    itemv1.GoldCost = "625,000 gp";
        //    itemv1.Level = "Lvl 4";
        //    ItemVersion itemv2 = item.NewItemVersion();
        //    itemv2.Bonus = "+2";
        //    itemv2.GoldCost = "1,325,000 gp";
        //    itemv2.Level = "Lvl 10";
        //    ItemVersion itemv3 = item.NewItemVersion();
        //    itemv3.Bonus = "+2";
        //    itemv3.GoldCost = "1,325,000 gp";
        //    itemv3.Level = "Lvl 10";
        //    Element e = item.NewElement();
        //    e.Indent = Indentation.Primary;
        //    e.Shading = Appearance.Shaded;
        //    e.Text = "BLAH!";
        //    e.Type = "Power";

        //    return item;
        //}

        private IHTMLWriteable healers_crystal()
        {
            Item item = new Item();
            item.LevelText = "Level 2+";
            item.Name = "Healer's Crystal";
            item.FlavourText = "An ordinary looking blue crystal that hangs from a simple rope that holds within it the power to keep your party going long after they have exhausted thier healing resources.";
            ItemVersion itemv1 = item.NewItemVersion();
            itemv1.Bonus = "+1";
            itemv1.GoldCost = "520 gp";
            itemv1.Level = "Lvl 2";
            Element e = item.NewElement();
            e.Indent = Indentation.Primary;
            e.Shading = Appearance.Not_Shaded;
            e.Text = "Neck";
            e.Type = "Item Slot";
            Element e6 = item.NewElement();
            e6.Indent = Indentation.Primary;
            e6.Shading = Appearance.Not_Shaded;
            e6.Text = "All Knowledge Based Skills";
            e6.Type = "Enhancement";
            Element e2 = item.NewElement();
            e2.Indent = Indentation.Primary;
            e2.Shading = Appearance.Not_Shaded;
            e2.Text = "This crystal can have no more than 3 charges at one time and resets to 1 charge after an extended rest.";
            e2.Type = "Property";
            Element e3 = item.NewElement();
            e3.Indent = Indentation.Tertiary;
            e3.Shading = Appearance.Not_Shaded;
            e3.Text = "This item is cursed and cannot be removed.";
            e3.Type = "Curse";
            Element e4 = item.NewElement();
            e4.Indent = Indentation.Primary;
            e4.Shading = Appearance.Shaded;
            e4.Text = "Standard Action. You or an adjacent ally expends a healing surge but does not regain hit points as normal, add 1 charge to this crystal.";
            e4.Type = "Power (At-Will)";
            Element e5 = item.NewElement();
            e5.Indent = Indentation.Primary;
            e5.Shading = Appearance.Shaded;
            e5.Text = "Immediate Reaction. Use this power when an ally within 5 squares of you takes damage. Expend 1 charge from the crystal. The ally regains hit points as though he or she had spent a healing surge, and regains an extra 1d6 hit points.";
            e5.Type = "Power (Encounter ♦ Healing)";

            return item;
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            BrowserWindow w = new BrowserWindow();
            CardBrowser c = w.cardBrowser1;
            List<IHTMLWriteable> list = new List<IHTMLWriteable>();
            foreach (object o in cardListBox.CheckedItems)
            {
                IHTMLWriteable t = o as IHTMLWriteable;
                list.Add(t);
            }
            c.AddCardList(list);
            w.Visible = true;
        }

        public void RefreshCardList()
        {
            this.cardListBox.Refresh();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            containerPanel.Controls.Clear();
            cardListBox.Items.Remove(cardListBox.SelectedItem);
        }

        private void cardListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            containerPanel.Controls.Clear();

            object o = cardListBox.SelectedItem;
            if (o == null) return;
            Control c;
            if (o.GetType().Equals(typeof(AtWill)))
            {
                Power p = o as AtWill;
                c = new PowerCtrl(CardTypes.AtWill, p);
                this.containerPanel.Controls.Add(c);
                c.Visible = true;

            }
            else if (o.GetType().Equals(typeof(Encounter)))
            {
                Power p = o as Encounter;
                c = new PowerCtrl(CardTypes.Encounter, p);
                this.containerPanel.Controls.Add(c);
                c.Visible = true;
            }
            else if (o.GetType().Equals(typeof(Daily)))
            {
                Power p = o as Daily;
                c = new PowerCtrl(CardTypes.Daily, p);
                this.containerPanel.Controls.Add(c);
                c.Visible = true;
            }
            else if (o.GetType().Equals(typeof(Item)))
            {
                Item i = o as Item;
                c = new ItemCtrl(i);
                this.containerPanel.Controls.Add(c);
                c.Visible = true;
            }
            else if (o.GetType().Equals(typeof(Monster)))
            {
                Monster m = o as Monster;
                c = new MonsterCtrl(m);
                this.containerPanel.Controls.Add(c);
                c.Visible = true;
            }
            else if (o.GetType().Equals(typeof(Class)))
            {
                Class cl = o as Class;
                c = new ClassCtrl(cl);
                this.containerPanel.Controls.Add(c);
                c.Visible = true;
            }
        }

        private void atWillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AtWill p = new AtWill();
            cardListBox.Items.Add(p);
            cardListBox.SelectedItem = p;
        }

        private void encounterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Encounter p = new Encounter();
            cardListBox.Items.Add(p);
            cardListBox.SelectedItem = p;
        }

        private void dailyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Daily p = new Daily();
            cardListBox.Items.Add(p);
            cardListBox.SelectedItem = p;
        }

        private void monsterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Monster p = new Monster();
            cardListBox.Items.Add(p);
            cardListBox.SelectedItem = p;
        }

        private void classToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class p = new Class();
            cardListBox.Items.Add(p);
            cardListBox.SelectedItem = p;
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Item p = new Item();
            cardListBox.Items.Add(p);
            cardListBox.SelectedItem = p;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CardMarker File *.card | *.card";
            DialogResult r = openFileDialog1.ShowDialog();
            filename = openFileDialog1.FileName;
            IFormatter formatter = new BinaryFormatter();
            System.IO.Stream stream;
            IHTMLWriteable obj = (IHTMLWriteable)formatter.Deserialize(stream = openFileDialog1.OpenFile());
            cardListBox.Items.Add(obj);
            stream.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename.Equals(""))
            {
                saveFileDialog1.Filter = "CardMarker File *.card | *.card";
                saveFileDialog1.Title = "Saving " + cardListBox.SelectedItem.ToString();
                DialogResult r = saveFileDialog1.ShowDialog();
                filename = saveFileDialog1.FileName;
            }
            IFormatter formatter = new BinaryFormatter();
            System.IO.Stream stream;
            formatter.Serialize(stream = saveFileDialog1.OpenFile(), cardListBox.SelectedItem);
            stream.Close();
        }

        private void CardMakerWindow_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 5000, AnimateWindowFlags.AW_ACTIVATE | AnimateWindowFlags.AW_SLIDE | AnimateWindowFlags.AW_HOR_POSITIVE);
        }
    }
}
