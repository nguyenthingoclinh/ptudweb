using Microsoft.AspNetCore.Mvc;
using PCSHOP.Models;

namespace PCSHOP.Components
{
    [ViewComponent(Name ="Slide")]
    public class SlideComponent : ViewComponent
    {
        private readonly DataContext _context;
        public SlideComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listSlide = (from s in _context.Slides
                             where(s.IsActive == true) && (s.Status ==1)
                             orderby s.ID descending
                             select s).Take(3).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listSlide));
        }
    }
}
