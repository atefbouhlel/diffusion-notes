using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Mooooc.Models;
using Mooooc.Views;
using SQLite;
using Xamarin.Forms;
using XamarinForms.SQLite;
using XamarinForms.SQLite.SQLite;

namespace Mooooc
{
    public class App : Application
    {
        public static SQLiteConnection _db = DependencyService.Get<ISQLite>().GetConnection();
        public static IUser CurrentUser;
        public static int UserType;
        public App()
        {
            MainPage = new NavigationPage(new Authentication());
            //deleteAllTables();
            //checkTables();
        }

        private void deleteAllTables()
        {
            _db.DropTable<Student>();
            _db.DropTable<Teacher>();
            _db.DropTable<Admin>();
            _db.DropTable<Course>();
            _db.DropTable<Degree>();
            _db.DropTable<StudentCourse>();
            _db.DropTable<TeacherCourse>();
        }

        private void checkTables()
        {
            var existStudent = _db.GetTableInfo("Student");
            if (existStudent.Count == 0)
            {
                _db.CreateTable<Student>();
                App._db.Insert(new Student
                {
                    LastName = "Bouhlel",
                    FirstName = "Atef",
                    Username = "atef.bouhlel",
                    Password = "1234"
                });

                App._db.Insert(new Student
                {
                    LastName = "Bow",
                    FirstName = "Danny",
                    Username = "danny.bow",
                    Password = "1234"
                });

                App._db.Insert(new Student
                {
                    LastName = "Martin",
                    FirstName = "Vincent",
                    Username = "vincent.martin",
                    Password = "1234"
                });

            }

            //
            var existTeacher = _db.GetTableInfo("Teacher");
            if (existTeacher.Count == 0)
            {
                _db.CreateTable<Teacher>();
                App._db.Insert(new Teacher
                {
                    LastName = "Bertin",
                    FirstName = "Julien",
                    Username = "julien.bertin",
                    Password = "1234"
                });
                App._db.Insert(new Teacher
                {
                    LastName = "Florian",
                    FirstName = "Gerrard",
                    Username = "gerrard.florian",
                    Password = "1234"
                });

                App._db.Insert(new Teacher
                {
                    LastName = "Katar",
                    FirstName = "Simon",
                    Username = "simon.katar",
                    Password = "1234"
                });

            }
            /***************/
            var existAdmin = _db.GetTableInfo("Admin");
            if (existAdmin.Count == 0)
            {
                _db.CreateTable<Admin>();
                App._db.Insert(new Admin
                {
                    LastName = "Hu",
                    FirstName = "Guillaume",
                    Username = "admin",
                    Password = "1234"
                });

            }
            //
            var existCourse = _db.GetTableInfo("Course");
            if (existCourse.Count == 0)
            {
                _db.CreateTable<Course>();
                _db.Insert(new Course
                {
                    Name= "Mathématiques Analyse Données",
                    Credits=15,
                    Duration = 35,
                    Semestre = 3 
                });

                _db.Insert(new Course
                {
                    Name = "Informatique Language Objet",
                    Credits = 15,
                    Duration = 35,
                    Semestre = 2
                });

                _db.Insert(new Course
                {
                    Name = "Informatique Base Données",
                    Credits = 15,
                    Duration = 35,
                    Semestre = 1
                });

                _db.Insert(new Course
                {
                    Name = "Programmation Avancée Projet",
                    Credits = 15,
                    Duration = 35,
                    Semestre = 3
                });
            }
            //
            var existTeacherCourse = _db.GetTableInfo("TeacherCourse");
            if (existTeacherCourse.Count == 0)
            {
                _db.CreateTable<TeacherCourse>();
                TeacherCourse teacherCourse1 = new TeacherCourse()
                {
                    TeacherId = 1,
                    CourseId = 1
                };
                App._db.Insert(teacherCourse1);

                TeacherCourse teacherCourse2 = new TeacherCourse()
                {
                    TeacherId = 1,
                    CourseId = 2
                };
                App._db.Insert(teacherCourse2);

                TeacherCourse teacherCourse3 = new TeacherCourse()
                {
                    TeacherId = 2,
                    CourseId = 2
                };
                App._db.Insert(teacherCourse3);

            }
            /**********/
            var existStudentCourse = _db.GetTableInfo("StudentCourse");
            if (existStudentCourse.Count == 0)
            {
                _db.CreateTable<StudentCourse>();
                StudentCourse sc1 = new StudentCourse()
                {
                    StudentId = 1,
                    CourseId = 1
                };
                App._db.Insert(sc1);

                StudentCourse sc2 = new StudentCourse()
                {
                    StudentId = 1,
                    CourseId = 2
                };
                App._db.Insert(sc2);

                StudentCourse sc3 = new StudentCourse()
                {
                    StudentId = 2,
                    CourseId = 1
                };
                App._db.Insert(sc3);

                StudentCourse sc4 = new StudentCourse()
                {
                    StudentId = 2,
                    CourseId = 3
                };
                App._db.Insert(sc4);

                StudentCourse sc5 = new StudentCourse()
                {
                    StudentId = 3,
                    CourseId = 3
                };
                App._db.Insert(sc5);

                StudentCourse sc6 = new StudentCourse()
                {
                    StudentId = 3,
                    CourseId = 1
                };
                App._db.Insert(sc6);

            }

            /*********/
            var existDegree = _db.GetTableInfo("Degree");
            if (existDegree.Count == 0)
            {
                _db.CreateTable<Degree>();
                Degree d = new Degree()
                {
                    StudentId = 1,
                    CourseId = 1,
                    Name = "Assists(20%)",
                    Value = 17
                };
                App._db.Insert(d);

                Degree d2 = new Degree()
                {
                    StudentId = 1,
                    CourseId = 1,
                    Name = "CC (40%)",
                    Value = 15
                };
                App._db.Insert(d2);

                Degree d3 = new Degree()
                {
                    StudentId = 1,
                    CourseId = 1,
                    Name = "Exam (40%)",
                    Value = 10
                };
                App._db.Insert(d3);
            }
        }
        

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
