using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KhetV3.MVVM.Views
{
    /// <summary>
    /// Interaction logic for BoardView.xaml
    /// </summary>
    public partial class BoardView : UserControl
    {
        public BoardView()
        {
            InitializeComponent();
        }

        private void OnGotFocus(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("BoardView got focus");
        }

        private void OnLostFocus(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("BoardView lost focus");
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine($"KeyDown received: {e.Key}");
            // Your existing binding logic here
        }
    }
}
