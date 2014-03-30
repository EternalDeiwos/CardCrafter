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
    public partial class MinionPowerCtrl : UserControl
    {
        MinionPower power;
        public MinionPowerCtrl(MinionPower power)
        {
            InitializeComponent();
            this.power = power;
            LoadData();
        }

        public void LoadData()
        {
            nameText.Text = power.Name;
            keywordsText.Text = power.Keywords;
            descText.Text = power.Description;
            actionComboBox.SelectedItem = power.Action;
            rechargeComboBox.SelectedItem = power.Usage;
        }

        public MinionPower GetData()
        {
            power.Name = nameText.Text;
            power.Keywords = keywordsText.Text;
            power.Description = descText.Text;
            
            ActionType action;
            Enum.TryParse<ActionType>(actionComboBox.SelectedItem.ToString(), out action);
            power.Action = action;

            SpellUsage usage;
            Enum.TryParse<SpellUsage>(rechargeComboBox.SelectedItem.ToString(), out usage);
            power.Usage = usage;

            return power;
        }
    }
}
