using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mooooc.Models;
using Xamarin.Forms;

namespace Mooooc.Views
{
    public partial class DegreesAdd : ContentPage
    {
        public DegreesAdd()
        {
            InitializeComponent();
        }

        public CarouselPage GetCarouselPage()
        {
            var page = new CarouselPage()
            {
                Title = "Add Degrees"
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

            var emptyPage = new ContentPage
            {
                Title = "There is no degree yet",
            };

            var page2 = new ContentPage
            {
                Title = "There is no degree yet",
                Content = new Label
                {
                    Text = "couccccc"
                }
            };

            page.Children.Add(contentPage2);
            page.Children.Add(page2);
            page.Children.Add(emptyPage);

            return page;
        }

        public TabbedPage GetPage(Course course)
        {
            var page = new TabbedPage()
            {
                Title = "Add Degrees to " + course.GetAbbreviation(),
            };

            foreach (var student in course.Students)
            {
                var entry1 = new Entry
                {
                    Placeholder = "Degree1",
                    WidthRequest = Device.OnPlatform<double>(300, 300, 260)
                };

                var entry2 = new Entry
                {
                    Placeholder = "Degree2",
                    WidthRequest = Device.OnPlatform<double>(300, 300, 260)
                };

                var entry3 = new Entry
                {
                    Placeholder = "Degree3",
                    WidthRequest = Device.OnPlatform<double>(300, 300, 260)
                };

                var entry4 = new Entry
                {
                    Placeholder = "Average",
                    WidthRequest = Device.OnPlatform<double>(300, 300, 260)
                };


                var saveButton = new Button
                {
                    Text = "Save",
                    BackgroundColor = Color.Maroon,
                    FontSize = 15,
                    TextColor = Color.White
                };

                saveButton.Clicked += async (s, e) =>
                {
                    App._db.Insert(new Degree()
                    {
                        CourseId = course.ID,
                        StudentId = student.ID,
                        Name= "Assists(20%)",
                        Value = float.Parse(entry1.Text, CultureInfo.InvariantCulture.NumberFormat)
                    });

                    App._db.Insert(new Degree()
                    {
                        CourseId = course.ID,
                        StudentId = student.ID,
                        Name = "CC (40%)",
                        Value = float.Parse(entry2.Text, CultureInfo.InvariantCulture.NumberFormat)
                    });

                    App._db.Insert(new Degree()
                    {
                        CourseId = course.ID,
                        StudentId = student.ID,
                        Name = "Exam (40%)",
                        Value = float.Parse(entry3.Text, CultureInfo.InvariantCulture.NumberFormat)
                    });
                    
                    await DisplayAlert("Succes", "The degrees have been added", "OK");
                };
                var contentPage = new ContentPage
                {
                    Title = student.LastName,
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
                                    new Label{Text = "Assists(20%)",FontSize = 25},entry1}
                            },
                            new StackLayout {
                                Orientation = StackOrientation.Horizontal,
                                Padding = new Thickness(20),
                                Children = {new Label{Text = "CC (40%)",FontSize = 25},entry2}
                                },
                            new StackLayout {
                                Orientation = StackOrientation.Horizontal,
                                Padding = new Thickness(20),
                                Children = {new Label{Text = "Exam (40%)",FontSize = 25},entry3}
                                },
                            saveButton
                        }
                    }
                };

                page.Children.Add(contentPage);
            }
            return page;
        }
    }
}
