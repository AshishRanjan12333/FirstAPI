using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAPI.Models;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDb;
        public ProductsController(ApplicationDbContext applicationDb)
        {
            this.applicationDb = applicationDb;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var products = applicationDb.Products.ToList();
           
                return Ok(products);
           

        }
        [HttpPost]
        public IActionResult Post(Products products)
        {
            applicationDb.Products.Add(products);
            applicationDb.SaveChanges();
            return Ok(new { ok = true, message = "product created successfully...." });
        }
    }
}
