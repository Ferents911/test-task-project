 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions.Abstractions;
using System.Collections.ObjectModel;
using Xamarin.Forms.Maps;
using Android.Gms.Location.Places.UI;
using Android.Net;

namespace TestTask
{
    public partial class MainPage : ContentPage
    {
        public string lat;
        public string lng;
        public MainPage()
        {
            InitializeComponent();

        }




        public class info
        {
            public string sunset;
            public string sunrise;
            public string solarNoon;
            public string DayLenght;
            public string CivilTwilightBegin;
            public string CivilTwilightEnd;
            public string nautical_twilight_begin;
            public string nautical_twilight_end;
            public string astronomical_twilight_begin;
            public string astronomical_twilight_end;
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            info i = new info();
            var locator = CrossGeolocator.Current;
            var position = await locator.GetLastKnownLocationAsync();
            lat = position.Latitude.ToString();
            lng = position.Longitude.ToString();
            string url = String.Format(@"https://api.sunrise-sunset.org/json?lat={0}&lng={1}", lat, lng) ;  
            var json = new WebClient().DownloadString(url);
            JObject jo = JObject.Parse(json);
            i.sunrise = jo["results"]["sunrise"].ToString();
            i.sunset = jo["results"]["sunset"].ToString();
            i.solarNoon = jo["results"]["solar_noon"].ToString();
            i.DayLenght = jo["results"]["day_length"].ToString();
            i.CivilTwilightBegin = jo["results"]["civil_twilight_begin"].ToString();
            i.CivilTwilightEnd = jo["results"]["civil_twilight_end"].ToString();
            i.nautical_twilight_begin = jo["results"]["nautical_twilight_begin"].ToString();
            i.nautical_twilight_end = jo["results"]["nautical_twilight_end"].ToString();
            i.astronomical_twilight_begin = jo["results"]["astronomical_twilight_begin"].ToString();
            i.astronomical_twilight_end = jo["results"]["astronomical_twilight_end"].ToString();
            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
            OutputLabel.Text = "Sunrise: " + i.sunrise + "\n\r" + "Sunset: " + i.sunset + "\n\r" + "Solar noon: " + i.solarNoon + "\n\r" + "Day lenght: " + i.DayLenght + "\n\r" + "Civil twilight begin: " + i.CivilTwilightBegin + "\n\r" + "Civil twilight end: " + i.CivilTwilightEnd + "\n\r" + "Nautical twilight begin: " + i.nautical_twilight_begin + "\n\r" + "Nautical twilight end: " + i.nautical_twilight_end + "\n\r" + "Astronomical twilight begin: " + i.astronomical_twilight_begin + "\n\r" + "Astronomical twilight end: " + i.astronomical_twilight_end;
            PositionField.Text = "Latitude: " + position.Latitude.ToString() + " Lonngitude: " + position.Longitude.ToString();


        }

          private void Button_Clicked_1(object sender, EventArgs e)
         {
            info i = new info();
            var locator = CrossGeolocator.Current;
            lat = Latitude.Text.ToString();
            lng = Longitude.Text.ToString();
            Xamarin.Forms.Maps.Position pos  = new Xamarin.Forms.Maps.Position(Convert.ToDouble(lat), Convert.ToDouble(lng));
            var pin = new Pin()
            {
                Position = new Xamarin.Forms.Maps.Position(pos.Latitude, pos.Longitude),
                Label = "Your location"
            };
            string url = String.Format(@"https://api.sunrise-sunset.org/json?lat={0}&lng={1}", lat.ToString(), lng.ToString());
            var json = new WebClient().DownloadString(url);
            JObject jo = JObject.Parse(json);
            i.sunrise = jo["results"]["sunrise"].ToString();
            i.sunset = jo["results"]["sunset"].ToString();
            i.solarNoon = jo["results"]["solar_noon"].ToString();
            i.DayLenght = jo["results"]["day_length"].ToString();
            i.CivilTwilightBegin = jo["results"]["civil_twilight_begin"].ToString();
            i.CivilTwilightEnd = jo["results"]["civil_twilight_end"].ToString();
            i.nautical_twilight_begin = jo["results"]["nautical_twilight_begin"].ToString();
            i.nautical_twilight_end = jo["results"]["nautical_twilight_end"].ToString();
            i.astronomical_twilight_begin = jo["results"]["astronomical_twilight_begin"].ToString();
            i.astronomical_twilight_end = jo["results"]["astronomical_twilight_end"].ToString();
            myMap.Pins.Add(pin);
            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(Convert.ToDouble(lat), Convert.ToDouble(lng)), Distance.FromMiles(1)));
            PositionField.Text = "Latitude: " + lat.ToString() + " Lonngitude: " + lng.ToString();
            OutputLabel.Text = "Sunrise: " + i.sunrise + "\n\r" + "Sunset: " + i.sunset + "\n\r" + "Solar noon: " + i.solarNoon + "\n\r" + "Day lenght: " + i.DayLenght + "\n\r" + "Civil twilight begin: " + i.CivilTwilightBegin + "\n\r" + "Civil twilight end: " + i.CivilTwilightEnd + "\n\r" + "Nautical twilight begin: " + i.nautical_twilight_begin + "\n\r" + "Nautical twilight end: " + i.nautical_twilight_end + "\n\r" + "Astronomical twilight begin: " + i.astronomical_twilight_begin + "\n\r" + "Astronomical twilight end: " + i.astronomical_twilight_end;
         }
    }
}