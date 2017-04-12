using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mooooc.Models;
using Xamarin.Forms;

namespace Mooooc.Views
{
    public partial class Authentication : ContentPage
    {
        public Authentication()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var user =  App._db.Table<Student>().Where(s => s.Username.Equals(Username.Text) && s.Password.Equals(Password.Text));
            
            if (!user.Any())
            {
                var user2 = App._db.Table<Teacher>()
                        .Where(t => t.Username.Equals(Username.Text) && t.Password.Equals(Password.Text));
                if (!user2.Any())
                {
                    var user3 = App._db.Table<Admin>()
                        .Where(t => t.Username.Equals(Username.Text) && t.Password.Equals(Password.Text));
                    if (!user3.Any())
                        await DisplayAlert("Alert", "Username Or Password Incorrect", "OK");
                    else
                    {
                        App.CurrentUser = user3.First();
                        App.UserType = 3;
                        await Navigation.PushAsync(new Accueil());
                    }
                }
                else
                {
                    App.CurrentUser = user2.First();
                    App.UserType = 2;
                    await Navigation.PushAsync(new Accueil());
                }
            }
            else
            {
                App.CurrentUser = user.First();
                App.UserType = 1;
                await Navigation.PushAsync(new Accueil());
            }
        }
    }
}
