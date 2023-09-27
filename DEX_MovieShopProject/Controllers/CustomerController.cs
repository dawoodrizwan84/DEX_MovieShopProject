﻿using AspNetCore;
using DEX_MovieShopProject.Models;
using DEX_MovieShopProject.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DEX_MovieShopProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;
        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService) 
        {
            _logger = logger;
            _customerService = customerService;
        }

     
        public IActionResult Index()
        {
            var customerList = 
            
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer newCustomer)
        {
            _customerService.CreateCustomer(newCustomer);
            return View();
        }
    }
}
