﻿using System.Collections.Generic;

namespace PizzaShop.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}