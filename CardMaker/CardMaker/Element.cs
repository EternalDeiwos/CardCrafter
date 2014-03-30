using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardMaker
{
    [Serializable]
    public enum Appearance
    {
        Shaded, Not_Shaded
    }

    [Serializable]
    public enum Indentation
    {
        Primary, Secondary, Tertiary
    }

    [Serializable]
    public class Element : IHTMLWriteable
    {
        public static string HTML_ELEMENT_TEMPLATE =
        @"<div style=""padding:0px 0px 0px @Indentation;background-image:@Appearance;"">
			<span style=""font-weight:bold;"">@Type</span>
			@Text
		</div>";

        public static string SHADED = @"url('http://omnichron.net/external/op/src/bg_350.jpg')";
        public static string NOT_SHADED = "none";
        public static string PRIMARY_INDENT = "5px";
        public static string SECONDARY_INDENT = "15px";
        public static string TERTIARY_INDENT = "25px";

        public string Type { get; set; }
        public string Text { get; set; }
        public Appearance Shading { get; set; }
        public Indentation Indent { get; set; }

        public string ToHTML()
        {
            StringBuilder builder = new StringBuilder(HTML_ELEMENT_TEMPLATE);

            // Replace Intendation
            switch (Indent)
            {
                case Indentation.Secondary:
                    builder.Replace("@Indentation", SECONDARY_INDENT);
                    break;
                case Indentation.Tertiary:
                    builder.Replace("@Indentation", TERTIARY_INDENT);
                    break;
                default:
                    builder.Replace("@Indentation", PRIMARY_INDENT);
                    break;
            }

            // Replace Appearance
            if (Shading.Equals(Appearance.Shaded)) builder.Replace("@Appearance", SHADED);
            else builder.Replace("@Appearance", NOT_SHADED);

            // Replace Type
            if (Type.Equals("")) builder.Replace("@Type", Type);
            else builder.Replace("@Type", Type + ": ");

            // Replace Text
            builder.Replace("@Text", Text);

            return builder.ToString();
        }

        override public string ToString()
        {
            return Type + ": " + Text;
        }
    }
}
