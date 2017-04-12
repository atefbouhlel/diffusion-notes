﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mooooc.Models;
using Xamarin.Forms;

namespace Mooooc.Views
{
    public partial class TeacherAdd : ContentPage
    {
        public TeacherAdd()
        {
            InitializeComponent();
        }

        private void AddTeacher_Button(object sender, EventArgs e)
        {
            
            Teacher teacher = new Teacher()
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Username = Username.Text,
                Password = Password.Text
            };
            App._db.Insert(teacher);
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
