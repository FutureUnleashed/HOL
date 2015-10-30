using NotificationsExtensions.Tiles;
using NotificationsExtensions.Toasts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Phone.UI.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FutureUnleashedUWP
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();
            
            SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
		}


        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                e.Handled = true;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
		{
			var senderButton = sender as Button;

			switch (senderButton.Name)
			{
				case "RelativePanel":
					this.Frame.Navigate(typeof(RPanel));
					break;

				case "Tiles":
					LaunchNVApps();
					break;

				case "Toasts":
					this.Frame.Navigate(typeof(ToastPage));
					break;

				case "ContextMenu":
					this.Frame.Navigate(typeof(ContextMenu));
					break;

				case "Data":
					this.Frame.Navigate(typeof(RoamingData));
					break;

				case "BGTask":
					this.Frame.Navigate(typeof(BGTaskPage));
					break;

				case "BGTransfer":
					this.Frame.Navigate(typeof(BackgroundTransfer));
					break;

				case "Cortana":
					this.Frame.Navigate(typeof(CortanaPage));
					break;

				case "Share":
					this.Frame.Navigate(typeof(ShareSource));
					break;

				default:
					break;
			}
		}

		private async void LaunchNVApps()
		{
			await Launcher.LaunchUriAsync(new Uri("ms-windows-store://pdp/?ProductId=9nblggh5xsl1", UriKind.RelativeOrAbsolute));            
		}



	}
}
