using DomainNew.Models;

namespace DomainNew.Interfaces
{
   public interface IPetRepository
    {
        void Create(Pet pet);
        Pet Delete(long id);
    }
}
