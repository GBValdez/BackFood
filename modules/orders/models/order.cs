using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.utils;

namespace project.modules.orders.models
{
    public enum OrderStatus
    {
        NEW,
        PAYED,
        SHIPPED,
        CANCELED,
        REFUNDED
    }
    public class Order : CommonsModel<ulong>
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public LatLng AddressLatLng { get; set; } = null!;
        public string PaymentId { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public List<orderItem> Items { get; set; } = new List<orderItem>();
        public OrderStatus Status { get; set; } = OrderStatus.NEW;
    }
}