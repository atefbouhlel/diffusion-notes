using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mooooc.Models;
using Xamarin.Forms;

namespace Mooooc.Views
{
    public partial class CourseShow : ContentPage
    {
        private List<int> index = new List<int>();
        private Course currentCourse;
        public CourseShow(Course course)
        {

            InitializeComponent();
            currentCourse = course;
            int i = 0;

            var teachers = App._db.Query<Teacher>("SELECT * from [Teacher] Order By [LastName]");
            TeacherPicker.Title = "Choose a teacher..";
            foreach (var t in teachers)
            {
                TeacherPicker.Items.Add(t.LastName.ToUpper() + " " + t.FirstName);
                index.Insert(i, t.ID);
                i++;
            }


            if (App.UserType == 2)
            {
                AddDegreesStack.IsVisible = true;
            }

            if (App.UserType == 1 || App.UserType == 2)
            {
                TeachersListView.ItemTapped += async (sender, e) =>
                {
                    var selected = sender as ListView;
                    if (selected != null)
                    {
                        var item = selected.SelectedItem as Teacher;

                        var choice = await DisplayActionSheet("Choose", "Annuler", null, "Show details");
                        switch (choice)
                        {
                            case "Show details":
                                await Navigation.PushAsync(new TeacherShow(item));
                                break;
                            default:
                                break;
                        }
                    }
                };
            }
            if (App.UserType == 3)
            {
                TeachersListView.ItemTapped += async (sender, e) =>
                {
                    var selected = sender as ListView;
                    if (selected != null)
                    {
                        var item = selected.SelectedItem as Teacher;

                        var choice = await DisplayActionSheet("Choose", "Annuler", null, "Show details", "Delete");
                        switch (choice)
                        {
                            case "Show details":
                                await Navigation.PushAsync(new TeacherShow(item));
                                break;
                            case "Delete":
                                currentCourse.DeleteTeacher(item.ID);
                                TeachersListView.ItemsSource = currentCourse.Teachers;

                                break;
                            default:
                                break;
                        }
                    }
                };
                AddTeacherStack.IsVisible = true;
            }
                

            TeachersListView.ItemsSource = course.Teachers;
            StudentsListView.ItemsSource = currentCourse.Students.ToList();
        }

        
        private async void AddDegrees_Button(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DegreesAdd().GetPage(currentCourse));
        }
        private async void AddTeacherCourse_Button(object sender, EventArgs e)
        {
            TeacherCourse teacherCourse = new TeacherCourse()
            {
                TeacherId = index.ElementAt(TeacherPicker.SelectedIndex),
                CourseId = currentCourse.ID
            };
            App._db.Insert(teacherCourse);
            TeachersListView.ItemsSource = currentCourse.Teachers;
            await DisplayAlert("Succes",
               " The teacher is Added to this course !",
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
