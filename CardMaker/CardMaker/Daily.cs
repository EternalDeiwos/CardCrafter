using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardMaker
{
    [Serializable]
    class Daily : Power
    {
        public Daily()
        {
            Name = "New Daily Spell";
            Usage = SpellUsage.Daily;
        }
    }
}
