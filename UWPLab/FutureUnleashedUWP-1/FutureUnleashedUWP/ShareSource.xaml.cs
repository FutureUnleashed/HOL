using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FutureUnleashedUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShareSource : Page
    {
        public ShareSource()
        {
            this.InitializeComponent();
        }



        DataTransferManager dataTransferManager;


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            dataTransferManager = DataTransferManager.GetForCurrentView();

            dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager,

            DataRequestedEventArgs>(this.ShareHandler);


        }
        
        private async void ShareHandler(DataTransferManager sender, DataRequestedEventArgs args)
        {


            DataRequest request = args.Request;
            request.Data.Properties.Title = "Share Example";
            request.Data.Properties.Description = "A demonstration that shows how to share.";

            if (Options == 0)
            {
                //  SHARE TEXT 
                request.Data.SetText("Hello World! I am sharing this text from my Share Source app");
            }


            //else
            //if (Options == 1)
            //{
            //    //  SHARE HTML 

            //    string htmlExample = "<h1>This is a Heading</h1><p> This is a paragraph.</p>";
            //    string htmlFormat = HtmlFormatHelper.CreateHtmlFormat(htmlExample);

            //    request.Data.SetHtmlFormat(htmlFormat);


            //}

            //else
            //    if (Options == 2)
            //{
            //    // SHARE FILE 
            //    DataRequestDeferral deferral = request.GetDeferral();

            //    // Make sure we always call Complete on the deferral.
            //    try
            //    {
            //        StorageFile logoFile =
            //            await Package.Current.InstalledLocation.GetFileAsync("Assets\\1000.png");
            //        List<IStorageItem> storageItems = new List<IStorageItem>();
            //        storageItems.Add(logoFile);
            //        request.Data.SetStorageItems(storageItems);
            //    }
            //    finally
            //    {
            //        deferral.Complete();
            //    }
            //}

        }




        int Options = 10;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;

            switch (b.Name)
            {
                case "ShareText":
                    {
                        Options = 0;
                        DataTransferManager.ShowShareUI();
                        break;
                    }


                case "ShareHTML":
                    {
                        Options = 1;
                        //  DataTransferManager.ShowShareUI();
                        break;
                    }
                case "ShareFiles":
                    {
                        Options = 2;
                        //   DataTransferManager.ShowShareUI();
                        break;
                    }
            }

        }









    }
}
