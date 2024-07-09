using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp_Api.Entities;

namespace TodoApp_Api.Controllers;

[Route("/[controller]")]
public class UsuarioController : ControllerBase
{
    [HttpGet]
    public IActionResult ListarUsuarios()
    {
        var context = new Context();
        var usuarios = context.Usuarios
            .Include(u => u.Tarefas.OrderBy(t => t.Id)
            ).ToList();
        
        return Ok(usuarios);
    }
}