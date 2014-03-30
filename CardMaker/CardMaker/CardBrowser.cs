using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CardMaker
{
    public class CardBrowser : WebBrowser
    {
        private List<string> list;
        int main = 0;
        int side = 0;

        static string HTML_TEMPLATE = @"
        <div class=""main"">
        <!--@Main-->
        </div>

        <div class=""sidebar"">
        <!--@Side-->
        </div>

        <style>
        .main{
            float:left;
	        width:350px;
	        }
        .sidebar{
	        position:absolute;
	        left:370px;
	        width:350px;
	        }
        </style>
        ";

        public CardBrowser()
        {
            list = new List<string>();
            //MessageBox.Show(string.Format("{0}", settings.Margins.Left));   
            
        }

        public void AddCardList(List<IHTMLWriteable> list)
        {
            foreach (IHTMLWriteable e in list)
            {
                string temp = e.ToHTML();
                this.list.Add(temp);
                //MessageBox.Show(temp);
            }
            UpdateCards();
        }

        public void AddCard(IHTMLWriteable i)
        {
            list.Add(i.ToHTML());
        }

        public bool RemoveCard(IHTMLWriteable i)
        {
            return list.Remove(i.ToHTML());
        }

        public void UpdateCards()
        {
            main = 0;
            side = 0;
            StringBuilder builder = new StringBuilder(HTML_TEMPLATE);

            foreach (string s in list)
            {
                if (main <= side)
                {
                    main++;
                    builder.Replace(@"<!--@Main-->", s + @" <!--@Main-->");
                }
                else
                {
                    side++;
                    builder.Replace(@"<!--@Side-->", s + @" <!--@Side-->");
                }
            }
            Navigate("about:blank");
            Document.OpenNew(false);
            Document.Write(builder.ToString());
            Refresh();
        }
    }
}
