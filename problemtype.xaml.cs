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

//PAGE: problemtype.xaml.cs
//DESCRIPTION: On this page the user selects a problem, e.g. 'printers' or 'wi-fi'. The user must choose a problem. If they leave this page without a problem a dialogue informs them that they must choose a problem. 
//AUTHORED BY: Jason Brown
//BUILD: 130.01
//LAST MODIFIED: February 09 2016

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace wh_at_Helpdesk__for_Windows_10_
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class problemtype : Page
    {
        public problemtype()
        {
            this.InitializeComponent();
        }

        private async void assemblyButton_Tapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemFile = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(problemFile, assemblyButton.Text.ToString());

            Frame.GoBack();
        }

        //Network
        private async void mainNetworkButton_Tapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemFile = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(problemFile, mainNetworkButton.Text.ToString());

            Frame.GoBack();
        }

        private async void wifiButton_Tapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemFile = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(problemFile, wifiButton.Text.ToString());

            Frame.GoBack();
        }

        private async void loggingInButton_Tapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemFile = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(problemFile, loggingInButton.Text.ToString());

            Frame.GoBack();
        }

        private async void accessingFilesButton_Tapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemFile = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(problemFile, accessingFilesButton.Text.ToString());

            Frame.GoBack();
        }

        //Peripherals
        private async void printersButton_Tapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemFile = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(problemFile, printersButton.Text.ToString());

            Frame.GoBack();
        }

        private async void projectorsButton_Tapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemFile = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(problemFile, projectorsButton.Text.ToString());

            Frame.GoBack();
        }

        private async void whiteboardButton_Tapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemFile = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(problemFile, whiteboardButton.Text.ToString());

            Frame.GoBack();
        }

        private async void soundButton_Tapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemFile = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(problemFile, soundButton.Text.ToString());

            Frame.GoBack();
        }

        private async void miceButton_Tapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemFile = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(problemFile, miceButton.Text.ToString());

            Frame.GoBack();
        }

        //Computers
        private async void notStartingButton_Tapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemFile = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(problemFile, notStartingButton.Text.ToString());

            Frame.GoBack();
        }

        private async void runningSlowButton_Tapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemFile = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(problemFile, runningSlowButton.Text.ToString());

            Frame.GoBack();
        }

        private async void surfacesButton_Tapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemFile = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(problemFile, surfacesButton.Text.ToString());

            Frame.GoBack();
        }

        private async void schoolLaptopsButton_Tapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemFile = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(problemFile, schoolLaptopsButton.Text.ToString());

            Frame.GoBack();
        }

        //Office 365
        private async void metroCentralButton_Tapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemFile = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(problemFile, metroCentralButton.Text.ToString());

            Frame.GoBack();
        }

        private async void onedriveButton_Tapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemFile = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(problemFile, onedriveButton.Text.ToString());

            Frame.GoBack();
        }

        private async void yammerButton_Tapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemFile = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(problemFile, yammerButton.Text.ToString());

            Frame.GoBack();
        }

        private async void emailsButton_Tapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemFile = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(problemFile, emailsButton.Text.ToString());

            Frame.GoBack();
        }

        //Other
        private async void otherButton_Tapped(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemFile = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(problemFile, otherButton.Text.ToString());

            Frame.GoBack();
        }

        private async void backButton_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog noProblem = new MessageDialog("You are required to choose a problem type." + "\n" + "\n" + "If you don't choose one now you will need to choose one later. Click or tap Choose Now to choose a problem type now or Choose Later to choose later.", "No problem type chosen");
            noProblem.Commands.Add(new UICommand { Label = "Choose Now", Id = 0 });
            noProblem.Commands.Add(new UICommand { Label = "Choose Later", Id = 1 });

            var res = await noProblem.ShowAsync();

            if ((int)res.Id == 1)
            {
                Frame.GoBack();
            }          
        }
    }
}

