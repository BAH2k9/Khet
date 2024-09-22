using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Khet.Wpf.Behaviors
{
    public static class ComboBoxBehavior
    {
        public static readonly DependencyProperty DisableArrowKeysBehaviorProperty =
            DependencyProperty.RegisterAttached(
                "DisableArrowKeysBehavior",
                typeof(bool),
                typeof(ComboBoxBehavior),
                new PropertyMetadata(false, OnDisableArrowKeysBehaviorChanged));

        public static bool GetDisableArrowKeysBehavior(DependencyObject obj)
        {
            return (bool)obj.GetValue(DisableArrowKeysBehaviorProperty);
        }

        public static void SetDisableArrowKeysBehavior(DependencyObject obj, bool value)
        {
            obj.SetValue(DisableArrowKeysBehaviorProperty, value);
        }

        private static void OnDisableArrowKeysBehaviorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ComboBox comboBox)
            {
                if ((bool)e.NewValue)
                {
                    comboBox.PreviewKeyDown += ComboBox_PreviewKeyDown;
                }
                else
                {
                    comboBox.PreviewKeyDown -= ComboBox_PreviewKeyDown;
                }
            }
        }

        private static void ComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left || e.Key == Key.Right)
            {
                // Instead of marking the event as handled, we'll just suppress the
                // default behavior of the ComboBox for these keys
               // e.handled = true;

                // Re-raise the event at the window level
                if (sender is ComboBox comboBox)
                {
                    //var window = Window.GetWindow(comboBox);
                    //if (window != null)
                    //{
                    //    var newEvent = new KeyEventArgs(e.KeyboardDevice, e.InputSource, e.Timestamp, e.Key)
                    //    {
                    //        RoutedEvent = Keyboard.KeyDownEvent
                    //    };
                    //    window.RaiseEvent(newEvent);
                    //}

                    // Focus moves to the next or previous control instead of the ComboBox handling it
                    TraversalRequest tRequest = e.Key == Key.Right || e.Key == Key.Left
                        ? new TraversalRequest(FocusNavigationDirection.Previous)
                        : new TraversalRequest(FocusNavigationDirection.Next);

                    comboBox.MoveFocus(tRequest);
                }
            }
        }
    }
}
