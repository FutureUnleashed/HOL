using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.ShareTarget;
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
    public sealed partial class ShareTarget : Page
    {
        public ShareTarget()
        {
            this.InitializeComponent();
        }



        ShareOperation so = null;

        private IReadOnlyList<IStorageItem> sharedStorageItems;


        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {

            this.so = (ShareOperation)e.Parameter;
            sharedContentTitle.Text = so.Data.Properties.Title.ToString();


            if (this.so.Data.Contains(StandardDataFormats.Text))
            {
                sharedText.Text = await this.so.Data.GetTextAsync();

            }

            //if (this.so.Data.Contains(StandardDataFormats.Html))
            //{
            //    string HtmlString = await this.so.Data.GetHtmlFormatAsync();
            //    string htmlFragment = HtmlFormatHelper.GetStaticFragment(HtmlString);


            //    ShareWebView.NavigateToString("<html><body>" + htmlFragment + "</body></html>"); ;
            //}

            //if (this.so.Data.Contains(StandardDataFormats.StorageItems))
            //{
            //    sharedStorageItems = await this.so.Data.GetStorageItemsAsync();

            //    sharedFiles.Text = "Share File Name: " + sharedStorageItems[0].Path;

            //}                           


        }



    }
}
