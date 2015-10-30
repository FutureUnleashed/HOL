using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class RoamingData : Page
    {
        ApplicationDataContainer roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;
        public RoamingData()
        {
            this.InitializeComponent();
        }

        private void Current_DataChanged(ApplicationData sender, object args)
        {
            Object value = roamingSettings.Values["SeekValue"];

        }

        private void mediaElement_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            var myMediaElement = sender as MediaElement;
            TimeSpan timeSpan = new TimeSpan(0);


            switch (myMediaElement.CurrentState)
            {
                case MediaElementState.Opening:
                    break;

                case MediaElementState.Paused:
                    Object value = roamingSettings. Values["SeekValue"];
                    if (value != null)
                    {
                        TimeSpan seekTime = (TimeSpan)value;
                        TimeSpan zeroTime = new TimeSpan(0);
                        if (myMediaElement.Position == zeroTime)
                        {
                            myMediaElement.Position = seekTime;
                            roamingSettings.Values.Remove("SeekValue");
                        }
                    }
                    break;

                case MediaElementState.Playing:
                    break;

                case MediaElementState.Stopped:
                    break;

                default:
                    break;
            }
            
            if (myMediaElement.CurrentState == MediaElementState.Paused && myMediaElement.Position != timeSpan)
            {
                roamingSettings.Values["SeekValue"] = myMediaElement.Position;
                ApplicationData.Current.SignalDataChanged();
            }
        }
    }
}
