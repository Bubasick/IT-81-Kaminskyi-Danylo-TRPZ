using System;
using System.IO;
using System.Runtime.Serialization;
namespace LogicLibrary
{
    [DataContract]
    public class Driver : ICloneable
    {
        public object Clone()
        {
            Driver clone = new Driver();
            clone.carPermit = this.carPermit;
            clone.motorbikePermit = this.motorbikePermit;
            clone.truckPermit = this.truckPermit;
            clone.timeBeforeAvailability = 0;
            return clone;
        }
        [DataMember]
        public Transport currentTransport;
        [DataMember]
        public bool motorbikePermit;
        [DataMember]
        public bool carPermit;
        [DataMember]
        public bool truckPermit;
        [DataMember]
        public double timeBeforeAvailability; // 0 - Driver is available
        public Driver()
        {
            this.timeBeforeAvailability = 0;
        }
    }
}