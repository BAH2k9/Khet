using Khet.Wpf.Enums;
using Khet.Wpf.ViewModels;
using Khet.Wpf.Models;
using System.Windows.Controls;

namespace Khet.Wpf.Tests
{
    public static class PieceTest
    {

        public static async Task AllOrientations(GridModel squareViewModels)
        {
            await Orientation(squareViewModels, Pyramid.tl);
            await Orientation(squareViewModels, Pyramid.tr);
            await Orientation(squareViewModels, Pyramid.bl);
            await Orientation(squareViewModels, Pyramid.br);
        }

        public static async Task Orientation(GridModel squareViewModels, Pyramid orientation)
        {
            int longd = 1200;
            int shortd = 400;
            // Set piece
            squareViewModels[4][4].activePiece = new PyramidViewModel(orientation);

            await Task.Delay(longd);

            // Fire laser 
            BoardViewModel.FireLaser(squareViewModels, 0, 4, Direction.down);
            await Task.Delay(longd);
            GridModel.ClearLaser(squareViewModels);

            // Set new piece
            squareViewModels[4][4].activePiece = new PyramidViewModel(orientation);
            await Task.Delay(shortd);

            // Fire Laser
            BoardViewModel.FireLaser(squareViewModels, 4, 0, Direction.right);
            await Task.Delay(longd);
            GridModel.ClearLaser(squareViewModels);

            squareViewModels[4][4].activePiece = new PyramidViewModel(orientation);
            await Task.Delay(shortd);

            BoardViewModel.FireLaser(squareViewModels, 7, 4, Direction.up);
            await Task.Delay(longd);
            GridModel.ClearLaser(squareViewModels);

            squareViewModels[4][4].activePiece = new PyramidViewModel(orientation);
            await Task.Delay(shortd);

            BoardViewModel.FireLaser(squareViewModels, 4, 9, Direction.left);
            await Task.Delay(longd);
            GridModel.ClearLaser(squareViewModels);

        }

        
    }
}
