﻿using Microsoft.AspNetCore.Mvc;
using PCSHOP.Models;
using System.Diagnostics;
using PCSHOP.Utilities;

namespace PCSHOP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            /*if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");*/
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/post-{slug}-{id:long}.html", Name = "Details")]
        public IActionResult Details(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var post = _context.Posts
                .FirstOrDefault(m =>(m.ID == id) && (m.IsActive == true));
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [Route("List-{slug}-{id:int}.html",Name ="List")]
        public IActionResult List(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var list =_context.PostMenus
                .Where(m =>(m.MenuID == id) && (m.IsActive == true))
                .Take(6).ToList();
            if(list == null)
            {
                return NotFound();
            }
            return View(list);
        }
        [Route("/Product-{slug}-{id:int}.html",Name="ProductDetails")]
        public IActionResult ProductDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _context.Products
                .FirstOrDefault(m => (m.ID == id) && (m.IsActive == true));
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [Route("/productlist-{slug}-{id:int}.html", Name = "ProductList")]
        public IActionResult ProductList(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productlist = _context.ProductMenus
                .Where(m => (m.ID == id) && (m.IsActive == true))
                .ToList();
            if (productlist == null)
            {
                return NotFound();
            }
            return View(productlist);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}