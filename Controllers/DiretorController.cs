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
    public async Task<List<DiretorOutputGetDTO>> Get()
    {
        var diretores = await _context.Diretores.ToListAsync();
        var output = new List<DiretorOutputGetDTO>();
        foreach(Diretor d in diretores)
        {
            output.Add(new DiretorOutputGetDTO(d.Id,d.Nome));
        }
        return output;
    } 


    [HttpGet]
    [Route("GetId/{id}")]
    public async Task<ActionResult<DiretorOutputGetIdDTO>> GetId(long id)
    { 
        var diretor = await  _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == id);
        var output = new DiretorOutputGetIdDTO(diretor.Id,diretor.Nome);
        return Ok(output); 
    } 
    
    [HttpDelete]
    public async Task<ActionResult<Diretor>> DeletePut([FromBody] Diretor diretor)
    {   
        _context.Diretores.Remove (diretor);
        await _context.SaveChangesAsync();
        return Ok(diretor);
    } 



}