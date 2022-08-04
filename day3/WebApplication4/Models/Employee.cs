using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class Employee
    {
        [Key]
        public int eId { get; set; }
        public string eName { get; set; }
        public int salary { get; set; }
    }
}
