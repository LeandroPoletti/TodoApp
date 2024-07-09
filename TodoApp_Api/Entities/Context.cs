using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace TodoApp_Api.Entities;

public class Context : DbContext
{
    private static readonly string conn = "Host=localhost;Database=todoapp;Username=postgres;Password=Senha123";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(conn);
    }

    
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().ToTable("usuarios");
        modelBuilder.Entity<Tarefa>().ToTable("tarefas");
        
        modelBuilder.Entity<Usuario>()
            .HasMany(e => e.Tarefas)
            .WithOne(e => e.UsuarioDono)
            .HasForeignKey(e => e.UsuarioId)
            .IsRequired();
    }
}