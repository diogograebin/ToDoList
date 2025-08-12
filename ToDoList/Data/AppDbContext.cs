using System;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Tarefa> Tarefas { get; set; } = null!; // DbSet para a entidade Tarefa
    }
}
