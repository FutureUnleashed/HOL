using NotificationsExtensions.Toasts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
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
    public sealed partial class ToastPage : Page
    {
        public ToastPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var senderButton = sender as Button;


            switch (senderButton.Name)
            {
                case "NormalToast":
                    ShowNormal();
                    break;

                case "ActionToast":
                    ShowWithAction();
                    break;

                case "InputToast":
                    ShowWithInputs();
                    break;

                case "InputToast2":
                    ShowWithInputs2();
                    break;

                case "SelectionToast":
                    ShowWithSelection();
                    break;

                case "ReminderToast":
                    ShowReminder();
                    break;

                case "SnoozeDismiss":
                    ShowSnoozeDismiss();
                    break;

                case "SnoozeDismiss2":
                    ShowSnoozeDismiss2();
                    break;

                default:
                    break;
            }
        }

        private void ShowNormal()
        {
            string myXml = @"
                            <toast>
                              <visual>
                                <binding template=""ToastGeneric"">
                                    <text>Photo Share</text>
                                    <text>Andrew sent you a picture</text>
                                    <text>See it in full size!</text>
                                    <image placement=""appLogoOverride"" src=""Assets/44.png"" />
                                    <image placement=""inline"" src=""Assets/hiking.png"" hint-crop=""none"" />
                                </binding>
                              </visual>
                            </toast>
                            ";

            XmlDocument myToastXml = new XmlDocument();
            myToastXml.LoadXml(myXml);

            ToastNotification myToast = new ToastNotification(myToastXml);
            ToastNotificationManager.CreateToastNotifier().Show(myToast);
        }

        private void ShowWithAction()
        {
            string myXml = @"
                            <toast>
                              <visual>
                                <binding template=""ToastGeneric"">
                                  <text>Microsoft Company Store</text>
                                  <text>New Halo game is back in stock!</text>
                                  <image placement=""appLogoOverride"" src=""Assets/StoreLogo.png"" />
                                  <image placement=""inline"" src=""Assets/Halo.png"" hint-crop=""none"" />
                                </binding>
                              </visual>
                              <actions>
                                <action activationType=""foreground"" content=""show details"" arguments=""details"" imageUri=""Assets/Check.png""/>
                                <action activationType=""background"" content=""maybe later"" arguments=""later"" imageUri=""Assets/Cancel.png""/>
                                <action activationType=""protocol"" content=""show map"" arguments=""bingmaps:?q=Microsoft"" />
                              </actions>
                            </toast>
                            ";

            XmlDocument myToastXml = new XmlDocument();
            myToastXml.LoadXml(myXml);

            ToastNotification myToast = new ToastNotification(myToastXml);
            ToastNotificationManager.CreateToastNotifier().Show(myToast);
        }

        private void ShowWithInputs()
        {
            string myXml = @"
                            <toast>
                              <visual>
                                <binding template=""ToastGeneric"">
                                  <text>Andrew B.</text>
                                  <text>Shall we meet up at 8?</text>
                                  <image placement=""appLogoOverride"" src=""Assets\44.png"" />
                                </binding>
                              </visual>
                              <actions>
                                <input id=""message"" type=""text"" placeHolderContent=""reply here"" />
                                <action activationType=""background"" content=""reply"" arguments=""reply"" />
                                <action activationType=""foreground"" content=""video call"" arguments=""video"" />
                              </actions>
                            </toast>
                            ";

            XmlDocument myToastXml = new XmlDocument();
            myToastXml.LoadXml(myXml);

            ToastNotification myToast = new ToastNotification(myToastXml);
            ToastNotificationManager.CreateToastNotifier().Show(myToast);
        }

        private void ShowWithInputs2()
        {
            string myXml = @"
                            <toast>
                              <visual>
                                <binding template=""ToastGeneric"">
                                  <text>Andrew B.</text>
                                  <text>Shall we meet up at 8?</text>
                                  <image placement=""appLogoOverride"" src=""Assets\44.png"" />
                                </binding>
                              </visual>
                              <actions>
                                <input id=""message"" type=""text"" placeHolderContent=""reply here"" />
                                <action activationType=""background"" content=""reply"" arguments=""reply"" imageUri=""Assets\Check.png"" hint-inputId=""message""/>
                              </actions>
                            </toast>
                            ";

            XmlDocument myToastXml = new XmlDocument();
            myToastXml.LoadXml(myXml);

            ToastNotification myToast = new ToastNotification(myToastXml);
            ToastNotificationManager.CreateToastNotifier().Show(myToast);
        }

        private void ShowWithSelection()
        {
            string myXml = @"
                            <toast>
                              <visual>
                                <binding template=""ToastGeneric"">
                                  <text>Mukesh Sinha</text>
                                  <text>How much bonus do you want?</text>
                                  <image placement=""appLogoOverride"" src=""Assets\44.png"" />
                                </binding>
                              </visual>
                              <actions>
                                <input id=""time"" type=""selection"" defaultInput=""1"" >
                                    <selection id=""1"" content=""100%"" />
                                    <selection id=""2"" content=""200%"" />
                                    <selection id=""3"" content=""400%"" />
                                </input>
                                <action activationType=""background"" content=""Confirm"" arguments=""confirm"" />
                                <action activationType=""background"" content=""Let me think"" arguments=""later"" />
                              </actions>
                            </toast>
                            ";

            XmlDocument myToastXml = new XmlDocument();
            myToastXml.LoadXml(myXml);

            ToastNotification myToast = new ToastNotification(myToastXml);
            ToastNotificationManager.CreateToastNotifier().Show(myToast);
        }

        private void ShowReminder()
        {
            string myXml = @"
                            <toast scenario=""reminder"">
                              <visual>
                                <binding template=""ToastGeneric"">
                                  <text>Adam's Hiking Camp</text>
                                  <text>You have an upcoming event for this Friday!</text>
                                  <text>RSVP before it""s too late.</text>
                                  <image placement=""appLogoOverride"" src=""Assets\44.png"" />
                                  <image placement=""inline"" src=""Assets/hiking.png"" />
                                </binding>
                              </visual>
                              <actions>
                                <action activationType=""background"" content=""RSVP"" arguments=""rsvp"" />
                                <action activationType=""background"" content=""Reminder me later"" arguments=""later"" />
                              </actions>
                            </toast>
                            ";

            XmlDocument myToastXml = new XmlDocument();
            myToastXml.LoadXml(myXml);

            ToastNotification myToast = new ToastNotification(myToastXml);
            ToastNotificationManager.CreateToastNotifier().Show(myToast);
        }

        private void ShowSnoozeDismiss()
        {
            string myXml = @"
                            <toast scenario=""reminder"">
                              <visual>
                                <binding template=""ToastGeneric"">
                                  <text>Time to Fly</text>
                                  <text>It's time to take your flight to Bangalore!</text>
                                  <image placement=""appLogoOverride"" src=""Assets\44.png"" />
                                  <image placement=""inline"" src=""hiking.png"" />
                                </binding>
                              </visual>
                              <actions hint-systemCommands = ""SnoozeAndDismiss"">
                              </actions>
                            </toast>
                            ";

            XmlDocument myToastXml = new XmlDocument();
            myToastXml.LoadXml(myXml);

            ToastNotification myToast = new ToastNotification(myToastXml);
            ToastNotificationManager.CreateToastNotifier().Show(myToast);
        }

        private void ShowSnoozeDismiss2()
        {
            string myXml = @"
                            <toast scenario=""reminder"">
                              <visual>
                                <binding template=""ToastGeneric"">
                                  <text>Time to Fly</text>
                                  <text>It's time to take your flight to Bangalore!</text>
                                  <image placement=""appLogoOverride"" src=""Assets\44.png"" />
                                  <image placement=""inline"" src=""hiking.png"" />
                                </binding>
                              </visual>
                              <actions>
                                 <input id=""snoozeTime"" type=""selection"" defaultInput=""10"">
                                    <selection id=""5"" content=""5 minutes"" />
                                    <selection id=""10"" content=""10 minutes"" />
                                    <selection id=""20"" content=""20 minutes"" />
                                    <selection id=""30"" content=""30 minutes"" />
                                    <selection id=""60"" content=""1 hour"" />
                                 </input>
                                <action activationType=""system"" arguments=""snooze"" hint-inputId=""snoozeTime"" content=""""/>
                                <action activationType=""system"" arguments=""dismiss"" content=""""/>
                              </actions>
                            </toast>
                            ";

            XmlDocument myToastXml = new XmlDocument();
            myToastXml.LoadXml(myXml);

            ToastNotification myToast = new ToastNotification(myToastXml);
            ToastNotificationManager.CreateToastNotifier().Show(myToast);
        }

    }
}
