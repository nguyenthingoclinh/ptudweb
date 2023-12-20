using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PCSHOP.Models;

namespace PCSHOP.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SlideController : Controller
	{
		private readonly DataContext _context;
		public SlideController(DataContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var mnList = _context.Slides.OrderBy(s => s.ID).ToList();
			return View(mnList);
		}
		public IActionResult Delete(long? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var mn = _context.Slides.Find(id);
			if (mn == null)
			{
				return NotFound();
			}
			return View(mn);
		}
		[HttpPost]
		public IActionResult Delete(long id)
		{
			var deleSlide = _context.Slides.Find(id);
			if (deleSlide == null)
			{
				return NotFound();
			}
			_context.Slides.Remove(deleSlide);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Create()
		{
			var mnList = (from s in _context.Slides
						  select new SelectListItem()
						  {
							  Text = s.Title,
							  Value = s.ID.ToString(),
						  }).ToList();
			ViewBag.mnList = mnList;
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Slide slide)
		{
			if (ModelState.IsValid)
			{
				_context.Slides.Add(slide);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult Edit(long? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var mn = _context.Slides.Find(id);
			if (mn == null)
			{
				return NotFound();
			}
			var mnList = (from s in _context.Slides
						  select new SelectListItem()
						  {
							  Text = s.Title,
							  Value = s.ID.ToString(),
						  }).ToList();
			ViewBag.mnList = mnList;
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Slide slide)
		{
			if (ModelState.IsValid)
			{
				_context.Slides.Update(slide);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(slide);
		}

	}
}
