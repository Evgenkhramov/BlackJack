using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewLayer.Interfaces
{
    public interface INumberValidation
    {
        int CheckNumber(int min, int max, string enterValidNumber, string notValidNumber);
    }
}
