using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using WebApplication.Infrastructure.Models;
using WebApplication.Infrastructure;
using WebApplication.Settings;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly PageSettings _settings;

        public HomeController(ApplicationContext context, IOptions<PageSettings> settings)
        {
            _context = context;
            _settings = settings.Value;
        }

        public async Task<ViewResult> Index()
        {
            var pageView = await _context.PageViews.FirstOrDefaultAsync(p => p.Name == "Home");
            if (pageView is null)
            {
                pageView = new PageView {Name = "Home"};
                _context.PageViews.Add(pageView);
            }

            pageView.Count++;

            await _context.SaveChangesAsync();
            
            return View(new HomeViewModel
            {
                Title = _settings.Title,
                ViewsCount = pageView.Count
            });
        }

        public ViewResult About()
        {
            return View(new AboutViewModel
            {
                Link = Url.ActionLink(nameof(Index))
            });
        }
    }
}