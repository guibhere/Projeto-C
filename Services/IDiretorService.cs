using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDiretorService
{
    Task<Diretor> Add(Diretor diretor);
    Task<Diretor> Delete(long id);
    Task<List<Diretor>> GetAll();

    Task<Diretor> GetById(long id);
    Task<Diretor> Update(Diretor diretor);

}