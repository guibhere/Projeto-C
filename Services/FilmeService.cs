using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Linq;
using Net5_Api.Extensions;

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
        var output = new FilmeOutputPostDTO(f.Id, f.Titulo, f.DiretorId);
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
            throw new KeyNotFoundException("Diretor não encontrado");
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
        var f = await _context.Filmes.Include(d => d.Diretor).FirstOrDefaultAsync(f => f.Id == id);
        var output = new FilmeOutputGetIdDTO(f.Id, f.Titulo, f.Diretor.Nome);
        return (f);
    }


    public async Task<ActionResult<Filme>> Delete(long id)
    {
        Filme f = await _context.Filmes.FindAsync(id);
        _context.Filmes.Remove(f);
        await _context.SaveChangesAsync();
        return (f);
    }
    public async Task<FilmeListOutputGetAllDTO> GetByPageAsync(int limit, int page, CancellationToken cancellationToken)
    {
        var pagedModel = await _context.Filmes
                .AsNoTracking()
                .OrderBy(p => p.Id)
                .PaginateAsync(page, limit, cancellationToken);

        if (!pagedModel.Items.Any())
        {
            throw new Exception("Não existem filmes cadastrados!");
        }

        var CurrentPage = pagedModel.CurrentPage;
        var TotalPages = pagedModel.TotalPages;
        var TotalItems = pagedModel.TotalItems;
        var Items = pagedModel.Items.Select(filme => new FilmeOutputGetAllDTO(filme.Id, filme.Titulo, filme.Ano)).ToList();

        FilmeListOutputGetAllDTO listOutputGetAllDTO = new FilmeListOutputGetAllDTO(CurrentPage, TotalPages, TotalItems, Items);

        return listOutputGetAllDTO;
    }



}