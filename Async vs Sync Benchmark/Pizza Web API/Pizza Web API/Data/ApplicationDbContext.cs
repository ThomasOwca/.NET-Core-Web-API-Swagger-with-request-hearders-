using Microsoft.EntityFrameworkCore;
using PizzeriaData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Web_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Crust> Crusts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Topping> Toppings { get; set; }
    }
}
