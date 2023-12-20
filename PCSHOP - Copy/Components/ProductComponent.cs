using Microsoft.AspNetCore.Mvc;
using PCSHOP.Models;

namespace PCSHOP.Components
{
	[ViewComponent(Name ="Product")]
	public class ProductComponent : ViewComponent
	{
		private readonly DataContext _context;
		public ProductComponent(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listProduct = (from p in _context.Products
							   where (p.IsActive == true) && (p.Status ==1)
							   orderby p.ID descending
							   select p).Take(4).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", listProduct));
		}
	}
}
