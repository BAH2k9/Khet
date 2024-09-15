using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Khet.Wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private BoardViewModel _boardViewModel;
        public BoardViewModel boardViewModel { get => _boardViewModel; set => SetProperty(ref _boardViewModel, value); }

        public ICommand Player1FireCommand { get; }
        public ICommand Player2FireCommand { get; }

        public MainViewModel()
        {

            boardViewModel = new BoardViewModel();

             Player1FireCommand = new RelayCommand<object>(FireLaserPlayer1);
             Player2FireCommand = new RelayCommand<object>(FireLaserPlayer2);
        }

        public void FireLaserPlayer1(object obj)
        {
            FireLaserPlayer(0, 0, Direction.down);
        }

        public void FireLaserPlayer2(object obj)
        {
            FireLaserPlayer(7, 9, Direction.up);
        }

        async Task FireLaserPlayer(int x, int y, Direction direction)
        {
            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                FireLaser(boardViewModel.squareViewModels, x, y, direction);
            });

            await Task.Delay(3000);

            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                GridModel.ClearLaser(boardViewModel.squareViewModels);
            });
        }

        public static void FireLaser(GridModel squareViewModels, int i, int j, Direction direction)
        {
            GridModel.ClearLaser(squareViewModels);

            while (GridModel.InBounds(i, j) && direction != Direction.kill)
            {
                switch (direction = squareViewModels[i][j].FireLaser(direction))
                {
                    case Direction.up:
                        i--;
                        break;
                    case Direction.down:
                        i++;
                        break;
                    case Direction.left:
                        j--;
                        break;
                    case Direction.right:
                        j++;
                        break;

                    default: break;
                }
            }
        }

    }
}
