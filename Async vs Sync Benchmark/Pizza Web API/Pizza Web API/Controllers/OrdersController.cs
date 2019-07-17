using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizza_Web_API.Data;
using PizzeriaData.Models;

namespace Pizza_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/orders
        [HttpGet("Async")]
        public async Task<IActionResult> GetOrdersAsync()
        {
            // Get request header(s) in C# .NET Core.
            string userName = Request.Headers["Username"];
            string fullName = Request.Headers["Fullname"];

            var headers = Request.Headers.Values;

            var username = User.Identity.Name;

            var results = await _context.Orders
                .Include(order => order.Status)
                .Include(order => order.Pizza.Crust)
                .Include(order => order.Pizza.Size)
                .Include(order => order.StorePickup)
                .ToListAsync();

            if (results != null)
                return Ok(results);
            else
                return BadRequest();
        }

        // GET api/orders
        [HttpGet("Sync")]
        public IActionResult GetOrdersSync()
        {
            // Get request header(s) in C# .NET Core.
            string userName = Request.Headers["Username"];
            string fullName = Request.Headers["Fullname"];

            var results = _context.Orders
                .Include(order => order.Status)
                .Include(order => order.Pizza.Crust)
                .Include(order => order.Pizza.Size)
                .Include(order => order.StorePickup)
                .ToList();

            if (results != null)
                return Ok(results);
            else
                return BadRequest();
        }

        // GET api/orders/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderAsync([FromRoute] int id)
        {
            // Get request header(s) in C# .NET Core.
            string userName = Request.Headers["Username"];
            string fullName = Request.Headers["Fullname"];

            var result = await _context.Orders.FirstOrDefaultAsync(order => order.Id == id);

            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }
    }
}