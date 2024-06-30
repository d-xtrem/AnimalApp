using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Reflection;

namespace AnimalApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetData();
        }


        private void AddWindow_Click(object sender, RoutedEventArgs e)
        {
            MenuAdd menu = new MenuAdd();
            bool? result = menu.ShowDialog();
            if (result == true)
            {
                AnimalLabel lbl = new AnimalLabel(Animal.animals[Animal.animals.Count - 1]);
                AnimalList.Items.Add(lbl);
                AnimalList.Items.SortDescriptions.Add(new SortDescription("LabelText", ListSortDirection.Ascending));
            }
        }
        private void GetData()
        {
            using (FileStream fs = new FileStream("AnimalData.json", FileMode.OpenOrCreate))
            {
                Animal.animals = JsonSerializer.Deserialize<List<Animal>?>(fs);
            }
            if (Animal.animals == null)
            {
                Animal.animals = new List<Animal>();
            }
            foreach (var animal in Animal.animals)
            {
                AnimalLabel lbl = new AnimalLabel(animal);
                AnimalList.Items.Add(lbl);
            }
            AnimalList.Items.SortDescriptions.Add(new SortDescription("LabelText", ListSortDirection.Ascending));
            //Animal.animals.Find(x => x.Name == "");
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AnimalList.Items.Clear();
            if (SearchBox.Text == string.Empty)
            {
                foreach (var animal in Animal.animals)
                {
                    AnimalLabel lbl = new AnimalLabel(animal);
                    AnimalList.Items.Add(lbl);
                }
                AnimalList.Items.SortDescriptions.Add(new SortDescription("LabelText", ListSortDirection.Ascending));
                return;
            }
            var selectedAnimal = from animal in Animal.animals where animal.Name.Contains(SearchBox.Text) select animal;
            foreach (var animal in selectedAnimal)
            {
                AnimalLabel lbl = new AnimalLabel(animal);
                AnimalList.Items.Add(lbl);
            }
            AnimalList.Items.SortDescriptions.Add(new SortDescription("LabelText", ListSortDirection.Ascending));
        }

        private void AnimalList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = AnimalList.SelectedIndex;
            if (index == -1)
            {
                return;
            }
            Animal animal = ((AnimalLabel)AnimalList.Items[index]).Animal;
            if (animal.PhotoWay != "")
            {
                ImageAnimal.Source = new BitmapImage(new Uri(animal.PhotoWay, UriKind.Absolute));
            }
            NameBlock.Text = animal.Name;
            DescriptionBlock.Text = animal.Description;
        }

        private void DelAnimal_Click(object sender, RoutedEventArgs e)
        {
            int index = AnimalList.SelectedIndex;
            Animal animal = ((AnimalLabel)AnimalList.Items[index]).Animal;
            int indexList = Animal.animals.IndexOf(animal);
            AnimalList.Items.RemoveAt(index);
            Animal.animals.RemoveAt(indexList);
            using (FileStream fs = new FileStream("AnimalData.json", FileMode.Create))
            {
                JsonSerializer.Serialize<List<Animal>>(fs, Animal.animals);
            }
        }
    }
}
