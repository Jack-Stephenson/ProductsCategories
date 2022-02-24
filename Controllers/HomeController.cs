using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsCategories.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Products()
        {
            ViewBag.AllProducts = _context.Products.ToList();
            return View();
        }
        [HttpPost("addProduct")]
        public IActionResult addProduct(Product newProduct)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Add(newProduct);
                _context.SaveChanges();
                return RedirectToAction("Products");
            }
            ViewBag.AllProducts = _context.Products.ToList();
            return View("Products");
        }
        [HttpGet("Categories")]
        public IActionResult Categories()
        {
            ViewBag.AllCategories = _context.Categories.ToList();
            return View();
        }
        [HttpPost("addCategory")]
        public IActionResult addCategory(Category newCategory)
        {
            if(ModelState.IsValid)
            {
                _context.Categories.Add(newCategory);
                _context.SaveChanges();
                return RedirectToAction("Categories");
            }
            ViewBag.AllCategories = _context.Categories.ToList();
            return View("Categories");
        }
        [HttpGet("categories/{cid}")]
        public IActionResult OneCategory(int cid)
        {
            ViewBag.Category = _context.Categories.Include(s=>s.Products).ThenInclude(d=>d.Product).FirstOrDefault(a=>a.CategoryId == cid);
            ViewBag.AllProducts = _context.Products.ToList();
            return View();
        }
        [HttpPost("categories/addCategoryProduct")]
        public IActionResult addCategoryProduct(Association newAssociation)
        {
            _context.Associations.Add(newAssociation);
            _context.SaveChanges();
            return Redirect($"{newAssociation.CategoryId}");
        }
        [HttpGet("products/{pid}")]
        public IActionResult OneProduct(int pid)
        {
            ViewBag.Product = _context.Products.Include(s=>s.Categories).ThenInclude(d=>d.Category).FirstOrDefault(a=>a.ProductId == pid);
            ViewBag.AllCategories = _context.Categories.ToList();
            return View();
        }
        [HttpPost("products/addProductCategory")]
        public IActionResult addProductCategory(Association newAssociation)
        {
            _context.Associations.Add(newAssociation);
            _context.SaveChanges();
            return Redirect($"{newAssociation.ProductId}");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
