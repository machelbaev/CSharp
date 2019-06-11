using System.Runtime.Serialization;

namespace Task
{
    [DataContract]
    public class BuyerFactory : IEntityFactory<Buyer>
    {
        private static long _id = 1;

        [DataMember(Name = "Name")]
        private string _name;

        [DataMember(Name = "Surname")]
        private string _surname;

        [DataMember(Name = "Address")]
        private string _address;

        [DataMember(Name = "City")]
        private string _city;

        [DataMember(Name = "Area")]
        private string _area;

        [DataMember(Name = "Country")]
        private string _country;

        [DataMember(Name = "Postcode")]
        private int _postcode;

        public BuyerFactory(string name, string surname, string address, string city,
            string area, string country, int postcode)
        {
            _name = name;
            _surname = surname;
            _address = address;
            _city = city;
            _area = area;
            _country = country;
            _postcode = postcode;
        }

        public Buyer Instance => new Buyer(_id++, _name, _surname, _address, _city, _area, _country, _postcode);
    }

}
