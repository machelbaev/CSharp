using System.Runtime.Serialization;

namespace Task
{
    [DataContract]
    public class GoodFactory : IEntityFactory<Good>
    {
        private static long _id = 1;

        [DataMember(Name = "Name")]
        private string _name;

        [DataMember(Name = "ShopId")]
        private long _shopId;

        [DataMember(Name = "Description")]
        private string _description;

        [DataMember(Name = "Category")]
        private string _category;

        public GoodFactory(string name, long shopId, string description, string category)
        {
            _name = name;
            _shopId = shopId;
            _description = description;
            _category = category;
        }

        public Good Instance => new Good(_id++, _name, _shopId, _description, _category);
    }
}
