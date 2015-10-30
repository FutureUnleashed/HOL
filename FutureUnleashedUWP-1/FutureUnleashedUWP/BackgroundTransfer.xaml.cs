using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.BackgroundTransfer;
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
    public sealed partial class BackgroundTransfer : Page
    {
        public BackgroundTransfer()
        {
            this.InitializeComponent();
            cts = new CancellationTokenSource();
        }


        

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string serverAddressField = "http://distribution.bbb3d.renderfarming.net//video/png/00_00/0001.png";
            Uri source = new Uri(serverAddressField);

            string destination = "TEST.png";

            StorageFile destinationFile = await KnownFolders.PicturesLibrary.CreateFileAsync(
                destination, CreationCollisionOption.GenerateUniqueName);

            BackgroundDownloader downloader = new BackgroundDownloader();
            DownloadOperation download = downloader.CreateDownload(source, destinationFile);

            Progress<DownloadOperation> progressCallback = new Progress<DownloadOperation>(DownloadProgress);

           // await download.StartAsync();

            await download.StartAsync().AsTask(cts.Token,progressCallback);

        }
        CancellationTokenSource cts;
        private void DownloadProgress(DownloadOperation download)
        {

            BackgroundDownloadProgress currentProgress = download.Progress;
            double percent = 100;
            if (currentProgress.TotalBytesToReceive > 0)
            {
                percent = currentProgress.BytesReceived * 100 / currentProgress.TotalBytesToReceive;
            }
            Status.Text = (String.Format(
                CultureInfo.CurrentCulture,
                " - Transfered bytes: {0} of {1}, {2}%",
                currentProgress.BytesReceived,
                currentProgress.TotalBytesToReceive,
                percent));

        }
    }
}
