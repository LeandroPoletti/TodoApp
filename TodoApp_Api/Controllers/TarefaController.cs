using Microsoft.AspNetCore.Mvc;
using TodoApp_Api.Entities;

namespace TodoApp_Api.Controllers;

[Route("/[controller]")]
public class TarefaController: ControllerBase
{
        private readonly TodoContext _context;
    
        public TarefaController(TodoContext todoContext)
        {
                _context = todoContext;
        }
        
        
        [HttpGet]
        public IActionResult ListarTarefas()
        {
                // TODO classe service
                var tarefas = _context.Tarefas.ToList();
                return Ok(tarefas);
        }
}