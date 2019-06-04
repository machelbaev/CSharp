using System.Runtime.Serialization;

namespace Task
{
    [DataContract]
    public class Shop : IEntity
    {
        public Shop(long id, string name, string city, string area, string country, string phone)
        {
            Id = id;
            Name = name;
            City = city;
            Area = area;
            Country = country;
            Phone = phone;
        }

        [DataMember]
        public long Id { set; get; }

        [DataMember]
        public string Name { set; get; }

        [DataMember]
        public string City { set; get; }

        [DataMember]
        public string Area { set; get; }

        [DataMember]
        public string Country { set; get; }

        [DataMember]
        public string Phone { set; get; }
    }
}
