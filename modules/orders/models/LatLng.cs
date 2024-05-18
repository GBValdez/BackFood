using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.utils;

namespace project.modules.orders
{
    public class LatLng : CommonsModel<ulong>
    {
        public string Lat { get; set; } = null!;
        public string Lng { get; set; } = null!;
    }
}