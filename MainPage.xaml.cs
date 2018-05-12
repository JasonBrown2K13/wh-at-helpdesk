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
using Windows.UI.Popups;
using Windows.Storage;
using Windows.ApplicationModel;

//PAGE: MainPage.xaml.cs
//DESCRIPTION: The first page that loads when the app is launched. This is where users must sign in with a valid staff @wh-at.net email address to in order to use the helpdesk.
//AUTHORED BY: Jason Brown
//BUILD: 130.01
//LAST MODIFIED: February 09 2016

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace wh_at_Helpdesk__for_Windows_10_
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
  
        public MainPage()
        {
            this.InitializeComponent();         
        }

        //We use a protected override void to execute code as soon as the page is loaded into memory
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        { 
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile signInInfo = await storageFolder.CreateFileAsync("signin.txt", Windows.Storage.CreationCollisionOption.OpenIfExists);

            var stream = await signInInfo.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
            ulong size = stream.Size;

            using (var inputStream = stream.GetInputStreamAt(0))
            {
                using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
                {
                    uint numBytesLoaded = await dataReader.LoadAsync((uint)size);
                    string signinAddress = dataReader.ReadString(numBytesLoaded);
                    //string currentUser = emailBox.Text;

                    if (signinAddress.ToString() == "")
                    {
                        emailBox.Text = "@wh-at.net";
                    }
                    else
                    {
                        emailBox.Text = signinAddress.ToString();
                        Frame.Navigate(typeof(helpdesk));
                    }                   
                }
            }
            stream.Dispose();
        }                

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            emailBox.Text = "@wh-at.net";
        }

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (emailBox.Text == "")
            {
                MessageDialog noEmail = new MessageDialog("You need to enter an e-mail address to use the Helpdesk.", "No e-mail address");
                await noEmail.ShowAsync();
            }

            else if (!addresslist.addressArray.Contains(emailBox.Text))
            {
                MessageDialog invalidEmail = new MessageDialog("The e-mail address you have entered is invalid." + "\n" + "\n" + "The e-mail address must be a @wh-at.net address and you must be a staff member to use the Helpdesk." + "\n" + "\n" + "If you do not have a wh-at.net e-mail address or you cannot log in with your staff e-mail address please contact your system administrator.", "Invalid e-mail address");
                await invalidEmail.ShowAsync();
            }

            else
            {
                this.Frame.Navigate(typeof(helpdesk));
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private async void keepSignedIn_Checked(object sender, RoutedEventArgs e)
        {    
            
            if (!addresslist.addressArray.Contains(emailBox.Text))
            {
                MessageDialog invalidEmail = new MessageDialog("The e-mail address you have entered is invalid." + "\n" + "\n" + "The e-mail address must be a @wh-at.net address and you must be a staff member to use the helpdesk." + "\n" + "\n" + "If you do not have a wh-at.net e-mail address or you cannot log in with your staff e-mail address please contact your system administrator.", "Invalid e-mail address");
                await invalidEmail.ShowAsync();
                keepSignedIn.IsChecked = false;
            }

            else if (emailBox.Text == "")
            {
                MessageDialog noEmail = new MessageDialog("You need to enter an e-mail address to use the Helpdesk.", "No e-mail address");
                await noEmail.ShowAsync();
                keepSignedIn.IsChecked = false;
            }

            else
            {
                //WRITE TEXT FILE TO KEEP USER SIGNED IN

                //Create the text file to hold the data
                keepSignedIn.IsChecked = true;

                Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile signinFile = await storageFolder.CreateFileAsync("signin.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

                //Write data to the file
                await Windows.Storage.FileIO.WriteTextAsync(signinFile, emailBox.Text.ToString());

                //MessageBox
                MessageDialog savedAddress = new MessageDialog("Address saved. You will automatically be signed in on this device using the address: " + emailBox.Text.ToString(), "Automatic sign in");
                savedAddress.Commands.Add(new UICommand { Label = "Close", Id = 0 });

                var savedAddressRes = await savedAddress.ShowAsync();

                if ((int)savedAddressRes.Id == 0)
                {
                    Frame.Navigate(typeof(helpdesk));
                }
            }
        }
    }
}

