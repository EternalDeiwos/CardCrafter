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
    public partial class ItemVersionCtrl : UserControl
    {
        ItemVersion version;
        public ItemVersionCtrl(ItemVersion v, TabPage p)
        {
            InitializeComponent();
            Parent = p;
            version = v;
            LoadData();
        }

        public ItemVersionCtrl(TabPage p)
        {
            InitializeComponent();
            Parent = p;
            version = new ItemVersion();
            version.Level = "New ItemVersion";
        }

        public void LoadData()
        {
            (Parent as TabPage).Text = version.Level;
            levelText.Text = version.Level;
            bonusText.Text = version.Bonus;
            priceText.Text = version.GoldCost;
        }

        public ItemVersion GetItemVersion()
        {
            WriteData();
            return version;
        }

        public void WriteData()
        {
            version.Level = levelText.Text;
            version.Bonus = bonusText.Text;
            version.GoldCost = priceText.Text;
        }
    }
}
