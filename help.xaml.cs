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
using Windows.Storage;
using Windows.UI.Popups;

//PAGE: help.xaml.cs
//DESCRIPTION: The help page is where users can access help information such as guidance on how to use the app, options they can configure in the app, recommended app downloads and technical information about the app, e.g. the build number and date.
//AUTHORED BY: Jason Brown
//BUILD: 130.02 Rev 2.0
//LAST MODIFIED: April 16 2016 

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace wh_at_Helpdesk__for_Windows_10_
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class help : Page
    {
        public help()
        {
            this.InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void osText_Tapped(object sender, RoutedEventArgs e)
        {
            //Navigate to Easter Egg
            Frame.Navigate(typeof(doge));
        }

        private async void deleteSignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StorageFile signInInfo = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("signin.txt");
                if (signInInfo != null)
                {
                    await signInInfo.DeleteAsync();
                    MessageDialog signInInfoRemoved = new MessageDialog("The sign in address has been removed." + "\n" + "\n" + "You will no longer be automatically signed into this device.", "Sign in address removed");
                    await signInInfoRemoved.ShowAsync();
                }
            }
            catch
            {
                MessageDialog noInfo = new MessageDialog("There is no sign in address to remove.", "No sign in address to remove");
                await noInfo.ShowAsync();
            }
            
        }

        private void changeSignIn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(changeaddress));
        }

        private async void deleteTicketsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog resetTicket = new MessageDialog("Do you want to remove all tickets on this device?" + "\n" + "\n" + "This action cannot be undone.", "Remove tickets");
            resetTicket.Commands.Add(new UICommand { Label = "Remove tickets", Id = 0 });
            resetTicket.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });

            var resetTicketRes = await resetTicket.ShowAsync();

            if ((int)resetTicketRes.Id == 0)
            {
                try
                {
                    StorageFile deleteTickets = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("tickets.txt");
                    if (deleteTickets != null)
                    {
                        await deleteTickets.DeleteAsync();
                        MessageDialog ticketsRemoved = new MessageDialog("All tickets have been removed.", "Tickets removed");
                        await ticketsRemoved.ShowAsync();
                    }
                }
                catch
                {
                    MessageDialog noTickets = new MessageDialog("There are no tickets to remove.", "No tickets to remove");
                    await noTickets.ShowAsync();
                }
            }
        }

        private async void downloadYammer_Click(object sender, RoutedEventArgs e)
        {
            string uriToLaunch = @"https://www.microsoft.com/en-gb/store/apps/yammer/9wzdncrfhwmz";
            var uri = new Uri(uriToLaunch);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private async void downloadSkype_Click(object sender, RoutedEventArgs e)
        {
            string uriToLaunch = @"https://www.microsoft.com/en-gb/store/apps/skype-for-business/9wzdncrfjbb2";
            var uri = new Uri(uriToLaunch);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private async void onenoteButton_Click(object sender, RoutedEventArgs e)
        {
            string uriToLaunch = @"https://www.microsoft.com/en-gb/store/apps/onenote/9wzdncrfhvjl";
            var uri = new Uri(uriToLaunch);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private async void downloadVideo_Click(object sender, RoutedEventArgs e)
        {
            string uriToLaunch = @"https://youtu.be/G6q0BD6s9MI";
            var uri = new Uri(uriToLaunch);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private async void downloadGuide_Click(object sender, RoutedEventArgs e)
        {
            string uriToLaunch = @"https://wymhigh-my.sharepoint.com/personal/09brownj_wh-at_net/_layouts/15/guestaccess.aspx?guestaccesstoken=0cIjEm3sDpPoUEx8iELTRRxu6j7EmlXobEwjXImujX0%3d&docid=048b9292b602544f095ced52791ad3881";
            var uri = new Uri(uriToLaunch);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
    }
}
