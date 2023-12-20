using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PCSHOP.Models;

namespace PCSHOP.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly DataContext _context;
		public ProductController(DataContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var mnList = _context.Products.OrderBy(p => p.ID).ToList();
			return View(mnList);
		}
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var mn = _context.Products.Find(id);
			if (mn == null)
			{
				return NotFound();
			}
			return View(mn);
		}
		[HttpPost]
		public IActionResult Delete(int id)
		{
			var deleProduct = _context.Products.Find(id);
			if (deleProduct == null)
			{
				return NotFound();
			}
			_context.Products.Remove(deleProduct);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Create()
		{
			var mnList = (from m in _context.Products
						  select new SelectListItem()
						  {
							  Text = m.Name,
							  Value = m.ID.ToString(),
						  }).ToList();
			mnList.Insert(0, new SelectListItem()
			{
				Text = "----Select----",
				Value = "0"
			});
			ViewBag.mnList = mnList;
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Product product)
		{
			if (ModelState.IsValid)
			{
				_context.Products.Add(product);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(product);
		}
	}
}
