using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Numerics;
using System.Collections.ObjectModel;
using Khet.Wpf.AbstractClasses;
using Khet.Wpf.Models;

namespace Khet.Wpf.ViewModels
{
    public class PyramidViewModel :  Piece
    {

        public new Brush playerColor
        {
            get => base.playerColor;
            set => SetProperty(ref base.playerColor, value);
        }
        private Pyramid _orientation;
        public Pyramid orientation
        {
            get { return _orientation; }
            set { _orientation = value; SetOrientation(); }
        }

        private double _controlWidth;
        public double controlWidth
        {
            get { return _controlWidth; }
            set { _controlWidth = value; SetOrientation(); }
        }

        private double _controlHeight { get; set; }
        public double controlHeight
        {
            get { return _controlHeight; }
            set { _controlHeight = value;  SetOrientation(); }
        }

        private PointCollection _points;
        public PointCollection points { get => _points; set => SetProperty(ref _points, value); }



        public PyramidViewModel(Pyramid orientation, int player = 1)
        {
            this.orientation = orientation;

            SetColor(player);
            SetOrientation();
        }


        private void SetOrientation()
        {
            switch (this.orientation)
            {
                case Pyramid.TL:
                    points = new PointCollection
                    {
                        new Point(0,0),
                        new Point(controlWidth, 0),
                        new Point(0, controlHeight)
                    };
                    break;
                case Pyramid.TR:
                    points = new PointCollection
                    {
                         new Point(0, 0),
                         new Point(controlWidth, 0),
                         new Point(controlWidth, controlHeight)
                    };
                    break;
                case Pyramid.BL:
                    points = new PointCollection
                    {
                         new Point(0, 0),
                         new Point(0, controlHeight),
                         new Point(controlWidth, controlHeight)
                    };
                    break;
                case Pyramid.BR:

                    points = new PointCollection
                    {
                         new Point(controlWidth, 0),
                         new Point(0, controlHeight),
                         new Point(controlWidth, controlHeight)
                    };
                    break;
            }
        }


        public override Direction ResolveLaserDirection(Direction inDirection)
        {

            var input = Tuple.Create(inDirection, this.orientation);
            var outDirection = Mappings.PyramidDirection[input];
            return outDirection;
           
        }

        public override void RotatePiece(Rotate rotation)
        {
            var maxEnumValue = (Pyramid)Enum.GetValues(typeof(Pyramid)).Length-1;
    
            switch (rotation)
            {
                case Rotate.Left:
                    if(orientation == 0)
                    {
                        orientation = maxEnumValue;
                    }
                    else
                    {
                        orientation--;
                    }
                    
                    break;
                case Rotate.Right:
                    if (orientation == maxEnumValue)
                    {
                        orientation = 0;
                    }
                    else
                    {
                        orientation++;
                    }
                    break;

            }
                      
        }
    }
}
