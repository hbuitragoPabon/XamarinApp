using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

#if DEBUG
            txtEmail.Text = "admin@admin.com";
            txtPassword.Text = "admin";
#endif
        }

        async private void btn_login_Clicked(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if(email == "admin@admin.com" && password == "admin")
            {
                //correcta
                await this.Navigation.PushModalAsync(new HomePage());
            }
            else
            {
               await this.DisplayAlert("Campos incorrectos", "Email o password incorrecto", "Aceptar");
            }

        }
    }
}