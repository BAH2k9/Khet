using KhetV4.Core.ExtensionMethods;
using Serilog;
using Stylet;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KhetV4.MVVM.ViewModels
{
    public class ToolbarViewModel : Screen
    {
        private double _closeOpacity;
        public double closeOpacity { get => _closeOpacity; set => SetAndNotify(ref _closeOpacity, value); }

        private double _minimiseOpacity;
        public double minimiseOpacity { get => _minimiseOpacity; set => SetAndNotify(ref _minimiseOpacity, value); }

        private double _maximiseOpacity;
        public double maximiseOpacity { get => _maximiseOpacity; set => SetAndNotify(ref _maximiseOpacity, value); }

        readonly ILogger _logger;
        Window _window => Application.Current.MainWindow;

        readonly (double high, double low) _opacityLevel;
        public ToolbarViewModel(ILogger logger)
        {
            _logger = logger;
            _logger.InformationWithCaller("ToolbarViewModel created");
            _opacityLevel = (1, 0.7);
            closeOpacity = minimiseOpacity = maximiseOpacity = _opacityLevel.low;
        }

        public void MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Image)
            {
                return;
            }

            _logger.InformationWithCaller("Clicked on Toolbar");
            if (e.ChangedButton == MouseButton.Left)
            {
                _window.DragMove();
            }
        }

        // Minimize window
        public void MinimiseClick(object sender, RoutedEventArgs e)
        {
            _logger.InformationWithCaller("Clicked on Minmise Icon");
            _window.WindowState = WindowState.Minimized;

            e.Handled = true;
        }

        // Maximize or restore window
        public void MaximiseClick(object sender, RoutedEventArgs e)
        {
            _logger.InformationWithCaller("Clicked on Maximise Icon");
            if (_window.WindowState == WindowState.Normal)
                _window.WindowState = WindowState.Maximized;
            else
                _window.WindowState = WindowState.Normal;

            e.Handled = true;
        }

        // Close window
        public void CloseClick(object sender, RoutedEventArgs e)
        {
            _logger.InformationWithCaller("Clicked on Close Icon");
            e.Handled = true;
            _window.Close();
        }

        public void MouseEnter(object sender, MouseEventArgs e)
        {
            e.Handled = true;
            if (sender is Image image)
            {
                _logger.InformationWithCaller($"Mouse Entered {image.Name} setting opacity to {_opacityLevel.high}");
                switch (image.Name)
                {
                    case "CloseIcon":
                        closeOpacity = _opacityLevel.high;
                        break;
                    case "MinimiseIcon":
                        minimiseOpacity = _opacityLevel.high;
                        break;
                    case "MaximiseIcon":
                        maximiseOpacity = _opacityLevel.high;
                        break;
                }
            }
        }

        public void MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Image image)
            {
                _logger.InformationWithCaller($"Mouse Left {image.Name} setting opacity to {_opacityLevel.low}");
                switch (image.Name)
                {
                    case "CloseIcon":
                        closeOpacity = _opacityLevel.low;
                        break;
                    case "MinimiseIcon":
                        minimiseOpacity = _opacityLevel.low;
                        break;
                    case "MaximiseIcon":
                        maximiseOpacity = _opacityLevel.low;
                        break;
                }
            }
        }
    }
}
