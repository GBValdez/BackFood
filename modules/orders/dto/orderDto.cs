using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.modules.orders;
using project.modules.orders.models;

namespace Nuevo.modules.orders.dto
{
    public class orderDto
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public LatLng AddressLatLng { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public List<orderItem> Items { get; set; } = new List<orderItem>();
        public string userId { get; set; } = null!;
    }
}