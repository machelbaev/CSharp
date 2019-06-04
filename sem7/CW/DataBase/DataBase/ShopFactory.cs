using System.Runtime.Serialization;

namespace Task
{
    [DataContract]
    public class ShopFactory : IEntityFactory<Shop>
    {
        private static long _id = 1;

        [DataMember(Name = "Name")]
        private string _name;

        [DataMember(Name = "City")]
        private string _city;

        [DataMember(Name = "Area")]
        private string _area;

        [DataMember(Name = "Country")]
        private string _country;

        [DataMember(Name = "Phone")]
        private string _phone;

        public ShopFactory(string name, string city, string area, string country, string phone)
        {
            _name = name;
            _city = city;
            _area = area;
            _country = country;
            _phone = phone;
        }

        public Shop Instance => new Shop(_id++, _name, _city, _area, _country, _phone);
    }
}
