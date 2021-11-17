
using iTechArtPetsitters.WebUI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Infrastructure.Repositories.Fake.PetsitterData
{
    public interface IPetsitersData
    {
        List<PetsitterFake> GetPetsitters();

        PetsitterFake GetPetsitter(Guid id);

        PetsitterFake AddPetsitter(PetsitterFake Petsitter);

        void DeletePetsitter(PetsitterFake Petsitter);

        PetsitterFake EditPetsitter(PetsitterFake petsitter);

    }
}
