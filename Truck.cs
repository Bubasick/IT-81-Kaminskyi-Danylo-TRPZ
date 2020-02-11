using System.Runtime.Serialization;
namespace LogicLibrary
{
    [DataContract]
    public class Truck : Transport
    {
        public Truck()
        {
            this.speed = 40;
            this.carryingCapacity = 1500;
            this.timeBeforeAvailability = 0;
        }
    }
}