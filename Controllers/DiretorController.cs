using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

[ApiController]
[Route("[controller]")]
public class DiretorController : ControllerBase
{
    private readonly AplicationDbContext _context;
    public DiretorController(AplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Cria um diretor
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /diretor
    ///     {
    ///        "nome": "Martin Scorsese",
    ///     }
    ///
    /// </remarks>
    /// <param name="nome">Nome do diretor</param>
    /// <returns>O diretor criado</returns>
    /// <response code="200">Diretor foi criado com sucesso</response>
    [HttpPost]
    public async Task<ActionResult<Diretor>> Post([FromBody] Diretor diretor)
    {
        try
        {
            if ((diretor.Nome == null) || (diretor.Nome == ""))
            {
                return Conflict("Nome do diretor necessário!");
            }
            _context.Diretores.Add(diretor);
            await _context.SaveChangesAsync();

            return Ok(diretor);
        }
        catch (Exception e)
        {
            return Conflict(e.Message);
        }
    }
    [HttpPut]
    public async Task<ActionResult<Diretor>> Put([FromBody] Diretor diretor)
    {
        try
        {

            _context.Diretores.Update(diretor);
            await _context.SaveChangesAsync();
            return Ok(diretor);
        }
        catch (Exception e)
        {
            return Conflict(e.Message);
        }
    }
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<List<DiretorOutputGetDTO>>> Get()
    {
        try
        {
            var diretores = await _context.Diretores.ToListAsync();
            var output = new List<DiretorOutputGetDTO>();
            foreach (Diretor d in diretores)
            {
                output.Add(new DiretorOutputGetDTO(d.Id, d.Nome));
            }
            return output;
        }
        catch (Exception e)
        {
            return Conflict(e.Message);
        }
    }


    [HttpGet]
    [Route("GetId/{id}")]
    public async Task<ActionResult<DiretorOutputGetIdDTO>> GetId(long id)
    {
        try
        {
            var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == id);
            var output = new DiretorOutputGetIdDTO(diretor.Id, diretor.Nome);
            return Ok(output);
        }
        catch (Exception e)
        {
            return Conflict(e.Message);
        }
    }

    [HttpDelete]
    public async Task<ActionResult<Diretor>> DeletePut([FromBody] Diretor diretor)
    {
        try
        {
            _context.Diretores.Remove(diretor);
            await _context.SaveChangesAsync();
            return Ok(diretor);
        }
        catch (Exception e)
        {
            return Conflict(e.Message);
        }
    }



}