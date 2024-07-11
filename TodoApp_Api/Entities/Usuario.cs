using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TodoApp_Api.Entities;

public class Usuario
{
    [Column("id")]
    public int Id { get; set; }
    [Required(ErrorMessage = "Necessário fornecer nome de usuário")]
    [Column("nome")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Necessário fornecer email")]
    [Column("email")]
    public string Email { get; set; }
    [Column("idade")]
    public int? Idade { get; set; }
    //public ICollection<Tarefa> Tarefas { get; } = new List<Tarefa>();
    public ICollection<Lista> Listas { get; set; } = new List<Lista>();
}