using Microsoft.AspNetCore.Mvc;
using ThreeAmigos.Domain.Entities;
using ThreeAmigos.Domain.Interfaces.Services;
using ThreeAmigos.UI.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;

namespace ThreeAmigos.UI.Controllers
{
    
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        


        public ProductsController(IProductService service)
        {

            _service = service;



            //TODO simple seed

            _service.AddProductAsync(new Product
            {
                IdProduct = 1,
                Name = "IPhone5",
                Description = "Description of IPhone5 product should be here.",
                Active = true,
                Price = 100,
                StockLevel = 4,
                Brand = new Brand
                {
                    Id = 1,
                    Name = "Apple"
                },
                Category = new Category
                {
                    Id = 2,
                    Name = "Phone",
                    Description = "Browse our wide range of mobile phones."
                }

            }); 

            _service.AddProductAsync(new Product
            {
                IdProduct = 2,
                Name = "Samsung Galaxy",
                Description = "Description of tablet product should be here.",
                Active = false,
                Price = 200,
                StockLevel = 7,
                Brand = new Brand
                {
                    Id = 2,
                    Name = "Samsung"
                },
                Category = new Category
                {
                    Id = 1,
                    Name = "Tablet",
                    Description = "Electronic tablets at premium prices.  If you're lukcy your tablet will be protected from any dents, scratches and scuffs."
                }
            });

            _service.AddProductAsync(new Product
            {
                IdProduct = 3,
                Name = "Ipad mini",
                Description = "Ipad mini version.",
                Active = false,
                Price = 300,
                StockLevel = 8,
                Brand = new Brand
                {
                    Id = 1,
                    Name = "Apple"
                },
                Category = new Category
                {
                    Id = 1,
                    Name = "Tablet",
                    Description = "Electronic tablets at premium prices.  If you're lukcy your tablet will be protected from any dents, scratches and scuffs."
                }

            });

        }

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            System.Collections.Generic.IEnumerable<Product> products = await _service.GetProductsAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString)
                                          || s.Brand.Name.Contains(searchString)
                                          || s.Category.Name.Contains(searchString));
                                       
            }
            return View(products);
        }

        public async Task<IActionResult> Brands(string sortOrder, string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            System.Collections.Generic.IEnumerable<Product> products = await _service.GetProductsAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Brand.Name.Contains(searchString));

            }
            return View(products);
        }

        public async Task<IActionResult> Categories(string sortOrder, string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            System.Collections.Generic.IEnumerable<Product> products = await _service.GetProductsAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Category.Name.Contains(searchString)
                                          || s.Category.Description.Contains(searchString));

            }
            return View(products);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Details(int? id)
        {
            

            return View(await _service.GetProductsAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            await _service.AddProductAsync(product);
            return View(product);
        }
    }
}
