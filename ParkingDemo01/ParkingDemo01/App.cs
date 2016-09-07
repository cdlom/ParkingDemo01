using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ParkingDemo01
{
    public class App : Application
    {

        public App()
        {


            // componentes
            var lbLatitud = new Label
            {
                Text = "Ubicación:"
                  
             };

            var map = new Map(
                   MapSpan.FromCenterAndRadius(
                   new Position(37, -122), Distance.FromMiles(0.3)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };



            ObtenerLocalizacion( lbLatitud );


            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    //VerticalOptions = LayoutOptions.Center,
                    Children = {
           //              new Label {
            //                //HorizontalTextAlignment = TextAlignment.Center,
             //               BackgroundColor = Color.White,
               //             TextColor = Color.Red,
                //            Text = "Posición Actual"
                 //                 },
                  //       lbLatitud,
                         map

                    }
                }
            };
        }

      

        private async void ObtenerLocalizacion(Label lbLatitud)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

            lbLatitud.Text = string.Format("Time: {0} \nLat: {1} \nLong: {2} ",
            position.Timestamp, position.Latitude, position.Longitude);
            
            


        //var tmplatitude = this.FindByName<global::Xamarin.Forms.Label>("lbLatitud");
        //tmplatitude.Text = string.Format("Latitud: {0}" ,position.Latitude);


          }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
