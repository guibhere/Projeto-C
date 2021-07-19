using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

public class FilmeService 
{
    private readonly AplicationDbContext _context;
    public FilmeService(AplicationDbContext context)
    {
        _context = context;
    }

 
    public async Task<Filme> Post(Filme f)
    {
        _context.Filmes.Add(f);
        await _context.SaveChangesAsync();
        var output = new FilmeOutputPostDTO(f.Id,f.Titulo,f.DiretorId);
        return (f);
    }
  
    public async Task<Filme> Put(Filme f)
    {
        if ((f.Titulo == null) || (f.Titulo == ""))
        {
           throw new ArgumentException("Nome do Filme é necessário!");
        }
        var d = await _context.Diretores.FindAsync(f.DiretorId);
        if (d == null)
        {
            throw new KeyNotFoundException ("Diretor não encontrado");
        }

        _context.Filmes.Update(f);
        await _context.SaveChangesAsync();
        return (f);
    }

    public async Task<List<Filme>> GetAll()
    {
        return await _context.Filmes.Include(d => d.Diretor).ToListAsync();
    } 


    public async Task<Filme> GetId(long id)
    {
        var f = await _context.Filmes.Include(d => d.Diretor).FirstOrDefaultAsync(f=> f.Id == id);
        var output = new FilmeOutputGetIdDTO(f.Id,f.Titulo,f.Diretor.Nome);
        return (f);
    }

 
    public async Task<ActionResult<Filme>> Delete(long id)
    {
        Filme f = await _context.Filmes.FindAsync(id);
        _context.Filmes.Remove(f);
        await _context.SaveChangesAsync();
        return (f);
    }



}