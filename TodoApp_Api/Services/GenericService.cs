using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TodoApp_Api.Entities;

namespace TodoApp_Api.Services;

public class GenericService<T>(TodoContext context)
    where T : class
{
    private readonly TodoContext _todoContext = context;

    public bool Validar(T entidade , out List<ValidationResult> erros)
    {
        erros = new List<ValidationResult>();
        var valido = Validator.TryValidateObject(entidade, new ValidationContext(entidade), erros);

        return valido;
    }
    
    public ICollection<T> ListarValores()
    {
        return _todoContext.Set<T>().ToList();
    }

    public ICollection<T> ListarValores(Func<T, bool> func)
    {
        return _todoContext.Set<T>().Where(func).ToList();
    }

    public bool AtualizarEntidade(T entidade)
    {
        var afetadas = 0;
        _todoContext.Set<T>().Update(entidade);
        try
        {
            afetadas = _todoContext.SaveChanges(); 
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e);
            
            throw;
        }

        return afetadas > 0;
    }

    public T AdicionarEntidade(T entidade)
    {
        
        List<ValidationResult> erros;
        if (Validar(entidade, out erros))
        {
            _todoContext.Set<T>().Add(entidade);
        }

        return entidade;
    }
    
}