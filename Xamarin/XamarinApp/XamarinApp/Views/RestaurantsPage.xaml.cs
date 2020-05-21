using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantsPage : ContentPage
    {
        public RestaurantsPage()
        {
            InitializeComponent();
            BindingContext = new RestaurantsPageViewModel();
        }

        async private void grd_restaurants_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as RestaurantModel;
            if (item == null)
                return;

            await Navigation.PushAsync(new RestaurantDetailPage(new RestaurantDetailPageViewModel(item)));
            grd_restaurants.SelectedItem = null;
        }
    }
}