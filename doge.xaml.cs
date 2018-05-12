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

//PAGE: doge.xaml.cs
//DESCRIPTION: This is an Easter Egg page that serves no purpose other than to be funny. It's a 'doge' description of the helpdesk app, based on the popular internet meme that typically consists of a picture of a Shiba Inu accompanied by multicolored text in Comic Sans font in the foreground. The text, representing a kind of internal monologue, is deliberately written in a form of broken English.
//AUTHORED BY: Jason Brown
//BUILD: 130.01
//LAST MODIFIED: February 09 2016 

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace wh_at_Helpdesk__for_Windows_10_
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class doge : Page
    {
        public doge()
        {
            this.InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
