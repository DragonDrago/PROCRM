using ProCrm.Ldi.Api.Domain;
using ProCrm.Ldi.Api.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ProCrm.Ldi.Api.Repositories
{
    public interface ILdiRepository
    {
        Task<int>CreateOrUpdateAsync(LdiDomain domain);
        Task<IEnumerable<LdiDomain>> All(LdiFilter ldiFilter);
        Task<bool>Remove(int id);
    }
}
