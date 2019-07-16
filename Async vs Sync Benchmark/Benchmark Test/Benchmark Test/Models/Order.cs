using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzeriaData.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int FulFilledById { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        
        [Required]
        public int Confirmation { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public Pizza Pizza { get; set; }

        [Required]
        public Store StorePickup { get; set; }

        public bool OnlineOrder { get; set; }

        public decimal Total { get; set; }
    }
}
