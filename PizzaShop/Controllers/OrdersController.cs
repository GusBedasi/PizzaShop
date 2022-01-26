using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Domain;
using AppContext = PizzaShop.Database.AppContext;

namespace PizzaShop.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly AppContext _dbcontext;
        
        public OrdersController(AppContext dbcontext)
        {
            _dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        }
        
        [HttpPost]
        public IActionResult CreateOrder(int amount)
        {
            var order = new Order()
            {
                Amount = amount,
                CustomerId = 1
            };

            _dbcontext.Orders.Add(order);
            _dbcontext.SaveChanges();
            
            return Ok(order);
        }
        
        [HttpGet]
        public IActionResult GetOrderById(int id)
        {
            var order = _dbcontext.Orders.Include(x => x.Customer)
                .Where(x => x.Id == id).ToList();

            return Ok(order);
        }
    }
}