using Khet3.Enums;
using KhetV3.Enums;
using KhetV3.Events;
using KhetV3.Interfaces;
using KhetV3.MVVM.Models;
using KhetV3.MVVM.ViewModels;
using Stylet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Threading.Tasks;

namespace KhetV3.Services
{
    public class FireLaserService
    {
        private EventAggregator _EventAggregator;
        private BoardUpdateService _boardUpdater;
        private Dictionary<(int row, int col), IPiece> pieceState;
        private int rows;
        private int cols;

        public FireLaserService(EventAggregator eventAggregator, BoardUpdateService boardUpdater)
        {
            _EventAggregator = eventAggregator;
            _boardUpdater = boardUpdater;
        }

        public void SetBoardDimensions(int row, int col)
        {
            this.rows = row;
            this.cols = col;
        }

        public async Task CalculateLaserPath((int row, int col) startingPosition, Direction firingDirection)
        {
            Trace.WriteLine("FireLaserService: CalculateLaserPath");

            _EventAggregator.Publish(new LaserFiredEvent());

            var position = startingPosition;
            var outDirection = firingDirection;
            LaserResponse laserResponse = null;
            pieceState = _boardUpdater.GetPieceInfo();


            foreach (var piece in pieceState)
            {
                Trace.WriteLine($"{piece}");
            }

            while (InBounds(position))
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

                if (outDirection == Direction.Stop)
                {
                    _boardUpdater.PieceHit(position);
                    break;
                }

                await _boardUpdater.DisplayLaser(position, laserResponse.LaserPositions);

                position = MoveToNextSquare(position, outDirection);
            }

            Trace.WriteLine("out of loop");

        }

        private bool InBounds((int row, int col) position)
        {
            if (position.row < this.rows && position.col < this.cols && position.row >= 0 && position.col >= 0)
            {
                return true;
            }

            return false;
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