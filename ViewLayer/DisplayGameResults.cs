using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewLayer.Interfaces;
using ViewLayer.Constants;
using BusinessLogic.Models;
using ViewModels;

namespace ViewLayer
{
    class DisplayGameResults
    { 
        private IOutput _output;

        public DisplayGameResults(IOutput output)
        {
            _output = output;         
        }

        public void FinishResult(List<GamerView> afterGameArray)
        {
            _output.ShowFinishResult(afterGameArray);           
        }
    }
}
