using System.Collections.Generic;
using System;
using System.Runtime.Serialization;
namespace LogicLibrary
{
    [DataContract]
    [KnownType(typeof(Driver))]
    [KnownType(typeof(Car))]
    [KnownType(typeof(Truck))]
    [KnownType(typeof(Motorbike))]
    [KnownType(typeof(Product))]
    [KnownType(typeof(Manager))]
    public class MainStore
    {
        [DataMember]
        public List<Driver> drivers = new List<Driver>();
        [DataMember]
        public List<Store> stores = new List<Store>();
        [DataMember]
        public List<Car> cars = new List<Car>();
        [DataMember]
        public List<Truck> trucks = new List<Truck>();
        [DataMember]
        public List<Motorbike> motorbikes = new List<Motorbike>();
        [DataMember]
        public List<Product> products = new List<Product>();
        [DataMember]
        public List<Manager> managers = new List<Manager>();

        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException();
            products.Add(product);
        }
        public Manager chooseManager()
        {
            managers.Sort((x, y) => x.timeBeforeAvailability.CompareTo(y.timeBeforeAvailability));
            return managers[0];
        }
        public List<string> displayProducts()
        {
            List<string> productList = new List<string>();
            foreach (Product product in products)
            {
                productList.Add(product.displayProduct());
            }

            return productList;

        }
        public Transport chooseTransportType(Product product)
        {
            if (product.size < 20)
            {
                motorbikes.Sort((x, y) => x.timeBeforeAvailability.CompareTo(y.timeBeforeAvailability));
                return motorbikes[0];
            }
            if (20 <= product.size && product.size < 200)
            {
                cars.Sort((x, y) => x.timeBeforeAvailability.CompareTo(y.timeBeforeAvailability));
                return cars[0];
            }
            if (200 <= product.size && product.size < 1500)
            {
                trucks.Sort((x, y) => x.timeBeforeAvailability.CompareTo(y.timeBeforeAvailability));
                return trucks[0];
            }
            else return null;
        }
        public Driver chooseDriver(Transport transport)
        {
            drivers.Sort((x, y) => x.timeBeforeAvailability.CompareTo(y.timeBeforeAvailability));
            foreach (Driver driver in drivers)
            {
                if (driver.carPermit && transport.GetType().Name == "Car")
                {
                    driver.currentTransport = transport;
                   return driver;
                }
                if (driver.motorbikePermit && transport.GetType().Name == "Motorbike")
                {
                    driver.currentTransport = transport;
                    return driver;
                }
                if (driver.truckPermit && transport.GetType().Name == "Truck")
                {
                    driver.currentTransport = transport;
                    return driver;
                }
            }
            return null;
        }
        public double timeToDeliver(string name, double km)
        {
            double time = 0;
            Product product = products.Find(i => i.name == name); //search for a Product object by its name
            Manager manager = chooseManager();
            Driver driver = chooseDriver(chooseTransportType(product));
            // System.Console.WriteLine(manager.timeNeededToPerformTask(product));

            time = manager.timeNeededToPerformTask(product) + driver.currentTransport.timeToDeliver(km) + Math.Max(driver.timeBeforeAvailability, driver.currentTransport.timeBeforeAvailability);
            driver.timeBeforeAvailability += 2 * driver.currentTransport.timeToDeliver(km);

            return Math.Round(time, 2);

        }
    }
}