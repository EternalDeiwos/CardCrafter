﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardMaker
{
    [Serializable]
    class Encounter : Power
    {
        public Encounter()
        {
            Name = "New Encounter Spell";
            Usage = SpellUsage.Encounter;
        }
    }
}
