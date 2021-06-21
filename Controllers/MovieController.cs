using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly AplicationDbContext _context;
    public MovieController(AplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Filme>> Post([FromBody] Filme f)
    {
        if ((f.Titulo == null) || (f.Titulo == ""))
        {
            return Conflict("Nome do filme necessário!");
        }
        Diretor d = await _context.Diretores.FindAsync(f.DiretorId);
        if (d == null)
        {
            return Conflict("Diretor não encontrado");
        }

        f.Diretor = d;
        _context.Filmes.Add(f);
        await _context.SaveChangesAsync();

        return Ok(f);
    }
    [HttpPut]
    public async Task<ActionResult<Filme>> Put([FromBody] Filme f)
    {
        if ((f.Titulo == null) || (f.Titulo == ""))
        {
            return Conflict("Nome do filme necessário!");
        }
        var d = await _context.Diretores.FindAsync(f.DiretorId);
        if (d == null)
        {
            return Conflict("Diretor não encontrado");
        }

        _context.Filmes.Update(f);
        await _context.SaveChangesAsync();
        return Ok(f);
    }
    [HttpGet]

    public async Task<List<Filme>> GetAll()
    {
        return await _context.Filmes.Include(d => d.Diretor).ToListAsync();
    } 

    [HttpGet]
    [Route("Id/{id}")]
    public async Task<Filme> GetId(long id)
    {
        return await _context.Filmes.Include(d => d.Diretor).Include(filmes => filmes.Diretor.Filmes).FirstOrDefaultAsync(f => f.Id == id);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<Filme>> Delete(long id)
    {
        Filme f = await _context.Filmes.FindAsync(id);
        _context.Filmes.Remove(f);
        await _context.SaveChangesAsync();
        return Ok(f);
    }



}