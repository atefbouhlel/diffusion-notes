using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mooooc.Models;
using Xamarin.Forms;

namespace Mooooc.Views
{   
    public partial class TeachersShow : ContentPage
    {
        private List<Teacher> Teachers = new List<Teacher>();
        public TeachersShow()
        {
            InitializeComponent();

            var teachers = App._db.Table<Teacher>().ToList();

            Teachers = teachers;
            TeachersListView.ItemsSource = teachers;
        }

        private async void TeachersItemTapped(object sender, ItemTappedEventArgs e)
        {
            var teacher = e.Item as Teacher;

            await DisplayAlert("Teacher Tapped",
                teacher.FirstName+" "+teacher.LastName,
                "OK");

        }


        private void SearchTeachers_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var keywords = searchTeachers.Text;

            TeachersListView.ItemsSource = Teachers.Where(teacher =>
                                    teacher.LastName.ToLower().Contains(keywords.ToLower()) || teacher.FirstName.ToLower().Contains(keywords.ToLower()));
        }

        private async void AccueilPage_Button(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Accueil());
        }

        private async void LogOut_Button(object sender, EventArgs e)
        {
            App.CurrentUser = null;
            App.UserType = 0;
            await Navigation.PushAsync(new Authentication());
        }

        private async void StudentsPage_Button(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StudentsShow());
        }

        private async void TeachersPage_Button(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TeachersShow());
        }

        private async void CoursesPage_Button(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoursesShow());
        }
    }
}
