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
    public partial class AuraCtrl : UserControl
    {
        Aura aura;
        public AuraCtrl(Aura aura)
        {
            InitializeComponent();
            this.aura = aura;
            LoadData();
        }

        public void LoadData()
        {
            nameText.Text = aura.Name;
            descText.Text = aura.Description;
            radiusText.Text = aura.Radius.ToString();
            typeText.Text = aura.Type;
        }

        public Aura GetData()
        {
            aura.Name = nameText.Text;
            aura.Description = descText.Text;
            aura.Radius = Convert.ToInt32(radiusText.Text);
            aura.Type = typeText.Text;

            return aura;
        }
    }
}
