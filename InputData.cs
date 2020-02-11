using System;
using System.IO;
using System.Collections.Generic;
namespace LogicLibrary
{
    public static class InputData
    {
        
        public static readonly string rootFolder = @"C:\Users\Danylo\source\repos\OOProjectWF\";
        public static readonly string textFile = @"C:\Users\Danylo\source\repos\OOProjectWF\drivers.txt";
        public static void inputDrivers(ref List<Driver> drivers)
        {
            string textFile = @"C:\Users\Danylo\source\repos\OOProjectWF\drivers.txt";
            string[] lines = File.ReadAllLines(textFile);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(' ');
                drivers.Add(new Driver());
                drivers[i].motorbikePermit = bool.Parse(parts[0]);
                drivers[i].carPermit = bool.Parse(parts[1]);
                drivers[i].truckPermit = bool.Parse(parts[2]);

            }
        }
        public static void inputProducts(ref List<Product> products)
        {
            string textFile = @"C:\Users\Danylo\source\repos\OOProjectWF\products.txt";
            string[] lines = File.ReadAllLines(textFile);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(' ');
                products.Add(new Product());
                products[i].name = parts[0];
                products[i].price = Convert.ToInt32(parts[1]);
                products[i].size = Convert.ToInt32(parts[2]);

            }

        }
        public static void inputManagers(ref List<Manager> managers)
        {
            string textFile = @"C:\Users\Danylo\source\repos\OOProjectWF\managers.txt";
            string line = File.ReadAllText(textFile);
            int amountOfManagers = Convert.ToInt32(line);
            for (int i = 0; i < amountOfManagers; i++) managers.Add(new Manager());
        }
        public static void inputCars(ref List<Car> cars)
        {
            string textFile = @"C:\Users\Danylo\source\repos\OOProjectWF\cars.txt";
            string line = File.ReadAllText(textFile);
            int amountOfCars = Convert.ToInt32(line);
            for (int i = 0; i < amountOfCars; i++) cars.Add(new Car());
        }
        public static void inputTrucks(ref List<Truck> trucks)
        {
            string textFile = @"C:\Users\Danylo\source\repos\OOProjectWF\trucks.txt";
            string line = File.ReadAllText(textFile);
            int amountOfTrucks = Convert.ToInt32(line);
            for (int i = 0; i < amountOfTrucks; i++) trucks.Add(new Truck());
        }
        public static void inputMotorbikes(ref List<Motorbike> motorbikes)
        {
            string textFile = @"C:\Users\Danylo\source\repos\OOProjectWF\motorbikes.txt";
            string line = File.ReadAllText(textFile);
            int amountOfMotorbikes = Convert.ToInt32(line);
            for (int i = 0; i < amountOfMotorbikes; i++) motorbikes.Add(new Motorbike());
        }
    }
}