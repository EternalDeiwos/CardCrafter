using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardMaker
{
    public interface IReturnsData<T>
    {
        T GetData();
    }
}
