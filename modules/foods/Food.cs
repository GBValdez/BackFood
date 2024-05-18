using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.utils;

namespace project.modules.foods
{
    public class Food : CommonsModel<ulong>
    {
        public string name { get; set; } = null!;
        public float price { get; set; } = 0;
        public List<string> tags { get; set; } = new List<string>();
        public bool favorite { get; set; } = false;
        public float stars { get; set; } = 0;
        public string imageUrl { get; set; } = null!;
        public List<string> origins { get; set; } = new List<string>();
        public string cookTime { get; set; } = null!;
    }
}