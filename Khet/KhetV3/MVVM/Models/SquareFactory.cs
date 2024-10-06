using KhetV3.MVVM.ViewModels;
using KhetV3.Services;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV3.MVVM.Models
{
    public class SquareFactory
    {
        private BindableCollection<SquareViewModel> _bindableSquares;
        private Dictionary<(int, int), SquareViewModel> _squareDict;

        private ClickService _clickService;
        public SquareFactory(ClickService clickService)
        {
            _clickService = clickService;
        }

        public void CreateSquares(int rows, int cols)
        {
            _bindableSquares = new BindableCollection<SquareViewModel>();
            _squareDict = new Dictionary<(int, int), SquareViewModel>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var square = new SquareViewModel(_clickService);
                    square.position = (row, col);
                    _bindableSquares.Add(square);
                    _squareDict[(row, col)] = square;
                }
            }

        }

        public BindableCollection<SquareViewModel> GetBindableSquares()
        {
            return _bindableSquares;
        }

        public Dictionary<(int, int), SquareViewModel> GetSquares()
        {
            return _squareDict;
        }
    }
}
