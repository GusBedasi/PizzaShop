using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Domain;
using AppContext = PizzaShop.Database.AppContext;

namespace PizzaShop.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomersController : ControllerBase
    {
        private readonly AppContext _dbcontext;
        
        public CustomersController(AppContext dbcontext)
        {
            _dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        }

        [HttpPost]
        public IActionResult CreateCustomer()
        {
            var customer = new Customer()
            {
                Name = "Gustavo",
                Email = "gustavo@email.com"
            };

            _dbcontext.Customers.Add(customer);
            _dbcontext.SaveChanges();
            
            return Ok(customer);
        }
        
        [HttpGet]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _dbcontext.Customers.Include(x => x.Orders)
                .Where(x => x.Id == id);
            
            return Ok(customer);
        }
    }
}