using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PCSHOP.Areas.Admin.Models;
using PCSHOP.Models;

namespace PCSHOP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminUserController : Controller
    {
        private readonly DataContext _context;
        public AdminUserController(DataContext context) 
        { 
            _context = context;
        }
        public IActionResult Index()
        {
            var mnList = _context.AdminUsers.OrderBy(m => m.ID).ToList();
            return View(mnList);

        }
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var mn = _context.AdminUsers.Find(id);
			if (mn == null)
			{
				return NotFound();
			}
			return View(mn);
		}
		[HttpPost]
		public IActionResult Delete(int id)
		{
			var deleadmin = _context.AdminUsers.Find(id);
			if (deleadmin == null)
			{
				return NotFound();
			}
			_context.AdminUsers.Remove(deleadmin);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Create()
		{
			var mnList = (from m in _context.AdminUsers
						  select new SelectListItem()
						  {
							  Text = m.UserName,
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
		public IActionResult Create(AdminUser mn)
		{
			if (ModelState.IsValid)
			{
				_context.AdminUsers.Add(mn);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(mn);
		}
	}
}
