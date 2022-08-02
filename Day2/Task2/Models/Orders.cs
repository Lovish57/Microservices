using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int OrderAmount { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}