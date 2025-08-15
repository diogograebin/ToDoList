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

        //Criar nova tarefa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarefa);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        //Editar tarefa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string titulo, string descricao, bool concluida)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            tarefa.Titulo = titulo;
            tarefa.Descricao = descricao;
            tarefa.Concluida = concluida;

            _context.Update(tarefa);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}
