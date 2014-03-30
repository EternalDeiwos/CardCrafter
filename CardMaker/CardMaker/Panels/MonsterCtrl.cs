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
    public partial class MonsterCtrl : UserControl
    {
        Monster monster;
        public MonsterCtrl(Monster m)
        {
            InitializeComponent();
            monster = m;
        }
    }
}
