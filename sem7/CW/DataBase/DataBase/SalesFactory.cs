/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
*/

using System.Runtime.Serialization;

namespace Task
{
    [DataContract]
    public class SalesFactory : IEntityFactory<Sales>
    {
        private static long _id = 1;

        [DataMember(Name = "CustomerId")]
        private long _customerId;

        [DataMember(Name = "ShopId")]
        private long _shopId;

        [DataMember(Name = "GoodId")]
        private long _goodId;

        [DataMember(Name = "Quantity")]
        private int _quantity;

        [DataMember(Name = "Cost")]
        private double _cost;

        public SalesFactory(long customerId, long shopId, long goodId, int quantity, double cost)
        {
            _customerId = customerId;
            _shopId = shopId;
            _goodId = goodId;
            _quantity = quantity;
            _cost = cost;
        }

        public Sales Instance => new Sales(_id++, _customerId, _shopId, _goodId, _quantity, _cost);
    }
}


