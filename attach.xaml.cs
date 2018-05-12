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
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Pickers.Provider; //activate the file picker

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace wh_at_Helpdesk__for_Windows_10_
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class attach : Page
    {
        public attach()
        {
            this.InitializeComponent();
        }

        private async void attachFileButton_Tapped(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            /*if (file != null)
            {
                // Application now has read/write access to the picked file
                this.textBlock.Text = "Picked photo: " + file.Name;
            }
            else
            {
                this.textBlock.Text = "Operation cancelled.";
            }*/


        }

        private async void takePhotoButton_Tapped(object sender, RoutedEventArgs e)
        {
            MessageDialog useCamera = new MessageDialog("Please note that the camera is best used only on mobile devices such as smartphones and tablets." + "\n" + "\n" + "Click or tap Use Camera to use the camera or click or tap Cancel to go back.", "Camera");
            useCamera.Commands.Add(new UICommand { Label = "Use Camera", Id = 0 });
            useCamera.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });

            var useCameraRes = await useCamera.ShowAsync();

            if ((int)useCameraRes.Id == 0)
            {
                CameraCaptureUI captureUI = new CameraCaptureUI();
                captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
                captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);

                StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

                if (photo == null)
                {
                    // User cancelled photo capture
                    return;
                }
            }            
        }

        private async void takeVideoButton_Tapped(object sender, RoutedEventArgs e)
        {
            MessageDialog useVideo = new MessageDialog("Please note that the camera is best used only on mobile devices such as smartphones and tablets." + "\n" + "\n" + "Click or tap Use Camera to use the camera or click or tap Cancel to go back.", "Camera");
            useVideo.Commands.Add(new UICommand { Label = "Use Camera", Id = 0 });
            useVideo.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });

            var useCameraRes = await useVideo.ShowAsync();

            if ((int)useCameraRes.Id == 0)
            {
                CameraCaptureUI captureUI = new CameraCaptureUI();
                captureUI.VideoSettings.Format = CameraCaptureUIVideoFormat.Mp4;

                StorageFile videoFile = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Video);

                if (videoFile == null)
                {
                    // User cancelled photo capture
                    return;
                }
            }
        }

        private void takeScreenshotButton_Tapped(object sender, RoutedEventArgs e)
        {
            //
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void emailButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
