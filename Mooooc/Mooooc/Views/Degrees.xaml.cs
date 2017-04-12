using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mooooc.Models;
using Xamarin.Forms;
using XamarinForms.SQLite;

namespace Mooooc.Views
{
    public partial class Degrees : ContentPage
    {

        public Degrees()
        {
            InitializeComponent();
            
        }

        public TabbedPage GetPage()
        {
            var page = new TabbedPage()
            {
                Title = "My Degrees "
            };
            var user = (Student) App.CurrentUser; 
            foreach (var course in user.GetCourses())
            {
                var contentPage = new ContentPage
                {
                    Title = course.GetAbbreviation(),
                    Content = new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        Padding = new Thickness(20),
                        Children =
                        {
                            new StackLayout {
                                Orientation = StackOrientation.Horizontal,
                                Padding = new Thickness(20),
                                Children = {
                                    new Label{Text = "Assists(20%): ",FontSize = 25}, new Label{Text = user.GetDegrees(course.ID).ElementAt(0).Value.ToString(),FontSize = 25}}
                            },
                            new StackLayout {
                                Orientation = StackOrientation.Horizontal,
                                Padding = new Thickness(20),
                                Children = {new Label{Text = "CC (40%): ",FontSize = 25}, new Label{Text = user.GetDegrees(course.ID).ElementAt(1).Value.ToString(), FontSize = 25}}
                                },
                            new StackLayout {
                                Orientation = StackOrientation.Horizontal,
                                Padding = new Thickness(20),
                                Children = {new Label{Text = "Exam (40%):  ",FontSize = 25}, new Label{Text = user.GetDegrees(course.ID).ElementAt(2).Value.ToString(), FontSize = 25}}
                                },
                            new StackLayout {
                                Orientation = StackOrientation.Horizontal,
                                Padding = new Thickness(20),
                                Children = {new Label{Text = "The average:  ", FontSize = 25},
                                    new Label{Text = (((user.GetDegrees(course.ID).ElementAt(0).Value)+( user.GetDegrees(course.ID).ElementAt(1).Value * 2)+(user.GetDegrees(course.ID).ElementAt(0).Value * 2))/5).ToString(),
                                        FontSize = 25}}
                            }
                        }
                    }
                };

                page.Children.Add(contentPage);
            }


            var contentPage2 = new ContentPage
            {
                Title = "Page2",
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "IBD",
                            FontSize = 30
                        },
                        new StackLayout
                        {
                            Orientation = StackOrientation.Vertical,
                            Margin = new Thickness(30),
                            Children =
                            {
                                new Label
                                {
                                    Text = "Teachers",
                                    FontSize = 25
                                },
                                new Label
                                {
                                    Text = "Degrees",
                                    FontSize = 25
                                }
                            }
                        }
                    }
                }
            };


            return page;
        }

        /*public CarouselPage GetPage()
        {
            var emptyPage = new ContentPage
            {
                Title = "There is no degree yet",
            };
              

            
            var teacherLabel = new Label
            {
                Text = "Teacher1",
                FontSize = 15
            };

            List<Degree> degrees = new List<Degree>();
            var res = App._db.Table<Degree>().Where(d => d.StudentId.Equals(App.CurrentUser.ID)).ToList();
            foreach (var x in res)
            {
                degrees.Add(x);
            }
            var listView = new ListView
            {
                ItemsSource = degrees
            };

            var contentPage2 = new ContentPage
            {
                Title = "Page2",
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "IBD",
                            FontSize = 30
                        },
                        new StackLayout
                        {
                            Orientation = StackOrientation.Vertical,
                            Margin = new Thickness(30),
                            Children =
                            {
                                new Label
                                {
                                    Text = "Teachers",
                                    FontSize = 25
                                },
                                teacherLabel,
                                new Label
                                {
                                    Text = "Degrees",
                                    FontSize = 25
                                },
                                listView
                            }
                        }
                    }
                }
            };
            
            var p = new CarouselPage()
            {
                Title = "My Degrees",
                BackgroundColor = new Color(1),
                Children =
                {
                    contentPage2,
                    emptyPage
                }
            };

            return p;
        }*/
    }
}
