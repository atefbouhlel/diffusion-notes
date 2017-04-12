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
    public partial class CoursesShow : ContentPage
    {
        private List<Course> Courses = new List<Course>();
        public CoursesShow()
        {
            InitializeComponent();

            var courses = App._db.Table<Course>().ToList();

            if (App.UserType == 1)
            {
                foreach (var course in courses)
                {
                    foreach (var student in course.Students)
                    {
                        if (student.ID == App.CurrentUser.ID)
                        {
                            Courses.Add(course);
                        }
                    }

                }
            }
            else if (App.UserType == 2)
            {
                foreach (var course in courses)
                {
                    foreach (var teacher in course.Teachers)
                    {
                        if (teacher.ID == App.CurrentUser.ID)
                        {
                            Courses.Add(course);
                        }
                    }
                    
                }
            }
            else
            {
                Courses = courses;
            }
            
            CoursesListView.ItemsSource = Courses;
        }

        private async void CoursesItemTapped(object sender, ItemTappedEventArgs e)
        {
            var course = e.Item as Course;

            await Navigation.PushAsync(new CourseShow(course));
            //await DisplayAlert("Course Tapped",course.Name,"OK");

        }


        private void SearchCourses_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var keywords = searchCourses.Text;

            CoursesListView.ItemsSource = Courses.Where(course =>
                                    course.Name.ToLower().Contains(keywords.ToLower()));
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
