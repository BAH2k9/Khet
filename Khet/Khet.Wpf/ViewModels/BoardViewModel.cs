using Khet.Wpf.Core;
using Khet.Wpf.Enums;
using Khet.Wpf.Exceptions;
using Khet.Wpf.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Khet.Wpf.ViewModels
{
    public class BoardViewModel : ViewModelBase
    {
        // private members
        private MoveModel _mover;
        private BoardConfiguration _boardConfiguration;
        private SquareViewModel _selectedSquare;


        // Commands
        public ICommand SelectClick { get; }
        public ICommand ClearGridCommand { get; }
        public ICommand SetGridCommand { get; }
        public ICommand LeftKeyCommand { get; }
        public ICommand RightKeyCommand { get; }
        public ICommand selectionChangedCommand { get; }


        // Bindables - VM -> UI
        public GridModel squareViewModels { get; set; }
        public ObservableCollection<BoardConfig> boardConfigurationNames { get; set; } = new ObservableCollection<BoardConfig>();

        private string _warningMessage;
        public string WarningMessage
        {
            get => _warningMessage;
            set { _warningMessage = value; SetProperty(ref _warningMessage, value); }
        }


        // Bindables UI -> VM
        public BoardConfig selectedConfiguration { get; set; }



        public BoardViewModel(MoveModel mover, BoardConfiguration boardConfiguration)
        {
            _mover = mover;
            _boardConfiguration = boardConfiguration;
            squareViewModels = _boardConfiguration.GetGridModel();
            _boardConfiguration.SetNames(boardConfigurationNames);
            _boardConfiguration.SetSquareColor();
            _boardConfiguration.SetClassic();

            SelectClick = new RelayCommand<SquareViewModel>(ExecuteSelectClick);
            SetGridCommand = new RelayCommand<object>(param => _boardConfiguration.SetClassic());
            RightKeyCommand = new RelayCommand<object>(param => RotatePiece(Rotate.Right));
            LeftKeyCommand = new RelayCommand<object>(param => RotatePiece(Rotate.Left));
            ClearGridCommand = new RelayCommandAsync(param => GridModel.ClearGridAsync(squareViewModels));
            selectionChangedCommand = new RelayCommandAsync(param => ConfigurationChange(null));

        }

        private void ExecuteSelectClick(SquareViewModel squareViewModel)
        {
            try
            {
                WarningMessage = "";
                _selectedSquare = _mover.NewSquareClicked(squareViewModel);

            }
            catch (PieceMoveException ex)
            {
                WarningMessage = ex.Message;
            }
        }
        private void RotatePiece(Rotate rotation)
        {
            try
            {
                _selectedSquare.activePiece?.RotatePiece(rotation);
                WarningMessage = "";
            }
            catch (UserExceptions ex)
            {
                WarningMessage = ex.Message;
            }

        }

        private async Task ConfigurationChange(object param)
        {
            await GridModel.ClearGridAsync(squareViewModels);

            switch (this.selectedConfiguration)
            {
                case BoardConfig.Classic:
                    _boardConfiguration.SetClassic();
                    break;

                case BoardConfig.Dynasty:
                    _boardConfiguration.SetDynasty();
                    break;

                default:
                    break;
            }
        }
    }
}
