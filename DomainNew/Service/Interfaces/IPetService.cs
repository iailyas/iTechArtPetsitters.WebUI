using DomainNew.Models;
using System.Threading.Tasks;

namespace DomainNew.Service.Interfaces
{
    public interface IPetService
    {
        Task CreateAsync(Pet pet);
        Task<Pet> DeleteAsync(long id);
    }
}
