using Khet2._0.CustomTypes;
using Khet2._0.Enums;
using Khet2._0.Events;
using Khet2._0.MVVM.ViewModel;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Khet2._0.MVVM.Models
{
    public class LaserModel : IHandle<LaserFireEvent>
    {
        private readonly Idx StartP1 = new Idx { row = 7, column = 9 };
        private readonly Idx StartP2 = new Idx { row = 0, column = 0 };

        private readonly Direction directionP1 = Direction.Up;
        private readonly Direction directionP2 = Direction.Down;

        private Idx Start;
        private Direction direction;

        private MyGrid _grid;
        public LaserModel(EventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);
        }

        public void SetGrid(MyGrid grid)
        {
            _grid = grid;
        }

        public void Handle(LaserFireEvent e)
        {
            if (e.player == 1)
            {
                Start = StartP1;
                direction = directionP1;
            }
            else if (e.player == 2)
            {
                Start = StartP2;
                direction = directionP2;
            }

            ResolveLaser(Start, direction);
        }

        public async void ResolveLaser(Idx idx, Direction outDirection)
        {
            var row = idx.row;
            var col = idx.column;
            Direction inDirection;


            while (InBounds(row, col))
            {
                (inDirection, outDirection) = ResolveSquare(_grid[row][col], outDirection);

                if (outDirection == Direction.Stop)
                {
                    // DeletePiece and exit loop
                    _grid[row][col].ActivePiece = null;
                    break;
                }

                _grid[row][col].ActiveLaser.FillLaser(inDirection);
                _grid[row][col].ActiveLaser.FillLaser(outDirection);

                await Task.Delay(150);
                _grid[row][col].ActiveLaser.ClearLaser(); // Example method; implement accordingly

                switch (outDirection)
                {
                    case Direction.Up:
                        row--;
                        break;
                    case Direction.Down:
                        row++;
                        break;
                    case Direction.Left:
                        col--;
                        break;
                    case Direction.Right:
                        col++;
                        break;
                    default:
                        break;
                }
            }


        }


        private (Direction, Direction) ResolveSquare(SquareViewModel square, Direction fireDirection)
        {
            Direction inDirection = Mappings.flip[fireDirection];
            Direction outDirection;

            if (square.ActivePiece == null)
            {
                outDirection = fireDirection;
            }
            else
            {
                switch (square.ActivePiece)
                {
                    case DjedViewModel Djed:
                        outDirection = Mappings.Djed[(inDirection, Djed.orientation)];
                        break;
                    case PyramidViewModel Pyramid:
                        outDirection = Mappings.Pyramid[(inDirection, Pyramid.orientation)];
                        break;
                    case PharaohViewModel:
                        outDirection = Direction.Stop;
                        break;
                    case ObeliskViewModel:
                        outDirection = Direction.Stop;
                        break;
                    default:
                        outDirection = Direction.Stop;
                        break;
                }
            }
            return (inDirection, outDirection);
        }

        private bool InBounds(int row, int col)
        {
            if (row >= 0 && row <= 7)
            {
                if (col >= 0 && col <= 9)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
