using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mooooc.Models;
using Xamarin.Forms;

namespace Mooooc.Views
{
    public partial class StudentsShow : ContentPage
    {
        private List<Student> Students = new List<Student>();
        public StudentsShow()
        {
            InitializeComponent();
            
            var students = App._db.Table<Student>().ToList();

            Students = students;
            StudentsListView.ItemsSource = students;
        }

        private async void StudentsItemTapped(object sender, ItemTappedEventArgs e)
        {
            var student = e.Item as Student;

            await DisplayAlert("Student Tapped",
                " Student: " + student.LastName,
                "OK");

        }


        private void SearchStudents_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var keywords = searchStudents.Text;

            StudentsListView.ItemsSource = Students.Where(student =>
                                    student.LastName.ToLower().Contains(keywords.ToLower()) || student.FirstName.ToLower().Contains(keywords.ToLower()));
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
