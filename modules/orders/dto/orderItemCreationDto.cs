using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nuevo.modules.orders.dto
{
    public class orderItemCreationDto
    {
        public int FoodId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}