using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PCSHOP.Models;

namespace PCSHOP.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class KHController : Controller
	{
		private readonly DataContext _context;
		public KHController(DataContext context) 
		{ 
			_context = context; 
		}
		public IActionResult Index()
		{
			var mnList = _context.Users.OrderBy(m => m.ID).ToList();
			return View(mnList);
		}
	}
}
