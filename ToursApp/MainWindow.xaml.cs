using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace ToursApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ToursPage());
            Manager.MainFrame = MainFrame;

            ImpotrTours();
        }

        private void ImpotrTours()
        {
            var fileData = File.ReadAllLines(@"C:\Users\Анастас\Downloads\Туры (1) - Лист1.txt");
            var images = Directory.GetFiles(@"C:\Users\Анастас\Downloads\фото");

            foreach (var line in fileData)
            {
                var data = line.Split('\t');

                var tempTour = new Tour
                {
                    Name = data[0].Replace("\"", " "),
                    TicketCount = int.Parse(data[2]),
                    Price = decimal.Parse(data[3]),
                    IsActual = (data[4] == "0") ? false : true
                };

                foreach (var tourType in data[5].Split(new string[] { "," },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    var currentType = TourBaseEntities.GetContext().Types.ToList().
                        FirstOrDefault(p => p.Name == tourType);
                    if (currentType != null)
                        tempTour.Types.Add(currentType);
                }

                try
                {
                    tempTour.ImagePreview = File.ReadAllBytes(images.FirstOrDefault(
                        p => p.Contains(tempTour.Name)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                TourBaseEntities.GetContext().Tours.Add(tempTour);
                TourBaseEntities.GetContext().SaveChanges();
            }

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }
    }
}


