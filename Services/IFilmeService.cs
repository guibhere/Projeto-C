using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFilmeService
{

    Task<Filme> Post(Filme f);
    Task<Filme> Delete(long id);
    Task<Filme> GetId(long id);
    Task<List<Filme>> GetAll();
    Task<Filme> Put(Filme f);
}