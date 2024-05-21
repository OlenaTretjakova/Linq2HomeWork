namespace Linq2HomeWork
{
    internal class Devise
    {
        public class Device
        {
            public string Name { get; set; }
            public string Manufacturer { get; set; }
            public double Price { get; set; }

            public Device(string name, string manufacturer, double price)
            {
                Name = name;
                Manufacturer = manufacturer;
                Price = price;
            }

            public bool CompareByManufacturer(Device dev1, Device dev2)
            {
                return dev1.Manufacturer == dev2.Manufacturer;
            }

            public override string ToString()
            { 
                return $"{Name} {Manufacturer} {Price}  ";
            }
        }

    }
}
