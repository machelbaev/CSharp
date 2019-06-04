using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    [DataContract]
    public class Good : IEntity
    {
        public Good(long id, string name, long shopId, string description, string category)
        {
            Id = id;
            Name = name;
            ShopId = shopId;
            Description = description;
            Category = category;
        }

        [DataMember]
        public long Id { set; get; }

        [DataMember]
        public string Name { set; get; }

        [DataMember]
        public long ShopId { set; get; }

        [DataMember]
        public string Description { set; get; }

        [DataMember]
        public string Category { set; get; }
    }
}
