using System.Runtime.Serialization;

namespace Task
{
    [DataContract]
    public class Sales : IEntity
    {
        public Sales(long id, long customerId, long shopId, long goodId, int quantity, double cost)
        {
            Id = id;
            CustomerId = customerId;
            ShopId = shopId;
            GoodId = goodId;
            Quantity = quantity;
            Cost = cost;
        }

        [DataMember]
        public long Id { set; get; }

        [DataMember]
        public long CustomerId { set; get; }

        [DataMember]
        public long ShopId { set; get; }

        [DataMember]
        public long GoodId { set; get; }

        [DataMember]
        public int Quantity { set; get; }

        [DataMember]
        public double Cost { set; get; }
    }
}


