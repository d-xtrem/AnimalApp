using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalApp
{
    [Serializable]
    public class Animal
    {
        static public List<Animal>? animals = new List<Animal>();
        string name;
        string description;
        string photoway;
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public string Description
        {
            set { description = value; }
            get { return description; }
        }
        public string PhotoWay
        {
            set { photoway = value; }
            get { return photoway; }
        }
        public Animal(string name, string description, string photoway)
        {
            Name = name;
            Description = description;
            PhotoWay = photoway;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
