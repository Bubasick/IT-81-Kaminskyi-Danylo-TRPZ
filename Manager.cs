using System.Runtime.Serialization;
namespace LogicLibrary
{
    [DataContract]
    public class Manager
    {
        [DataMember]
        public double timeBeforeAvailability = 0;
        public double timeNeededToPerformTask(Product product)
        {
            this.timeBeforeAvailability = product.name.Length / 60.0;
            return ((product.name.Length / 60.0)); // We assume that the longer the name of the type, the longer will manager operate with it.
        }

    }
}