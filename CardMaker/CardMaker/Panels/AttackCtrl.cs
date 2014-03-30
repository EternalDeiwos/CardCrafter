using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CardMaker.ClassStuff;

namespace CardMaker
{
    public partial class AttackCtrl : UserControl
    {
        Attack attack;
        public AttackCtrl(Attack attack)
        {
            InitializeComponent();
            this.attack = attack;
            LoadData();
        }

        public void LoadData()
        {
            nameText.Text = attack.Name;
            bonusText.Text = attack.AttackBonus.ToString();
            damageText.Text = attack.Damage;
            targetDefType.SelectedIndex = (int)attack.TargetDefence;
        }

        public Attack GetData()
        {
            attack.Name = nameText.Text;
            attack.AttackBonus = Convert.ToInt32(bonusText.Text);
            attack.Damage = damageText.Text;
            Defences target;
            Enum.TryParse<Defences>(targetDefType.SelectedItem.ToString(), out target);
            attack.TargetDefence = target;
            return attack;
        }
    }
}
