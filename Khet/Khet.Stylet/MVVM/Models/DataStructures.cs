using Khet.Stylet.MVVM.ViewModels;
using Stylet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet.Stylet.MVVM.Models
{
    public class GridModel : BindableCollection<BindableCollection<SquareViewModel>> { }
    public class Position
    {
        public int i;
        public int j;
    }


}
