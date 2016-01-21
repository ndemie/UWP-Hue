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
using UWP_Hue.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_Hue
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailPage : Page
    {
        public Light chosenLight;
        List<Light> lightsList = HueStore.Instance.lights;
        private bool loadingPage = true;
        public DetailPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var lightId = (int)e.Parameter;

            chosenLight = lightsList.Find(x => x.Id == lightId);

            if (chosenLight != null)
            {
                toggleSwitch.IsOn = chosenLight.On;
                hue.Value = chosenLight.Hue;
                saturation.Value = chosenLight.Saturation;
                brightness.Value = chosenLight.Brightness;
            }

            loadingPage = false;
        }

        private async void toggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (!loadingPage)
            {
                var state = e.OriginalSource as ToggleSwitch;
                string jsonString = "{\"on\":" + state.IsOn.ToString() + ",\"transitiontime\":0,\"bri\":" + brightness.Value + "}";
                await HueAPIHelper.putLightChanges(jsonString.ToLowerInvariant(), chosenLight.Id);
            }
        }

        private async void saturation_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (!loadingPage)
            {
                var jsonString = "{\"sat\":" + e.NewValue + ",\"transitiontime\":0}";
                await HueAPIHelper.putLightChanges(jsonString, chosenLight.Id);
            }
        }

        private async void hue_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (!loadingPage) {
                var jsonString = "{\"hue\":" + e.NewValue + ",\"transitiontime\":0}";
                await HueAPIHelper.putLightChanges(jsonString, chosenLight.Id);
            }
            
        }

        private async void brightness_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (!loadingPage) {
                var jsonString = "{\"bri\":" + e.NewValue + ",\"transitiontime\":0}";
                await HueAPIHelper.putLightChanges(jsonString, chosenLight.Id);
            }
        }
    }
}
