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

//PAGE: changeaddress.xaml.cs
//DESCRIPTION: This page allows the user to change the default sign in address of the app. Ideally this page shouldn't have to exist because you should be able to navigate to the MainPage, however that didn't work so this page was created instead.
//AUTHORED BY: Jason Brown
//BUILD: 130.01
//LAST MODIFIED: February 09 2016

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace wh_at_Helpdesk__for_Windows_10_
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class changeaddress : Page
    {
        public changeaddress()
        {
            this.InitializeComponent();
        }

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

                    if (signinAddress.ToString() == "")
                    {
                        emailBox.Text = "@wh-at.net";
                    }
                    else
                    {
                        emailBox.Text = signinAddress.ToString();
                    }
                }
                stream.Dispose(); 
            }
        }

        private async void changeAddressButton_Click(object sender, RoutedEventArgs e)
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
                //WRITE TEXT FILE TO KEEP USER SIGNED IN

                //Create the text file to hold the data
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
                    Frame.GoBack();
                }
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
