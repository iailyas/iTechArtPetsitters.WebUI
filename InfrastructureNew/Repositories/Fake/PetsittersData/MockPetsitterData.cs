
using iTechArtPetsitters.WebUI.Domain.Models;
using iTechArtPetsitters.WebUI.Infrastructure.Repositories.Fake.PetsitterData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.PetsittersData
{
    public class MockPetsitterData : IPetsitersData
    {
        private List<Petsitter> petsitters = new List<Petsitter>()
        {
            new Petsitter()
            {
            Id=Guid.NewGuid(),
            Name="Petsitter 1"
            },
            new Petsitter()
            {
            Id=Guid.NewGuid(),
            Name="Petsitter 2"
            }
        };
        public Petsitter AddPetsitter(Petsitter Petsitter)
        {
            Petsitter.Id = Guid.NewGuid();
            petsitters.Add(Petsitter);
            return Petsitter;
        }

        public void DeletePetsitter(Petsitter Petsitter)
        {
            petsitters.Remove(Petsitter);
        }

        public Petsitter EditPetsitter(Petsitter petsitter)
        {
            var ExistingPetsitter = GetPetsitter(petsitter.Id);
            ExistingPetsitter.Name = petsitter.Name;
            return ExistingPetsitter;
        }

        public Petsitter GetPetsitter(Guid id)
        {
            return petsitters.SingleOrDefault((x=> x.Id==id));
        }

        public List<Petsitter> GetPetsitters()
        {
            return petsitters;
        }

        
    }
}
