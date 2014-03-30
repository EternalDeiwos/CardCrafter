using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardMaker
{
    [Serializable]
    public class AtWill : Power
    {
        public AtWill()
        {
            Name = "New At-Will Spell";
            Usage = SpellUsage.AtWill;
        }
    }
}
