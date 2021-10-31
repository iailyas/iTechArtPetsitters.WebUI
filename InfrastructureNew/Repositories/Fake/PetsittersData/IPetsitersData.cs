
using iTechArtPetsitters.WebUI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Infrastructure.Repositories.Fake.PetsitterData
{
    public interface IPetsitersData
    {
        List<Petsitter> GetPetsitters();

        Petsitter GetPetsitter(Guid id);

        Petsitter AddPetsitter(Petsitter Petsitter);

        void DeletePetsitter(Petsitter Petsitter);

        Petsitter EditPetsitter(Petsitter petsitter);

    }
}
