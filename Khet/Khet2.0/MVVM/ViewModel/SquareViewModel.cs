using Stylet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet2._0.MVVM.ViewModel
{
    public class SquareViewModel : Screen
    {
        public void ExecuteMouseDown()
        {
            Trace.WriteLine("SquareClicked!");
        }
    }
}
