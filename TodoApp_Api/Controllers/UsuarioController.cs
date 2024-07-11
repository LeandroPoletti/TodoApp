using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp_Api.Entities;

namespace TodoApp_Api.Controllers;

[Route("/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly TodoContext _context;

    public UsuarioController(TodoContext todoContext)
    {
        _context = todoContext;
    }
    
    [HttpGet]
    public IActionResult ListarUsuarios()
    {
        var usuarios = _context.Usuarios
            .Include(u => u.Listas.OrderBy(t => t.Id))
            .ToList();

        foreach (var usuario in usuarios)
        {
            usuario.Listas = _context.Listas.Where(l => l.IdUsuario == usuario.Id)
                .Include(l => l.ListaDeTarefas)
                .ToList();
        }
        
        return Ok(usuarios);
    }
}