using Khet3.Enums;
using KhetV3.Enums;
using KhetV3.Interfaces;
using KhetV3.MVVM.Models;
using KhetV3.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Threading.Tasks;

namespace KhetV3.Services
{
    public class FireLaserService
    {
        private BoardUpdateService _boardUpdater;
        private Dictionary<(int row, int col), IPiece> pieceState;

        public FireLaserService(BoardUpdateService boardUpdater)
        {
            _boardUpdater = boardUpdater;
        }

        public async void CalculateLaserPath((int row, int col) startingPosition, Direction firingDirection)
        {
            Trace.WriteLine("FireLaserService: CalculateLaserPath");

            pieceState = _boardUpdater._pieceDictionary;

            var position = startingPosition;
            var outDirection = firingDirection;
            LaserResponse laserResponse = null;

            while (_boardUpdater.InBounds(position) && outDirection != Direction.Stop)
            {
                if (!pieceState.ContainsKey(position))
                {
                    laserResponse = DefaultLaser(outDirection);
                }
                else
                {
                    laserResponse = PieceLaser(outDirection, pieceState[position]);
                }

                outDirection = laserResponse.direction;


                await _boardUpdater.DisplayLaser(position, laserResponse.LaserPositions);

                position = MoveToNextSquare(position, outDirection);
            }

            Trace.WriteLine("out of loop");

        }

        private LaserResponse PieceLaser(Direction firingDirection, IPiece piece)
        {

            var inDirection = DirectionMappings.flip[firingDirection];
            var outDirection = Direction.Stop;
            var laserPosition = (LaserPosition.None, LaserPosition.None);

            if (piece is IRotatable rotatablePiece)
            {
                outDirection = piece switch
                {
                    DjedViewModel => LaserReflection.Djed[(inDirection, rotatablePiece.orientation)],
                    PyramidViewModel => LaserReflection.Pyramid[(inDirection, rotatablePiece.orientation)],
                    _ => Direction.Stop
                };

                laserPosition = (DirectionMappings.ToLaserPosition[inDirection], DirectionMappings.ToLaserPosition[outDirection]);
            }
            else
            {
                laserPosition = (DirectionMappings.ToLaserPosition[inDirection], DirectionMappings.ToLaserPosition[outDirection]);
            }

            Trace.WriteLine($"Hit Piece! Laser Positions {laserPosition}, out direction {firingDirection}");

            return new LaserResponse(laserPosition, outDirection);

        }

        private LaserResponse DefaultLaser(Direction firingDirection)
        {
            (LaserPosition p1, LaserPosition p2) laserPosition = firingDirection switch
            {
                Direction.Up => (LaserPosition.Bottom, LaserPosition.Top),
                Direction.Down => (LaserPosition.Top, LaserPosition.Bottom),
                Direction.Left => (LaserPosition.Right, LaserPosition.Left),
                Direction.Right => (LaserPosition.Left, LaserPosition.Right),
                _ => throw new InvalidOperationException()
            };

            Trace.WriteLine($"FireLaserService.DefaultLaser: Laser Positions {laserPosition}, out direction {firingDirection}");


            return new LaserResponse(laserPosition, firingDirection);
        }

        private (int row, int col) MoveToNextSquare((int row, int col) position, Direction outDirection)
        {
            int rowStep = 0;
            int colStep = 0;

            switch (outDirection)
            {
                case Direction.Up:
                    rowStep--;
                    break;
                case Direction.Down:
                    rowStep++;
                    break;
                case Direction.Left:
                    colStep--;
                    break;
                case Direction.Right:
                    colStep++;
                    break;
                case Direction.Stop:
                    break;
                default:
                    break;
            }

            position = (position.row + rowStep, position.col + colStep);

            return position;
        }
    }
}