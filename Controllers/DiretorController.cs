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
    public string Put()
    {
        return "Put";
    } 
    [HttpGet]
    public async Task<List<Diretor>> Get()
    {
        return await _context.Diretores.ToListAsync();
    } 
        [HttpDelete]
    public string Delete()
    {
        return "Delete";
    } 



}