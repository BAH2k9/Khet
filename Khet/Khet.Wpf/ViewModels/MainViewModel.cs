﻿using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Models;
using System.Collections.ObjectModel;

namespace Khet.Wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<SquareViewModel> squareViewModels {get; set;}

        public MainViewModel()
        {
            
            var sf = new SquareFactory();

            squareViewModels = sf.GetObservableCollection();


            // squareViewModels[50].activePiece = new PieceViewModel() { orientation = OrientationDjed.dl };
            //squareViewModels[55].activePiece = new PieceViewModel() { orientation = OrientationDjed.dl };

           // DestroyPyramidTest(Pyramid.bl);
            // PyramidTest();
            DjedTest();
        }

        private void DjedTest()
        {
            squareViewModels[70].activePiece = new DjedViewModel(Djed.dl);
            squareViewModels[71].activePiece = new DjedViewModel(Djed.dr);

            squareViewModels[01].activePiece = new DjedViewModel(Djed.dr);
            squareViewModels[02].activePiece = new DjedViewModel(Djed.dl);


            squareViewModels[72].activePiece = new DjedViewModel(Djed.dl);



            //  squareViewModels[0].FireLaser(Direction.down);
            squareViewModels[0].FireLaser(Direction.down);
        }

        private void PyramidTest()
        {

            squareViewModels[70].activePiece = new PyramidViewModel(Pyramid.bl);
            squareViewModels[71].activePiece = new PyramidViewModel(Pyramid.br);

            squareViewModels[01].activePiece = new PyramidViewModel(Pyramid.tl);
            squareViewModels[02].activePiece = new PyramidViewModel(Pyramid.tr);         

            squareViewModels[72].activePiece = new PyramidViewModel(Pyramid.bl);

            //  squareViewModels[0].FireLaser(Direction.down);
            squareViewModels[0].FireLaser(Direction.down);
        }

        private async void DestroyPyramidTest(Pyramid orientation)
        {
            // Set piece
            squareViewModels[44].activePiece = new PyramidViewModel(orientation);

            // Fire laser 
            squareViewModels[4].FireLaser(Direction.down);
            await Task.Delay(2000);
            ClearLaser();
            await Task.Delay(500);

            squareViewModels[40].FireLaser(Direction.right);
            await Task.Delay(2000);
            ClearLaser();
            await Task.Delay(500);

            squareViewModels[74].FireLaser(Direction.up);
            await Task.Delay(2000);
            ClearLaser();
            await Task.Delay(500);

            squareViewModels[49].FireLaser(Direction.left);
            await Task.Delay(2000);
            ClearLaser();
            await Task.Delay(500);

        }

        private void ClearLaser()
        {
            foreach (var square in squareViewModels)
            {
                square.Clear();
            }
        }
    }
}
