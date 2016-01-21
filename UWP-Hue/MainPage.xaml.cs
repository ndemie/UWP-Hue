using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Hue
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
            NavFrame.Navigated += OnNavigated;

            NavFrame.Navigate(typeof(ListPage));
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (NavFrame != null && NavFrame.CanGoBack)
            {
                e.Handled = true;
                NavFrame.GoBack();
            }
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            if (e.Parameter != null && NavFrame.CanGoBack)
            {
                PageTitle.Text = e.Parameter.ToString();
            } else
            {
                PageTitle.Text = "Hue UWP";
            }
        }
    }
}
