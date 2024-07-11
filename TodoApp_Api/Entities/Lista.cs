using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp_Api.Entities;

public class Lista
{
    [Column("id")]
    public int Id { get; set; }
    [Column("nome")]
    public string Nome { get; set; }
    [Column("descricao")]
    public string Descricao { get; set; }
    [Column("usuario_id")]
    public int IdUsuario { get; set; }

    public ICollection<Tarefa> ListaDeTarefas { get; } = new List<Tarefa>();
    public Usuario DonoDaLista { get; set; } = null!;
}