using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.Json;
using System.IO;

namespace AnimalApp
{
    /// <summary>
    /// Логика взаимодействия для MenuAdd.xaml
    /// </summary>
    public partial class MenuAdd : Window
    {
        public MenuAdd()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = new Animal(NameBox.Text,DescriptionBox.Text,PhotoWayBox.Text);
            Animal.animals.Add(animal);
            using (FileStream fs = new FileStream("AnimalData.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<List<Animal>>(fs, Animal.animals);
            }
            DialogResult = true;
        }

        private void SelectWay_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                PhotoWayBox.Text = dlg.FileName;
            }
            else
            {
                PhotoWayBox.Text = "";
            }

        }
    }
}
