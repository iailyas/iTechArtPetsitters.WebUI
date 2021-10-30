using iTechArtPetsitters.WebUI2.Domain.Models;
using System;
using System.Collections.Generic;
namespace iTechArtPetsitters.WebUI2.Infrastructure.Repositories.Fake.PetsittersData
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
