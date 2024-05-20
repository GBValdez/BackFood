using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.modules.foods;
using project.utils;

namespace project.modules.orders.models
{
    public class orderItem : CommonsModel<int>
    {

        public int FoodId { get; set; }

        public int OrderId { get; set; }
        public Food? Food { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Order? Order { get; set; }

    }
}