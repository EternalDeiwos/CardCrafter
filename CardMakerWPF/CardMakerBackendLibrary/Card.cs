using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.StringTemplate;

namespace CardMakerBackend
{
    [Serializable]
    class Card
    {
        public Card()
        {
        }

        public virtual string ToHTML()
        {
            //Template t = new Template("");

            return "";
        }
    }
}
