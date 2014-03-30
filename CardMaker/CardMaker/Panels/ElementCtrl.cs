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
    public partial class ElementCtrl : UserControl
    {
        Element element;

        public ElementCtrl(Element e, TabPage tabpage)
        {
            InitializeComponent();
            Parent = tabpage;
            element = e;
            LoadElement();
        }

        public ElementCtrl(TabPage tabpage)
        {
            InitializeComponent();
            element = new Element();
            element.Type = "New Element";
            Parent = tabpage;
            LoadElement();
        }

        public void LoadElement()
        {
            (Parent as TabPage).Text = element.Type;
            nameText.Text = element.Type;
            descText.Text = element.Text;
            indentType.SelectedIndex = (int)element.Indent;
            appearanceType.SelectedIndex = (int)element.Shading;
        }

        public void WriteData()
        {
            
        }

        public Element getElement()
        {
            WriteData();
            return element;
        }

        private void nameText_TextChanged(object sender, EventArgs e)
        {
            (Parent as TabPage).Text = element.Type;
        }
    }
}
