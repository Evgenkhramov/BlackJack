using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewLayer.Interfaces
{
    public interface IInput
    {
        string InputString();

        int InputInt(int min, int max);
    }
}
