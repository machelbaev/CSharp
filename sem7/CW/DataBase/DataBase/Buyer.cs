using System.Runtime.Serialization;

namespace Task
{
    [DataContract]
    public class Buyer : IEntity
    {
        public Buyer(long id, string name, string surName,
            string address, string city, string area, string country, int postCode)
        {
            Id = id;
            Name = name;
            SurName = surName;
            Address = address;
            City = city;
            Area = area;
            Country = country;
            PostCode = postCode;
        }

        [DataMember]
        public long Id { set; get; }

        [DataMember]
        public string Name { set; get; }

        [DataMember]
        public string SurName { set; get; }

        [DataMember]
        public string Address { set; get; }

        [DataMember]
        public string City { set; get; }

        [DataMember]
        public string Area { set; get; }

        [DataMember]
        public string Country { set; get; }

        [DataMember]
        public int PostCode { set; get; }

    }
}
