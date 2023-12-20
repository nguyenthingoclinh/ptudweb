using Microsoft.AspNetCore.Mvc;
using PCSHOP.Models;

namespace PCSHOP.Components
{
    [ViewComponent(Name ="MenuView")]
    public class MenuViewComponent : ViewComponent
    {
        private DataContext _context;
        public MenuViewComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofMenu = (from s in _context.Menus
                              where (s.IsActive==true) && (s.Position==1)
                              select s).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofMenu));
        }
    }
}
