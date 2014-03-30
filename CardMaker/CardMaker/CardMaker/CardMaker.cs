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

        public CardMaker()
        {
            InitializeComponent();
            MessageBox.Show("");
        }

        public static int getNewID()
        {
            return id++;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }
    }
}
