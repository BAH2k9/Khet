using Khet.Wpf.Enums;
using Khet.Wpf.ViewModels;
using Khet.Wpf.Models;
using System.Windows.Controls;

namespace Khet.Wpf.Tests
{
    public static class DjedTest
    {

        public static async Task AllOrientations(GridModel squareViewModels)
        {
            await Orientation(squareViewModels, Djed.dl);
            await Orientation(squareViewModels, Djed.dr);

        }

        public static async Task Orientation(GridModel squareViewModels, Djed orientation)
        {
            int longd = 1200;
            int shortd = 400;
            // Set piece
            squareViewModels[4][4].activePiece = new DjedViewModel(orientation);

            await Task.Delay(longd);

            // Fire laser 
            MainViewModel.FireLaser(squareViewModels, 0, 4, Direction.down);
            await Task.Delay(longd);
            GridModel.ClearLaser(squareViewModels);

            // Set new piece
            squareViewModels[4][4].activePiece = new DjedViewModel(orientation);
            await Task.Delay(shortd);

            // Fire Laser
            MainViewModel.FireLaser(squareViewModels, 4, 0, Direction.right);
            await Task.Delay(longd);
            GridModel.ClearLaser(squareViewModels);

            squareViewModels[4][4].activePiece = new DjedViewModel(orientation);
            await Task.Delay(shortd);

            MainViewModel.FireLaser(squareViewModels, 7, 4, Direction.up);
            await Task.Delay(longd);
            GridModel.ClearLaser(squareViewModels);

            squareViewModels[4][4].activePiece = new DjedViewModel(orientation);
            await Task.Delay(shortd);

            MainViewModel.FireLaser(squareViewModels, 4, 9, Direction.left);
            await Task.Delay(longd);
            GridModel.ClearLaser(squareViewModels);

        }



        
    }
}
