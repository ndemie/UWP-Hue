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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI;
using System.Threading.Tasks;
using UWP_Hue.Models;
using System.Collections.ObjectModel;
using Windows.UI.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_Hue
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListPage : Page
    {
        ContentDialog dialog;
        public ObservableCollection<Light> lightcollection { get; set; }
        List<Light> lightsList = HueStore.Instance.lights;

        public ListPage()
        {
            this.InitializeComponent();

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

            showDialog();

            checkForStatusChange();

            lightcollection = new ObservableCollection<Light>();
        }

        private async void showDialog()
        {
            dialog = new ContentDialog()
            {
                Title = "Authenticeren met de Hue Bridge",
                MaxWidth = this.ActualWidth,
                Background = new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0xff, 0xff))
            };

            var panel = new StackPanel();

            panel.Children.Add(new TextBlock
            {
                Text = "Druk op de link knop op uw Hue om verbinding te maken.",
                TextWrapping = TextWrapping.Wrap
            });

            BitmapImage bitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/smartbridge.jpg"));

            panel.Children.Add(new Image
            {
                Source = bitmapImage
            });

            dialog.Content = panel;
            var result = await dialog.ShowAsync();
        }

        private async void checkForStatusChange()
        {
            var status = await checkStatus();

            if (status == true)
            {
                dialog.Hide();

                getLights();
            }
        }

        private async Task<Boolean> checkStatus()
        {
            Boolean loginStatus = false;
            while(loginStatus == false)
            {
                var result = await HueAPIHelper.getUsernameCredentials();

                if (result == true) {
                    loginStatus = result;
                }
            }

            return loginStatus;
        }

        private async void getLights()
        {
            Task t = HueAPIHelper.parseLights(lightcollection);
            await t;
        }

        private void LightsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedLight = (Light)e.ClickedItem;

            string lightName = selectedLight.Name;

            this.Frame.Navigate(typeof(DetailPage), lightName);
        }
    }
}
