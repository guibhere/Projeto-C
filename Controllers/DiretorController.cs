using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

[ApiController]
[Route("[controller]")]
public class DiretorController : ControllerBase
{
    private readonly AplicationDbContext _context;
    public DiretorController(AplicationDbContext context)
    {
        _context = context;  
    }

    [HttpPost]
    public async Task<ActionResult<Diretor>> Post([FromBody] Diretor diretor)
    {
        if((diretor.Nome == null)||(diretor.Nome == ""))
        {
            return Conflict("Nome do diretor necessário!") ;  
        }
      _context.Diretores.Add(diretor);
      await _context.SaveChangesAsync();

      return Ok(diretor);
    } 
    [HttpPut]
    public async Task<ActionResult<Diretor>> Put([FromBody] Diretor diretor)
    {
        _context.Diretores.Update(diretor);
        await _context.SaveChangesAsync();
        return Ok(diretor);
    } 
    [HttpGet]
    [Route("GetAll")]
    public async Task<List<Diretor>> Get()
    {
        return await _context.Diretores.Include(filmes => filmes.Filmes).ToListAsync();
    } 


    [HttpGet]
    [Route("GetId/{id}")]
    public async Task<Diretor> GetId(long id)
    { 
        return await  _context.Diretores.Include(f => f.Filmes).FirstOrDefaultAsync(d => d.Id == id);
    } 
    
    [HttpDelete]
    public async Task<ActionResult<Diretor>> DeletePut([FromBody] Diretor diretor)
    {   
        _context.Diretores.Remove (diretor);
        await _context.SaveChangesAsync();
        return Ok(diretor);
    } 



}