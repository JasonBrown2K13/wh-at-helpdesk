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
using Windows.ApplicationModel.Email;
using Windows.Media.Capture;
using Windows.Storage.Pickers;

//PAGE: helpdesk.xaml.cs
//DESCRIPTION: This is the main page of the app. Users write their ticket here and from here can select a problem, a room, a priority as well as attach files and use the device's camera to take a photograph or a video of the problem. By swiping left they can access tickets that have been saved on the device.
//AUTHORED BY: Jason Brown
//BUILD: 130.01
//LAST MODIFIED: February 09 2016 

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace wh_at_Helpdesk__for_Windows_10_
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class helpdesk : Page
    {
        public helpdesk()
        {
            this.InitializeComponent();
        }

        private StorageFile _file;

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //Select problem button
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile problemInfo = await storageFolder.CreateFileAsync("problem.txt", Windows.Storage.CreationCollisionOption.OpenIfExists);

            var problemStream = await problemInfo.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
            ulong problemSize = problemStream.Size;

            using (var inputStream = problemStream.GetInputStreamAt(0))
            {
                using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
                {
                    uint numBytesLoaded = await dataReader.LoadAsync((uint)problemSize);
                    string problemContent = dataReader.ReadString(numBytesLoaded);

                    if (problemContent == "")
                    {
                        selectProblemButton.Content = "choose a problem";
                    }
                    else
                    {
                        selectProblemButton.Content = problemContent.ToString();
                    }
                }
            }
            problemStream.Dispose();

            //Select room button
            Windows.Storage.StorageFile roomInfo = await storageFolder.CreateFileAsync("room.txt", Windows.Storage.CreationCollisionOption.OpenIfExists);

            var roomStream = await roomInfo.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
            ulong roomSize = roomStream.Size;

            using (var inputStream = roomStream.GetInputStreamAt(0))
            {
                using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
                {
                    uint numBytesLoaded = await dataReader.LoadAsync((uint)roomSize);
                    string roomContent = dataReader.ReadString(numBytesLoaded);

                    if (roomContent == "")
                    {
                        selectRoomButton.Content = "choose a room";
                    }
                    else
                    {
                        selectRoomButton.Content = roomContent.ToString();
                    }
                }
            }
            roomStream.Dispose();        
        }

        private void descriptionText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string textLength = descriptionText.Text.Length.ToString();
            int textOverflow_int = 600 - descriptionText.Text.Length;
            string textOverflow_str = textOverflow_int.ToString();

            descriptionText.MaxLength = 600;

            charactersText.Text = textOverflow_str + " characters remaining";

            while (textOverflow_int < 0)
            {
                charactersText.Text = "600 characters reached";
                break;
            }
        }

        string priority = "not specified";
        private void lowPriority_Checked(object sender, RoutedEventArgs e)
        {
            priority = "low";
        }

        private void fairPriority_Checked(object sender, RoutedEventArgs e)
        {
            priority = "medium";
        }

        private void highPriority_Checked(object sender, RoutedEventArgs e)
        {
            priority = "high";
        }

        private void selectProblemButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(problemtype));
        }

        private void selectRoomButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(selectroom));
        }

        private async void cameraButton_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog useCamera = new MessageDialog("Would you like to take a photo or a video?" + "\n" + "\n" + "Please note the longest video you can send to the helpdesk is 30 seconds.", "Camera");
            useCamera.Commands.Add(new UICommand { Label = "Take photo", Id = 0 });
            useCamera.Commands.Add(new UICommand { Label = "Take video", Id = 1 });

            var useCameraRes = await useCamera.ShowAsync();

            var mediaDate = DateTime.Now.ToString("dd-MM-yyyy_H-mm-ss");

            if ((int)useCameraRes.Id == 0)
            {
                CameraCaptureUI captureUI = new CameraCaptureUI();
                captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
                captureUI.PhotoSettings.CroppedSizeInPixels = new Size(1920, 1080);

                StorageFile fileCopy = null;

                try
                {
                    StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);
                    fileCopy = await photo.CopyAsync(KnownFolders.PicturesLibrary, "helpdesk_photo_" + mediaDate + ".jpg", NameCollisionOption.GenerateUniqueName);
                }

                catch
                {
                    return;
                }

                if (fileCopy == null)
                {
                    // User cancelled photo capture
                    return;
                }
            }

            else
            {
                CameraCaptureUI captureUI = new CameraCaptureUI();
                captureUI.VideoSettings.Format = CameraCaptureUIVideoFormat.Mp4;
                captureUI.VideoSettings.MaxDurationInSeconds = 30;

                StorageFile fileCopy = null;

                try
                {
                    StorageFile videoFile = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Video);
                    fileCopy = await videoFile.CopyAsync(KnownFolders.PicturesLibrary, "helpdesk_video_" + mediaDate + ".mp4", NameCollisionOption.GenerateUniqueName);
                }

                catch
                {
                    return;
                }

                if (fileCopy == null)
                {
                    // User cancelled photo capture
                    return;
                }
            }
        }

        private async void attachButton_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".mp4");

            try
            {
                _file = await picker.PickSingleFileAsync();
                fileText.Text = _file.Name;
            }

            catch
            {
                return;
            }
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(help));
        }

        private async void submitButton_Click(object sender, RoutedEventArgs e)
        { 
            //MessageBox
            if (selectProblemButton.Content.ToString() == "choose a problem")
            {
                MessageDialog invalidProblem = new MessageDialog("You need to select a problem type before you can submit a ticket.", "Invalid problem type");
                await invalidProblem.ShowAsync();
            }

            else if (descriptionText.Text == "")
            {
                MessageDialog invalidDescription = new MessageDialog("You need to type a description before you can submit a ticket.", "You need to type a description");
                await invalidDescription.ShowAsync();
            }            

            else if (expletiveslist.expletivesArray.Contains(descriptionText.Text))
            {                
                MessageDialog expletivesDetected = new MessageDialog("There are expletives in your description. Please remove these before sending the ticket.", "Expletives detected");
                await expletivesDetected.ShowAsync();
            }

            else
            {
                //Get variables
                var submitDate = DateTime.Now.ToString();
                var problem = selectProblemButton.Content.ToString();
                var location = selectRoomButton.Content.ToString();
                var attachedFile = fileText.Text.ToString();

                string videoAttached = null;
                if (attachedFile.Contains("mp4"))
                {
                    videoAttached = "Attached video: " + attachedFile;
                }

                else
                {
                    videoAttached = "Attached photo: " + attachedFile;
                }

                //WRITE
                //Create the text file to hold the data
                Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile ticketsFile = await storageFolder.CreateFileAsync("tickets.txt", Windows.Storage.CreationCollisionOption.OpenIfExists);
                await FileIO.AppendTextAsync(ticketsFile, "\n" + "Submitted: " + submitDate + "\n" + "Problem: " + problem + "\n" + "Room: " + location + "\n" + "Description: " + descriptionText.Text + "\n" + "Priority: " + priority + "\n" + videoAttached + "\n");

                //Use stream to write to the file
                var stream = await ticketsFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);

                using (var outputStream = stream.GetOutputStreamAt(0))
                {
                    using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                    {
                        await dataWriter.StoreAsync();
                        await outputStream.FlushAsync();
                    }
                }
                stream.Dispose(); // Or use the stream variable (see previous code snippet) with a using statement as well.*/

                //READ
                //Open the text file
                stream = await ticketsFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
                ulong size = stream.Size;

                using (var inputStream = stream.GetInputStreamAt(0))
                {
                    using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
                    {
                        uint numBytesLoaded = await dataReader.LoadAsync((uint)size);
                        string savedTickets = dataReader.ReadString(numBytesLoaded);

                        ticketTextBlock.Text = savedTickets;
                    }
                }
                stream.Dispose();

                //SEND EMAIL
                string messageBody = "\n" + "Ticket submitted: " + submitDate + "\n" + "Problem: " + problem.ToUpper() + "\n" + "Room: " + location + "\n" + "Description: " + descriptionText.Text + "\n" + "Priority: " + priority + "\n" + videoAttached + "\n" + "\n" + "----------------------------------------------------------" + "\n" + "Sent from wh-at Helpdesk (for Windows 10)" + "\n" + "\n" + "You may respond to this email, it will send an email to the sender.";
                string messageTitle = problem.ToUpper() + " | " + location;

                if (_file == null)
                {
                    EmailMessage emailMessage = new EmailMessage();
                    emailMessage.To.Add(new EmailRecipient("helpdesk@wh-at.net"));
                    emailMessage.Body = messageBody;
                    emailMessage.Subject = messageTitle;
                    await EmailManager.ShowComposeNewEmailAsync(emailMessage);
                }

                else
                {
                    EmailMessage emailMessage = new EmailMessage();
                    emailMessage.To.Add(new EmailRecipient("helpdesk@wh-at.net"));
                    emailMessage.Body = messageBody;
                    emailMessage.Subject = messageTitle;

                    var emailStream = Windows.Storage.Streams.RandomAccessStreamReference.CreateFromFile(_file);
                    var attachment = new Windows.ApplicationModel.Email.EmailAttachment(
                             _file.Name,
                             emailStream);
                    emailMessage.Attachments.Add(attachment);

                    await EmailManager.ShowComposeNewEmailAsync(emailMessage);
                }
            }
        }

        private async void ticketTextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //READ
            //Open the text file
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile ticketsFile = await storageFolder.CreateFileAsync("tickets.txt", Windows.Storage.CreationCollisionOption.OpenIfExists);

            var stream = await ticketsFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
            ulong size = stream.Size;

            using (var inputStream = stream.GetInputStreamAt(0))
            {
                using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
                {
                    uint numBytesLoaded = await dataReader.LoadAsync((uint)size);
                    string savedTickets = dataReader.ReadString(numBytesLoaded);

                    ticketTextBlock.Text = savedTickets;
                }
            }
            stream.Dispose();
        }
    } 
}
  


