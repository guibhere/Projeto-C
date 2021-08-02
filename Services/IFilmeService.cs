using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IFilmeService
{

    Task<Filme> Post(Filme f);
    Task<Filme> Delete(long id);
    Task<Filme> GetId(long id);
    Task<List<Filme>> GetAll();
    Task<FilmeListOutputGetAllDTO> GetByPageAsync(int limit, int page, CancellationToken cancellationToken);
    Task<Filme> Put(Filme f);
}