using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CardMaker
{
    public partial class ItemCtrl : UserControl
    {
        Item item;
        public ItemCtrl(Item i)
        {
            InitializeComponent();
            item = i;
            LoadData();
        }

        public ItemCtrl(out Item i)
        {
            InitializeComponent();
            i = new Item();
            item = i;
        }

        public void LoadData()
        {
            nameText.Text = item.Name;
            levelText.Text = item.LevelText;
            flavourText.Text = item.FlavourText;
            LoadItemVersions();
            LoadElements();
        }

        private void LoadItemVersions()
        {
            itemVersionTabCtrl.TabPages.Clear();
            foreach (ItemVersion v in item.ItemVersions)
            {
                TabPage ctrl = new TabPage();
                ItemVersionCtrl v_ctrl = new ItemVersionCtrl(v, ctrl);
                ctrl.Controls.Add(v_ctrl);
                itemVersionTabCtrl.TabPages.Add(ctrl);
            }
        }

        private void LoadElements()
        {
            elementTabCtrl.TabPages.Clear();
            foreach (Element e in item.Elements)
            {
                TabPage ctrl = new TabPage();
                ElementCtrl e_ctrl = new ElementCtrl(e, ctrl);
                ctrl.Controls.Add(e_ctrl);
                elementTabCtrl.TabPages.Add(ctrl);
            }
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public Item GetItem()
        {
            return item;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Element element = item.NewElement();
            TabPage ctrl = new TabPage();
            ctrl.Controls.Add(new ElementCtrl(element,ctrl));
            elementTabCtrl.TabPages.Add(ctrl);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            TabPage tab = elementTabCtrl.SelectedTab;
            Element element = (tab.Controls[0] as ElementCtrl).getElement();
            item.Elements.Remove(element);
            elementTabCtrl.TabPages.Remove(tab);
            LoadElements();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            item.Name = nameText.Text;
            item.LevelText = levelText.Text;
            item.FlavourText = flavourText.Text;

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

            foreach (TabPage p in itemVersionTabCtrl.TabPages)
            {
                ItemVersionCtrl ctrl = p.Controls[0] as ItemVersionCtrl;
                ItemVersion in_page = ctrl.GetItemVersion();

                in_page.Bonus = ctrl.bonusText.Text;
                in_page.GoldCost = ctrl.priceText.Text;
                in_page.Level = ctrl.levelText.Text;
            }
            LoadElements();
            LoadItemVersions();
        }

        private void addVersionButton_Click(object sender, EventArgs e)
        {
            ItemVersion itemversion = item.NewItemVersion();
            TabPage ctrl = new TabPage();
            ctrl.Controls.Add(new ItemVersionCtrl(itemversion,ctrl));
            itemVersionTabCtrl.TabPages.Add(ctrl);
        }

        private void removeVersionButton_Click(object sender, EventArgs e)
        {
            TabPage tab = itemVersionTabCtrl.SelectedTab;
            ItemVersion itemversion = (tab.Controls[0] as ItemVersionCtrl).GetItemVersion();
            item.ItemVersions.Remove(itemversion);
            elementTabCtrl.TabPages.Remove(tab);
            LoadItemVersions();
        }
    }
}
