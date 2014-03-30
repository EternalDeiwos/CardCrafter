using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CardMaker
{
    [Serializable]
    public class Item : IHTMLWriteable
    {
        protected static string HTML_TEMLPLATE =
    @"<div style=""font-family:arial;font-size:8pt;width:350px;line-height:10.5pt;"">
		<div style=""background-color:#EFC404;color:#FFFFFF;padding:1px 5px 0px 5px;width:340px;height:16px;"">
			<div style=""font-weight:bold;float:left;"">@Name</div>
			<div style=""float:right;"">@LevelText</div>
		</div>
		<div style=""background-color:#DDDDCC;background-image:url('http://omnichron.net/external/op/src/bg_350.jpg');font-style:italic;padding: 1px 0px 3px 5px;"">@FlavourText</div>
		<div style=""padding-left:5px;"">
			@ItemVersions
		</div>
		@Elements
		<br />
	</div>";

        public string Name { get; set; }
        public string LevelText { get; set; }
        public string FlavourText { get; set; }
        public List<ItemVersion> ItemVersions;
        public List<Element> Elements;

        public Item()
        {
            Name = "New Item";
            ItemVersions = new List<ItemVersion>();
            Elements = new List<Element>();
        }

        public Element NewElement()
        {
            Element temp = new Element();
            Elements.Add(temp);
            return temp;
        }

        public ItemVersion NewItemVersion()
        {
            ItemVersion temp = new ItemVersion();
            ItemVersions.Add(temp);
            return temp;
        }

        public string ToHTML()
        {
            StringBuilder builder = new StringBuilder(HTML_TEMLPLATE);
            // Replace Name
            builder.Replace("@Name", Name);

            // Replace Level Text
            builder.Replace("@LevelText", LevelText);

            // Replace Flavour Text
            builder.Replace("@FlavourText", FlavourText);

            // Replace Item Versions
            StringBuilder item_vBuilder = new StringBuilder();
            bool flag = false;
            foreach (ItemVersion s in ItemVersions)
            {
                item_vBuilder.Append(s.ToHTML());
                if (flag)
                {
                    item_vBuilder.Append(@"<br>");
                }
                flag = !flag;
            }
            builder.Replace("@ItemVersions", item_vBuilder.ToString());

            // Replace Elements
            StringBuilder elementsBuilder = new StringBuilder();

            foreach (Element e in Elements)
            {
                elementsBuilder.Append(e.ToHTML()).Append('\n');
            }
            builder.Replace("@Elements", elementsBuilder.ToString());
            return builder.ToString();
        }

        public override string ToString()
        {
            return Name;
        }
    }

    [Serializable]
    public class ItemVersion : IHTMLWriteable
    {

        private static string ITEM_VERSION = @"<span style=""padding:1px 5px 0px 5px;width:40px;"">@Level</span>
        <span style=""padding:1px 5px 0px 5px;width:20px;"">@Bonus</span>
        <span style=""padding:1px 5px 0px 5px;text-align:right;width:100px;padding-right:25px"">@Gold</span>";

        public string Level { get; set; }
        public string Bonus { get; set; }
        public string GoldCost { get; set; }

        public string ToHTML()
        {
            StringBuilder builder = new StringBuilder(ITEM_VERSION);

            builder.Replace("@Level", Level);
            builder.Replace("@Bonus", Bonus);
            builder.Replace("@Gold", GoldCost);

            return builder.ToString();
        }

        public override string ToString()
        {
            return Level;
        }
    }
}
