﻿using Microsoft.AspNetCore.Mvc;
using ThreeAmigos.Domain.Entities;
using ThreeAmigos.Domain.Interfaces.Services;
using ThreeAmigos.UI.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ThreeAmigos.UI.Controllers
{
    public class BrandsController : Controller
    {
        
        private readonly IProductService _service;

        public BrandsController(IProductService service)
        {
            
            _service = service;

            //TODO simple seed
            _service.AddProductAsync(new Product
            {
                Name = "Soggy Sponge",
                Active = true
            });

            _service.AddProductAsync(new Product
            {
                Name = "Damp Squib",
                Active = false
            });

        }
        
        public async Task<IActionResult> Index()
        {
            
            return View(await _service.GetProductsAsync());
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
