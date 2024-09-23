using Khet.Stylet.Enums;
using Khet.Stylet.MVVM.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet.Stylet.MVVM.ViewModels
{
    public class LaserBeamViewModel
    {
        private List<Direction> _directions;

        public LaserBeamViewModel(Direction inDirection, IPiece piece = null)
        {
            _directions.Add(inDirection);

            if (piece != null)
            {
                FindLaserDirection(piece.orientation);
            }
            else
            {
                FindLaserDirection();
            }
        }

        public void FindLaserDirection(Orientation pieceOrientation)
        {
            _directions.Add(Direction.Left);
        }
        public void FindLaserDirection()
        {

            Direction outDirection = _directions[0] switch
            {
                Direction.Up => Direction.Down,
                Direction.Down => Direction.Up,
                Direction.Left => Direction.Right,
                Direction.Right => Direction.Left,
                _ => throw new NotImplementedException()

            };

            _directions.Add(Direction.Left);
        }
        public void DisplayLaser()
        {
            setTopLaser();
            setRightLaser();
            setBottomLaser();
        }


        //public static LaserBeamViewModel CreateWithPiece(Direction inDirection)
        //{
        //    return LaserBeamViewModel{ }
        //}

        //public static LaserBeamViewModel CreateWithoutPiece()
        //{

        //}
    }
}
