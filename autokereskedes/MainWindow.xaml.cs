using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace autokereskedes
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, string> carImages = new Dictionary<string, string>();

        public MainWindow()
        {
            InitializeComponent();

            
            carImages["Toyota"] = @"..\..\..\images\Toyota.jpg";
            carImages["Volkswagen"] = @"..\..\..\images\Volkswagen.jpg";
            carImages["BMW"] = @"..\..\..\images\BMW.jpg";
            carImages["Audi"] = @"..\..\..\images\Audi.jpg";
            carImages["Mercedes"] = @"..\..\..\images\mercedes.jpg";
            carImages["Ford"] = @"..\..\..\images\Ford.jpg";
            carImages["Honda"] = @"..\..\..\images\Honda.jpg";
            carImages["Kia"] = @"..\..\..\images\Kia.jpg";
            carImages["Nissan"] = @"..\..\..\images\Nissan.jpg";
            carImages["BMW"] = @"..\..\..\images\BMW.jpg";
            carImages["Hyundai"] = @"..\..\..\images\Hyundai.jpg";
            
        }

        private void LoadFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string filePath = @"..\..\..\src\autok.txt";

                
                List<Auto> autok = new List<Auto>();
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    autok.Add(new Auto(line));
                }

                
                carDataGrid.ItemsSource = autok;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba a fájl beolvasásakor: {ex.Message}");
            }
        }

        private void carDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (carDataGrid.SelectedItem is Auto selectedCar)
            {
                if (carImages.ContainsKey(selectedCar.Gyarto))
                {
                    string imagePath = carImages[selectedCar.Gyarto];
                    if (File.Exists(imagePath))
                    {
                        try
                        {
                            var image = new Image();
                            var bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
                            bitmap.EndInit();
                            image.Source = bitmap;

                            var imageWindow = new Window
                            {
                                Title = "Autókép",
                                Content = image,
                                Width = 400,
                                Height = 300,
                                WindowStartupLocation = WindowStartupLocation.CenterScreen
                            };
                            imageWindow.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Hiba a kép megjelenítésekor: {ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("A kép nem található.");
                    }
                }
                else
                {
                    MessageBox.Show("Nincs kép az autóhoz.");
                }
            }
        }


    }
}
