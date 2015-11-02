using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;

namespace BGTasks
{
    public sealed class BG : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {


            // Checking for the last time access when the network was available and displaying it on the live tile.

            var tileContent = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text01);

            var tileLines = tileContent.SelectNodes("tile/visual/binding/text");

            var networkStatus = Windows.Networking.Connectivity.NetworkInformation.GetInternetConnectionProfile();

            tileLines[0].InnerText = (networkStatus == null) ?
                "No network" :
                networkStatus.GetNetworkConnectivityLevel().ToString();

            tileLines[1].InnerText = DateTime.Now.ToString("MM/dd/yyyy");
            tileLines[2].InnerText = DateTime.Now.ToString("HH:mm:ss");
            tileLines[3].InnerText = "Update from my App";

            var notification = new TileNotification(tileContent);

            var updater = TileUpdateManager.CreateTileUpdaterForApplication();

            updater.Update(notification);

        }
    }
}
