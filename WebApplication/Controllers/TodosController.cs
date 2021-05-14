using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;
using WebApplication.Infrastructure.Models;
using WebApplication.Infrastructure;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class TodosController : Controller
    {
        private readonly ApplicationContext _context;

        public TodosController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ViewResult> Index()
        {
            var todos = await _context.Todos
                .OrderByDescending(t => t.CreatedAt)
                .Select(t => new TodoViewModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    CreatedAt = t.CreatedAt
                })
                .ToListAsync();

            return View(todos);
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Create([FromForm] CreateTodoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = ModelState.Values.SelectMany(e => e.Errors).FirstOrDefault()?.ErrorMessage;
                return RedirectToAction(nameof(Index));
            }

            var todo = new Todo
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                CreatedAt = DateTime.UtcNow
            };

            await _context.AddAsync(todo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        
        [HttpPost]
        public async Task<RedirectToActionResult> Delete([FromForm] DeleteTodoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = ModelState.Values.SelectMany(e => e.Errors).FirstOrDefault()?.ErrorMessage;
                return RedirectToAction(nameof(Index));
            }

            var todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == model.Id);
            if (todo is null)
            {
                return RedirectToAction(nameof(Index));
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }
    }
}