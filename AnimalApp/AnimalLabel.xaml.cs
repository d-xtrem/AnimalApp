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

namespace AnimalApp
{
    /// <summary>
    /// Логика взаимодействия для AnimalLabel.xaml
    /// </summary>
    public partial class AnimalLabel : UserControl
    {
        public string LabelText
        {
            get{ return (string)Text.Content; }
            private set { Text.Content = value; }
        }
        public Animal Animal { get; private set; }

        public AnimalLabel(Animal animal)
        {
            InitializeComponent();
            Animal = animal;
            Text.Content = animal.ToString();
        }
    }
}
