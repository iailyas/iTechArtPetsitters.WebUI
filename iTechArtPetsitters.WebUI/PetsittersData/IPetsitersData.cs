using iTechArtPetsitters.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.PetsittersData
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
