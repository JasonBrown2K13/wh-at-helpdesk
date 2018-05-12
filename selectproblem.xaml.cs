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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace wh_at_Helpdesk__for_Windows_10_
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class selectproblem : Page
    {
        public selectproblem()
        {
            this.InitializeComponent();
            ProblemListView.SelectedIndex = -1;
            //ProblemListView.SelectionMode = ListViewSelectionMode.None;

            this.NavigationCacheMode = NavigationCacheMode.Required;

            SetItemSource();
        }
        private void SetItemSource()
        {
            List<ProblemList> source = new List<ProblemList>();
            //General 
            source.Add(new ProblemList("assembly", "general"));

            //Internet
            source.Add(new ProblemList("main network", "internet & network"));
            source.Add(new ProblemList("wi-fi", "internet & network"));
            source.Add(new ProblemList("logging in", "internet & network"));
            source.Add(new ProblemList("accessing files", "internet & network"));

            //Peripherals
            source.Add(new ProblemList("printers", "peripherals"));
            source.Add(new ProblemList("projectors", "peripherals"));
            source.Add(new ProblemList("whiteboards", "peripherals"));
            source.Add(new ProblemList("sound", "peripherals"));
            source.Add(new ProblemList("mice", "peripherals"));
            source.Add(new ProblemList("keyboards", "peripherals"));
    
            //Computers
            source.Add(new ProblemList("computer not starting", "computers"));
            source.Add(new ProblemList("computer running slow", "computers"));
            source.Add(new ProblemList("surfaces & trollies", "computers"));
            source.Add(new ProblemList("school laptops", "computers"));
            source.Add(new ProblemList("software request", "computers"));

            //Office 365
            source.Add(new ProblemList("metro central", "office 365"));
            source.Add(new ProblemList("onedrive", "office 365"));
            source.Add(new ProblemList("yammer", "office 365"));
            source.Add(new ProblemList("e-mails", "office 365"));
            source.Add(new ProblemList("office online", "office 365"));
            source.Add(new ProblemList("onenote", "office 365"));
            source.Add(new ProblemList("office 365 other", "office 365"));

            //Other
            source.Add(new ProblemList("other", "other"));

            List<AlphaKeyGroup<ProblemList>> itemSource = AlphaKeyGroup<ProblemList>.CreateGroups(source,
                CultureInfo.CurrentUICulture,
                s => s.ProblemName, true);

            ((CollectionViewSource)Resources["ProblemGroups"]).Source = itemSource;
        }

        private void ProblemListView_Tapped(object sender, RoutedEventArgs e)
        {
            string selectedProblem = ProblemListView.SelectedItem.ToString();

            //MessageDialog showProblem = new MessageDialog(selectedProblem);
            //await showProblem.ShowAsync();

            string selectproblemButtonText = selectedProblem;
            Frame.Navigate(typeof(helpdesk), selectproblemButtonText);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

    }
}
