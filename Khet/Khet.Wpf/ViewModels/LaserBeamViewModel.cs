using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet.Wpf.ViewModels
{
    class LaserBeamViewModel : ViewModelBase
    {

        private string _height;
        public string height { get => _height; set => SetProperty(ref _height, value); }

        
        private string _width;
        public string width { get => _width; set => SetProperty(ref _width, value); }


        public LaserBeamViewModel(Direction direction)
        {           
            if (direction == Direction.down || direction == Direction.up)
            {
                width = "10";
                height = "auto";

            }

            if (direction == Direction.left || direction == Direction.right)
            {
                width = "auto";
                height = "10";
            }

        }
    }
}
