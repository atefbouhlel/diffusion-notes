using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mooooc.Models;
using Xamarin.Forms;

namespace Mooooc.Views
{
    public partial class CourseAdd : ContentPage
    {
        public CourseAdd()
        {
            InitializeComponent();
            for (int i = 0; i < 6; i++)
            {
                SemestersPicker.Items.Add("Semstre"+(i+1));
            }
            
        }

        private async void AddCourse_Button(object sender, EventArgs e)
        {
            Course course = new Course()
            {
                Name = Name.Text,
                Credits = Convert.ToInt32(Credits.Text),
                Duration = Convert.ToInt32(Duration.Text) ,
                Semestre = SemestersPicker.SelectedIndex + 1
            };
            App._db.Insert(course);
            await DisplayAlert("Success",
                " The course "+course.Name + " is added successfully dans le semestre "+ course.Semestre,
                "OK");
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
