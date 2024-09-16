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
        public ICommand SelectClick { get; }
        public ICommand PyramidTestCommand { get; }
        public ICommand DjedTestCommand { get; }
        public ICommand ClearGridCommand { get; }
        public ICommand SetGridCommand { get; }
        public ICommand LeftKeyCommand { get; }
        public ICommand RightKeyCommand { get; }

        public ICommand selectionChangedCommand { get; }
        public SquareViewModel SelectedSquare { get; set; } = new SquareViewModel(0,0) { IsSelected = false };

        private MoveModel _mover = new MoveModel();
        public GridModel squareViewModels { get; set; }

        private string _warningMessage;

        private ObservableCollection<BoardConfig> _boardConfigurations = new ObservableCollection<BoardConfig> { BoardConfig.Classic, BoardConfig.Dynasty };

        public ObservableCollection<BoardConfig> boardConfigurations
        {
            get => _boardConfigurations; set => SetProperty(ref _boardConfigurations, value);
        }

        private BoardConfig _selectedConfiguration;
        public BoardConfig selectedConfiguration
        {
            get => _selectedConfiguration; set { SetProperty(ref _selectedConfiguration, value); }
        }

        public string WarningMessage
        {
            get => _warningMessage;
            set
            {
                _warningMessage = value;
                OnPropertyChanged(nameof(WarningMessage));
            }
        }


        public BoardViewModel()
        {
            SelectClick = new RelayCommand<SquareViewModel>(ExecuteSelectClick);
            ClearGridCommand = new RelayCommandAsync(param =>  GridModel.ClearGrid(squareViewModels));
            SetGridCommand = new RelayCommand<object>(param => BoardConfiguration.Classic(squareViewModels));
            RightKeyCommand = new RelayCommand<object>(param => RotatePiece(Rotate.Right));
            LeftKeyCommand = new RelayCommand<object>(param => RotatePiece(Rotate.Left));
            selectionChangedCommand = new RelayCommandAsync(param => ConfigurationChange());

            squareViewModels = GridModel.Create();

            BoardConfiguration.Classic(squareViewModels);
            BoardConfiguration.SetSquareColor(squareViewModels);


        }

        private void ExecuteSelectClick(SquareViewModel squareViewModel)
        {
            try
            {
                WarningMessage = "";
                this.SelectedSquare = _mover.NewSquareClicked(squareViewModel);

            }
            catch(PieceMoveException ex)
            {
                WarningMessage = ex.Message;
            }
        }
        private void RotatePiece(Rotate rotation)
        {
            try
            {
                this.SelectedSquare.activePiece?.RotatePiece(rotation);
                WarningMessage = "";
            }
            catch(UserExceptions ex) 
            {
                WarningMessage = ex.Message;
            }
            
        }

        private async Task ConfigurationChange(object param=null)
        {
            await GridModel.ClearGrid(squareViewModels);

            switch (this.selectedConfiguration)
            {
                case BoardConfig.Classic:

                    BoardConfiguration.Classic(squareViewModels);


                    break;

                case BoardConfig.Dynasty:
                    
                    BoardConfiguration.Dynasty(squareViewModels);

                    break;

                default:

                    break;
            }

        }


    }
}
