using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp_Api.Entities;

public class Tarefa
{
    [Column("id")]
    public int Id { get; set; }
    [Column("datacriacao")]
    public DateOnly DataCriacao { get; set; }
    [Column("vencimento")]
    public DateOnly? Vencimento { get; set; }
    [Column("datacompleta")]
    public DateOnly? DataCompleta { get; set; }
    
    //[ForeignKey("Usuario")]
    [Column("usuario_id")]
    public int UsuarioId { get; set; }

    public Usuario UsuarioDono { get; set; } = null!;
}