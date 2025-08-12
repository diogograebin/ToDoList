using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Tarefa
    {
        [Key]
        public int TarefaID { get; set; }
        
        [Required(ErrorMessage = "O título é obrigatório.")]  // id unico da tarefa
        [StringLength(100, ErrorMessage = "O título não pode ter mais de 100 caracteres.")] //mensagem de erro personalizada
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }

        public bool Concluida { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public DateTime? DataConclusao { get; set; }


    }
}
