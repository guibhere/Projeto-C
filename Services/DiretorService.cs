using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Net5_Api.Extensions;

public class DiretorService : IDiretorService
{
    private readonly AplicationDbContext _context;
    public DiretorService(AplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Diretor> Add(Diretor diretor)
    {
        _context.Diretores.Add(diretor);
        await _context.SaveChangesAsync();
        return diretor;
    }

    public async Task<Diretor> Delete(long id)
    {
        var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == id);
        _context.Remove(diretor);
        await _context.SaveChangesAsync();
        return diretor;
    }

    public async Task<List<Diretor>> GetAll()
    {
        var diretores = await _context.Diretores.ToListAsync();
        return diretores;
    }


    public async Task<Diretor> Update(Diretor diretor)
    {
        _context.Diretores.Update(diretor);
        await _context.SaveChangesAsync();
        return diretor;
    }

    public async Task<DiretorListOutputGetAllDTO> GetByPageAsync(int limit, int page, CancellationToken cancellationToken)
    {
        var pagedModel = await _context.Diretores
                .AsNoTracking()
                .OrderBy(p => p.Id)
                .PaginateAsync(page, limit, cancellationToken);

        if (!pagedModel.Items.Any())
        {
            throw new Exception("Não existem diretores cadastrados!");
        }

        var CurrentPage = pagedModel.CurrentPage;
        var TotalPages = pagedModel.TotalPages;
        var TotalItems = pagedModel.TotalItems;
        var Items = pagedModel.Items.Select(diretor => new DiretorOutputGetAllDTO(diretor.Id, diretor.Nome)).ToList();

        DiretorListOutputGetAllDTO listOutputGetAllDTO = new DiretorListOutputGetAllDTO(CurrentPage, TotalPages, TotalItems, Items);

        return listOutputGetAllDTO;
    }
    public async Task<Diretor> GetById(long id)
    {
        var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == id);

        if (diretor == null)
        {
            throw new System.Exception("Não existem diretores cadastrados!");
        }

        return diretor;
    }

}