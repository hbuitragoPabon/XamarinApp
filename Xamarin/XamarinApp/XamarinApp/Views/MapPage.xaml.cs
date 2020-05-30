using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public MapPage(string nombre, string direccion, double latitud, double longitud)
        {

            Nombre = nombre;
            Direccion = direccion;
            Latitud = latitud;
            Longitud = longitud;
            InitializeComponent();

            SetPin();

        }

        private void SetPin()
        {
            var positiion = new Position(Latitud, Longitud);
            var pin = new Pin
            {
                Label = Nombre,
                Address = Direccion,
                Type = PinType.Place,
                Position = positiion
            };
            map.Pins.Add(pin);

            MapSpan mapSpan = MapSpan.FromCenterAndRadius(positiion, Distance.FromKilometers(0.5));
            map.MoveToRegion(mapSpan);
        }

        async private void btn_Close_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }
    }
}