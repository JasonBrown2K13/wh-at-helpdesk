using System;
using System.Collections.Generic;
using System.Globalization;
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

//PAGE: selectroom.xaml.cs
//DESCRIPTION: On this page the user selects a room to tell the technicians the location of the problem. Choosing a room is optional because some problems may not be room specific. 
//AUTHORED BY: Jason Brown
//BUILD: 130.01
//LAST MODIFIED: February 09 2016 

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace wh_at_Helpdesk__for_Windows_10_
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class selectroom : Page
    {
        public selectroom()
        {
            this.InitializeComponent();
            RoomListView.SelectedIndex = -1;
            //RoomListView.SelectionMode = ListViewSelectionMode.None;

            this.NavigationCacheMode = NavigationCacheMode.Required;

            SetItemSource();
        }
        private void SetItemSource()
        {
            List<RoomList> source = new List<RoomList>();
            //North Rooms - Classrooms   
            source.Add(new RoomList("N01", "North"));
            source.Add(new RoomList("N02", "North"));
            source.Add(new RoomList("N03", "North"));
            source.Add(new RoomList("N04", "North"));
            source.Add(new RoomList("N05", "North"));
            source.Add(new RoomList("N06", "North"));
            source.Add(new RoomList("N07", "North"));
            source.Add(new RoomList("N08", "North"));
            source.Add(new RoomList("N09", "North"));
            source.Add(new RoomList("N10", "North"));
            source.Add(new RoomList("N11", "North"));
            source.Add(new RoomList("N12", "North"));
            source.Add(new RoomList("N13", "North"));
            source.Add(new RoomList("N14", "North"));
            source.Add(new RoomList("N15", "North"));
            source.Add(new RoomList("N16", "North"));
            source.Add(new RoomList("N17", "North"));
            source.Add(new RoomList("N18", "North"));
            source.Add(new RoomList("N19", "North"));
            source.Add(new RoomList("N20", "North"));
            source.Add(new RoomList("N21", "North"));

            //North Rooms - Offices
            source.Add(new RoomList("Reception", "North"));
            source.Add(new RoomList("Data Office", "North"));
            source.Add(new RoomList("Sick Bay", "North"));
            source.Add(new RoomList("IAG/Careers Office", "North"));
            source.Add(new RoomList("Principal's Office", "North"));
            source.Add(new RoomList("Conference Room", "North"));
            source.Add(new RoomList("Reprographics Office", "North"));
            source.Add(new RoomList("Attendance Office", "North"));
            source.Add(new RoomList("Finance Office", "North"));
            source.Add(new RoomList("SENCO Office", "North"));
            source.Add(new RoomList("ICT Strategy Office", "North"));
            source.Add(new RoomList("Personnel Office", "North"));
            source.Add(new RoomList("Exams Office", "North"));
            source.Add(new RoomList("School Counsellor", "North"));
            source.Add(new RoomList("North Hall", "North"));
            source.Add(new RoomList("Site Office", "North"));
            source.Add(new RoomList("IEU", "North"));
            source.Add(new RoomList("Abbey House Office", "North"));
            source.Add(new RoomList("Cheshire House Office", "North"));
            source.Add(new RoomList("Ellis House Office", "North"));
            source.Add(new RoomList("MacMillan House Office", "North"));
            source.Add(new RoomList("Hub", "North"));
            source.Add(new RoomList("Jackie Everett's Office", "North"));
            source.Add(new RoomList("Ian Cook's Office", "North"));
            source.Add(new RoomList("North Staff Room", "North"));
            source.Add(new RoomList("Cover Manager", "North"));
            source.Add(new RoomList("Gateway", "North"));
            source.Add(new RoomList("Computing/IT Office", "North"));

            //East Rooms - Classrooms
            source.Add(new RoomList("E01", "East"));
            source.Add(new RoomList("E02", "East"));
            source.Add(new RoomList("E03", "East"));
            source.Add(new RoomList("E04", "East"));
            source.Add(new RoomList("E05", "East"));
            source.Add(new RoomList("E06", "East"));
            source.Add(new RoomList("E07", "East"));
            source.Add(new RoomList("E08", "East"));
            source.Add(new RoomList("E09", "East"));
            source.Add(new RoomList("E10", "East"));

            //East Rooms - Offices
            source.Add(new RoomList("Art Department Office", "East"));
            source.Add(new RoomList("History Department Office", "East"));

            //Middle Rooms - Classrooms
            source.Add(new RoomList("MA", "Mobile"));
            source.Add(new RoomList("MB", "Mobile"));
            source.Add(new RoomList("M01", "Middle"));
            source.Add(new RoomList("M02", "Middle"));
            source.Add(new RoomList("M03", "Middle"));
            source.Add(new RoomList("M04", "Middle"));
            source.Add(new RoomList("M05", "Middle"));
            source.Add(new RoomList("M06", "Middle"));
            source.Add(new RoomList("M07", "Middle"));
            source.Add(new RoomList("M08", "Middle"));
            source.Add(new RoomList("M09", "Middle"));
            source.Add(new RoomList("M10", "Middle"));
            source.Add(new RoomList("M11", "Middle"));
            source.Add(new RoomList("M12", "Middle"));
            source.Add(new RoomList("M13", "Middle"));
            source.Add(new RoomList("M14", "Middle"));
            source.Add(new RoomList("M15", "Middle"));
            source.Add(new RoomList("M16", "Middle"));
            source.Add(new RoomList("M17", "Middle"));
            source.Add(new RoomList("M18", "Middle"));
            source.Add(new RoomList("M19", "Middle"));
            source.Add(new RoomList("M20", "Middle"));
            source.Add(new RoomList("M21", "Middle"));
            source.Add(new RoomList("M22", "Middle"));
            source.Add(new RoomList("M23", "Middle"));
            source.Add(new RoomList("M24", "Middle"));
            source.Add(new RoomList("M25", "Middle"));
            source.Add(new RoomList("M26", "Middle"));
            source.Add(new RoomList("M27", "Middle"));
            source.Add(new RoomList("M28", "Middle"));
            source.Add(new RoomList("M29", "Middle"));
            source.Add(new RoomList("M30", "Middle"));
            source.Add(new RoomList("M31", "Middle"));
            source.Add(new RoomList("M32", "Middle"));
            source.Add(new RoomList("M33", "Middle"));

            //Middle Rooms - Offices
            source.Add(new RoomList("Student Services", "Middle"));
            source.Add(new RoomList("Tech Office", "Middle"));
            source.Add(new RoomList("Middle Staff Room", "Middle"));

            //South Rooms - Classrooms
            source.Add(new RoomList("S01", "South"));
            source.Add(new RoomList("S02", "South"));
            source.Add(new RoomList("S03", "South"));
            source.Add(new RoomList("S04", "South"));
            source.Add(new RoomList("S05", "South"));
            source.Add(new RoomList("S07", "South"));
            source.Add(new RoomList("S08", "South"));
            source.Add(new RoomList("S09", "South"));
            source.Add(new RoomList("S10", "South"));
            source.Add(new RoomList("S11", "South"));
            source.Add(new RoomList("S12", "South"));
            source.Add(new RoomList("S13", "South"));
            source.Add(new RoomList("S14", "South"));
            source.Add(new RoomList("S15", "South"));
            source.Add(new RoomList("S16", "South"));
            source.Add(new RoomList("S17", "South"));
            source.Add(new RoomList("S18", "South"));
            source.Add(new RoomList("S19", "South"));
            source.Add(new RoomList("S20", "South"));
            source.Add(new RoomList("S25", "South"));
            source.Add(new RoomList("S26", "South"));
            source.Add(new RoomList("S27", "South"));

            //South Rooms - Offices
            source.Add(new RoomList("CLC", "South"));
            source.Add(new RoomList("Library", "South"));
            source.Add(new RoomList("Science Technicians", "South"));
            source.Add(new RoomList("Sixth Form Study Area", "South"));
            source.Add(new RoomList("Jeremy Dickson's Office", "South"));
            source.Add(new RoomList("Recording Studio", "South"));
            source.Add(new RoomList("Drama Studio", "South"));
            source.Add(new RoomList("Arts Office", "South"));
            source.Add(new RoomList("PE Office", "South"));
            source.Add(new RoomList("Adrian Fehners' Office", "South"));
            source.Add(new RoomList("South Staff Room", "South"));

            List<AlphaKeyGroup<RoomList>> itemSource = AlphaKeyGroup<RoomList>.CreateGroups(source,
                CultureInfo.CurrentUICulture,
                s => s.RoomName, true);

            ((CollectionViewSource)Resources["RoomGroups"]).Source = itemSource;
        }

        private async void RoomListView_Tapped(object sender, RoutedEventArgs e)
        { 
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile roomFile = await storageFolder.CreateFileAsync("room.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(roomFile, RoomListView.SelectedItem.ToString());

            Frame.GoBack();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
