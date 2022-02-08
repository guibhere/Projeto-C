using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Threading;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly IFilmeService _filmeserv;
    public MovieController(IFilmeService filmeserv)
    {
        _filmeserv = filmeserv;
    }

    [HttpPost]
    public async Task<ActionResult<FilmeOutputPostDTO>> Post([FromBody] FilmeInputPostDTO input)
    {
        var f = new Filme(input.Titulo, input.DiretorID);
        await _filmeserv.Post(f);
        var output = new FilmeOutputPostDTO(f.Id, f.Titulo, f.DiretorId);
        return Ok(output);
    }

    [HttpPost("/diretor")]
    public async Task<ActionResult<FilmeOutputPostDTO>> PostD([FromBody] FilmeInputPostDTO input)
    {
        var f = new Filme(input.Titulo, input.DiretorID);
        await _filmeserv.Post(f);
        var output = new FilmeOutputPostDTO(f.Id, f.Titulo, f.DiretorId);
        return Ok(output);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Filme>> Put(long id, [FromBody] FilmeInputPutDTO input)
    {
        var f = new Filme(input.Titulo, input.DiretorId);
        f.Id = id;
        await _filmeserv.Put(f);
        var output = new FilmeOutputPutDTO(f.Id, f.Titulo);
        return Ok(output);
    }


    [HttpGet]
    public async Task<ActionResult<FilmeListOutputGetAllDTO>> Get(CancellationToken cancellationToken, int limit = 5, int page = 1)
    {


        return await _filmeserv.GetByPageAsync(limit, page, cancellationToken);
    }

    [HttpGet]
    [Route("Id/{id}")]
    public async Task<ActionResult<FilmeOutputGetIdDTO>> GetId(long id)
    {
        var f = await _filmeserv.GetId(id);
        var output = new FilmeOutputGetIdDTO(f.Id, f.Titulo, f.Diretor.Nome);
        return Ok(output);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<Filme>> Delete(long id)
    {
        var f = await _filmeserv.Delete(id);
        return Ok(f);
    }



}