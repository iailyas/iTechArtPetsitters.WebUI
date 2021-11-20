using DomainNew.Models;
using System.Threading.Tasks;

namespace DomainNew.Service.Interfaces
{
    interface IPetService
    {
        Task CreateAsync(Pet pet);
        Task<Pet> DeleteAsync(long id);
    }
}
