using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace TodoApp_Api.Entities;

public class TodoContext : DbContext
{
    //private static readonly string conn = "Host=localhost;Database=todoapp;Username=postgres;Password=Senha123";

    public TodoContext(DbContextOptions<TodoContext> contextOptions) : base(contextOptions)
    {
        
    }
    
    /*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(conn);
    }
*/
    
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<Lista> Listas { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().ToTable("usuarios");
        modelBuilder.Entity<Tarefa>().ToTable("tarefas");
        modelBuilder.Entity<Lista>().ToTable("listas");


        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Listas)
            .WithOne(l => l.DonoDaLista)
            .HasForeignKey(l => l.IdUsuario)
            .IsRequired();
        
        modelBuilder.Entity<Lista>()
            .HasMany(l => l.ListaDeTarefas)
            .WithOne(t => t.PertenceLista)
            .HasForeignKey(t => t.ListaId)
            .IsRequired();

    }
}