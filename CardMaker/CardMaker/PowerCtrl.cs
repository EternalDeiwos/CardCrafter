using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace CardMaker
{
    public partial class PowerCtrl : UserControl
    {
        Power power;
        CardTypes type;
        public PowerCtrl(CardTypes type, out Power t)
        {
            InitializeComponent();
            this.type = type;
            switch (type)
            {
                case CardTypes.AtWill:
                    power = new AtWill();
                    break;
                case CardTypes.Encounter:
                    power = new Encounter();
                    break;
                case CardTypes.Daily:
                    power = new Daily();
                    break;
                default:
                    throw new InvalidOperationException("Unsupported CardType");
            }
            t = power;
        }

        public PowerCtrl(CardTypes type, Power p)
        {
            InitializeComponent();
            power = p;
            this.type = type;

            LoadData();
        }

        public void LoadData()
        {
            nameText.Text = power.Name;
            levelText.Text = power.LevelText;
            flavourText.Text = power.FlavourText;
            usageText.Text = power.GetUsage().ToString();
            actionType.SelectedIndex = (int)power.Action;
            attackType.SelectedIndex = (int)power.Attack;
            rangeText.Text = power.Range;
            foreach (string s in power.Keywords)
            {
                if (String.IsNullOrWhiteSpace(keywordsText.Text)) keywordsText.Text += s;
                else keywordsText.Text += ", " + s;
            }

            LoadElements();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            power.Name = nameText.Text;
            power.LevelText = levelText.Text;
            
            ActionType action;
            Enum.TryParse<ActionType>(actionType.SelectedItem.ToString(), out action);
            power.Action = action;

            AttackType attack;
            Enum.TryParse<AttackType>(attackType.SelectedItem.ToString(), out attack);
            power.Attack = attack;

            power.FlavourText = flavourText.Text;
            power.Range = rangeText.Text;

            power.Keywords.Clear();
            string[] arr = (this.keywordsText.Text as string).Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in arr)
            {
                power.Keywords.Add(s);
            }

            power.Range = rangeText.Text;
            foreach (TabPage p in elementTabCtrl.TabPages)
            {
                //MessageBox.Show((p.Controls[0] as ElementCtrl).getElement().Type);
                ElementCtrl ctrl = p.Controls[0] as ElementCtrl;
                Element in_page = ctrl.getElement();
                
                Appearance shading;
                Enum.TryParse<Appearance>(ctrl.appearanceType.SelectedItem.ToString(), out shading);
                in_page.Shading = shading;

                Indentation indent;
                Enum.TryParse<Indentation>(ctrl.indentType.SelectedItem.ToString(), out indent);
                in_page.Indent = indent;

                in_page.Type = ctrl.nameText.Text;
                in_page.Text = ctrl.descText.Text;
            }
            LoadElements();
            (this.ParentForm as CardMakerWindow).RefreshCardList();
        }

        private void LoadElements()
        {
            elementTabCtrl.TabPages.Clear();
            foreach (Element e in power.Elements)
            {
                TabPage ctrl = new TabPage();
                ElementCtrl e_ctrl = new ElementCtrl(e, ctrl);
                ctrl.Controls.Add(e_ctrl);
                elementTabCtrl.TabPages.Add(ctrl);
            }
        }

        public Power GetPower()
        {
            return power;
        }

        public CardTypes GetCardType()
        {
            return type;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Element element = power.NewElement();
            TabPage ctrl = new TabPage();
            ctrl.Controls.Add(new ElementCtrl(ctrl));
            elementTabCtrl.TabPages.Add(ctrl);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            TabPage tab = elementTabCtrl.SelectedTab;
            Element element = (tab.Controls[0] as ElementCtrl).getElement();
            power.Elements.Remove(element);
            elementTabCtrl.TabPages.Remove(tab);
        }
    }
}
