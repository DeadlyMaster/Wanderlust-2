using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Essentials;

namespace Wanderlust.Essentials
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsPage : ContentPage
    {
        public MapsPage()
        {
            InitializeComponent();
        }

        private void ButtonOpenCoords_Clicked(object sender, EventArgs e)
        {
            if (!double.TryParse(EntryLatitude.Text, out double lat))
                return;

            if (!double.TryParse(EntryLongitude.Text, out double lng))
                return;

            Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                Name = EntryName.Text,
                NavigationMode = NavigationMode.Driving
            });
        }
    }
}