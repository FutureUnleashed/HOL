using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FutureUnleashedUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContextMenu : Page
    {

        public ContextMenu()
        {
            this.InitializeComponent();
        }

        bool IsShuffleEnabled, IsRepeatEnabled;
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            IsShuffleEnabled = false;
            ShuffleToggle.Text = "Shuffle";

            IsRepeatEnabled = false;
            RepeatToggle.Text = "Repeat";
        }

        private void ShuffleToggle_Click(object sender, RoutedEventArgs e)
        {
            if (ShuffleToggle.IsChecked == true)
            {
                IsShuffleEnabled = true;
                ShuffleToggle.Text = "Shuffle off";
            }
            else
            {
                IsShuffleEnabled = false;
                ShuffleToggle.Text = "Shuffle";
            }
        }

        private void RepeatToggle_Click(object sender, RoutedEventArgs e)
        {
            if (RepeatToggle.IsChecked == true)
            {
                IsRepeatEnabled = true;
                RepeatToggle.Text = "Repeat off";
            }
            else
            {
                IsRepeatEnabled = false;
                RepeatToggle.Text = "Repeat";
            }
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);

        }

        private void ImageMenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = sender as MenuFlyoutItem;

            if (item != null)
            {
                Image img = item.DataContext as Image;

                if (img != null)
                {
                    if (item.Tag.ToString() == "Fill")
                        img.Stretch = Stretch.Fill;
                    else if (item.Tag.ToString() == "UniformToFill")
                        img.Stretch = Stretch.UniformToFill;
                    else img.Stretch = Stretch.Uniform;
                }
            }
        }

        private void SortMenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem selectedItem = sender as MenuFlyoutItem;

            if (selectedItem != null)
            {
                if (selectedItem.Tag.ToString() == "rating")
                {
                    //SortByRating();
                }
                else if (selectedItem.Tag.ToString() == "match")
                {
                    //SortByMatch();
                }
                else if (selectedItem.Tag.ToString() == "distance")
                {
                    //SortByDistance();
                }
            }
        }
    }
}
