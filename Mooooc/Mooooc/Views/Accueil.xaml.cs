using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mooooc.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mooooc.Views
{
    public partial class Accueil : ContentPage
    {
        public Accueil()
        {
            InitializeComponent();
            Student s;
            Teacher t;
            Admin admin;
            
            int type = App.UserType;
            if (type == 1)
            {
                s = (Student) App.CurrentUser;
                t = null;
                admin = null;
                UserName.Text = "Hello " + s.FirstName + " "+ s.LastName;
                DegreesList.IsVisible = true;
                TeachersList.IsVisible = true;
                CoursesList.IsVisible = true;
            }
            else if (type == 2)
            {
                t = (Teacher)App.CurrentUser;
                s = null;
                admin = null;
                UserName.Text = "Hello " + t.FirstName + " " + t.LastName;

                CoursesList.Text = "My Courses";
                CoursesList.IsVisible = true;
            }
            else
            {
                admin = (Admin)App.CurrentUser;
                t = null;
                s = null;
                UserName.Text = "Hello " + admin.FirstName + " " + admin.LastName;

                CoursesList.Text = "Courses";
                CoursesList.IsVisible = true;

                StudentAdd.IsVisible = true;
                StudentsList.IsVisible = true;
                TeacherAdd.IsVisible = true;
                TeachersList.IsVisible = true;
                CourseAdd.IsVisible = true;
                CoursesList.IsVisible = true;
            }
        }

        

        private async void ShowDegrees_Button(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Degrees().GetPage());
        }
        private async void AddStudent_Button(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StudentAdd());
        }

        private async void ShowStudents_Button(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StudentsShow());
        }

        private async void AddTeacher_Button(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TeacherAdd());
        }

        private async void ShowTeachers_Button(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TeachersShow());
        }

        private async void AddCourse_Button(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CourseAdd());
        }

        private async void ShowCourses_Button(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoursesShow());
        }

        private async void LogOut_Button(object sender, EventArgs e)
        {
            App.CurrentUser = null;
            App.UserType = 0;
            await Navigation.PushAsync(new Authentication());
        }
    }
}
