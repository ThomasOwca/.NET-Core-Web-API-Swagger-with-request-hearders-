using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzeriaData.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required]
        public Crust Crust { get; set; }

        [Required]
        public Size Size { get; set; }

        [Required]
        public string Topping1 { get; set; }

        [Required]
        public string Topping2 { get; set; }

        [Required]
        public string Topping3 { get; set; }

        public int Quantity { get; set; }

        public decimal SubTotal { get; set; }
    }
}
