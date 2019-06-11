using System.Runtime.Serialization;

namespace Task
{
    [DataContract]
    public class Buyer : IEntity
    {
        public Buyer(long id, string name, string surname,
            string address, string city, string area, string country, int postcode)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Address = address;
            City = city;
            Area = area;
            Country = country;
            Postcode = postcode;
        }

        [DataMember]
        public long Id { set; get; }

        [DataMember]
        public string Name { set; get; }

        [DataMember]
        public string Surname { set; get; }

        [DataMember]
        public string Address { set; get; }

        [DataMember]
        public string City { set; get; }

        [DataMember]
        public string Area { set; get; }

        [DataMember]
        public string Country { set; get; }

        [DataMember]
        public int Postcode { set; get; }

    }
}
