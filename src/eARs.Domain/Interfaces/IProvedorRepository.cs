using System.Collections.Generic;
using System.Threading.Tasks;

namespace eARs.Domain.Interfaces
{
    public interface IProvedorRepository
    {
        Task<IEnumerable<Provedor>> List();
        Task<Provedor> Get(int idProvedor);
        Task<Provedor> Save(Provedor provedor);
        Task<bool> Update(Provedor provedor);
        Task<bool> Delete(int idProvedor);
    }
}
