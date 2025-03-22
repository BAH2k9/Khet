using KhetV4.Core.ExtensionMethods;
using KhetV4.Core.StaticClasses;
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

        public ToolbarViewModel(ILogger logger)
        {
            _logger = logger;
            _logger.InformationWithCaller("ToolbarViewModel created");
            closeOpacity = minimiseOpacity = maximiseOpacity = Mappings.OpacityLevel.Normal;
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
                _logger.InformationWithCaller($"Mouse Entered {image.Name} setting opacity to {Mappings.OpacityLevel.Highlighted}");
                switch (image.Name)
                {
                    case "CloseIcon":
                        closeOpacity = Mappings.OpacityLevel.Highlighted;
                        break;
                    case "MinimiseIcon":
                        minimiseOpacity = Mappings.OpacityLevel.Highlighted;
                        break;
                    case "MaximiseIcon":
                        maximiseOpacity = Mappings.OpacityLevel.Highlighted;
                        break;
                }
            }
        }

        public void MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Image image)
            {
                _logger.InformationWithCaller($"Mouse Left {image.Name} setting opacity to {Mappings.OpacityLevel.Normal}");
                switch (image.Name)
                {
                    case "CloseIcon":
                        closeOpacity = Mappings.OpacityLevel.Normal;
                        break;
                    case "MinimiseIcon":
                        minimiseOpacity = Mappings.OpacityLevel.Normal;
                        break;
                    case "MaximiseIcon":
                        maximiseOpacity = Mappings.OpacityLevel.Normal;
                        break;
                }
            }
        }
    }
}
