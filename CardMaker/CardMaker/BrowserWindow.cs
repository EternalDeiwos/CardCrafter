using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CardMaker
{
    public partial class BrowserWindow : Form
    {
        string filepath;

        public BrowserWindow()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "HTML Files (*.html)|*.html|All Files (*.*)|*.*";
            if (filepath == null)
            {
                saveFileDialog.ShowDialog();
                filepath = saveFileDialog.FileName;
            }
            save(filepath);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "HTML Files (*.html)|*.html|All Files (*.*)|*.*";
            openFileDialog.ShowDialog();
            filepath = openFileDialog.FileName;
            open(filepath);
        }

        private void save(string filepath)
        {
            using (FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                try
                {
                    byte[] bytes = ASCIIEncoding.ASCII.GetBytes(cardBrowser1.DocumentText);
                    fs.Write(bytes, 0, bytes.Length);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void open(string filepath)
        {
            string ret = null;
            using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    byte[] bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                    ret = ASCIIEncoding.ASCII.GetString(bytes);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            cardBrowser1.DocumentText = ret;
        }
    }
}
