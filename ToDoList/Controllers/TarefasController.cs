using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;
using Microsoft.EntityFrameworkCore; 

namespace ToDoList.Controllers
{
    public class TarefasController : Controller
    {
        private readonly AppDbContext _context;

        public TarefasController(AppDbContext context)
        {
            _context = context;
        }

        // Lista e formulário de criação

        public async Task<IActionResult> Index()
        {
            var tarefas = await _context.Tarefas.OrderByDescending(t => t.DataCriacao).ToListAsync();
            return View(tarefas);
        }
    }
}
