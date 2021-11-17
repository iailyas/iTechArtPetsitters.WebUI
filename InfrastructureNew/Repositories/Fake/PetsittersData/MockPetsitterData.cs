
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
        private List<PetsitterFake> petsitters = new List<PetsitterFake>()
        {
            new PetsitterFake()
            {
            Id=Guid.NewGuid(),
            Name="Petsitter 1"
            },
            new PetsitterFake()
            {
            Id=Guid.NewGuid(),
            Name="Petsitter 2"
            }
        };
        public PetsitterFake AddPetsitter(PetsitterFake Petsitter)
        {
            Petsitter.Id = Guid.NewGuid();
            petsitters.Add(Petsitter);
            return Petsitter;
        }

        public void DeletePetsitter(PetsitterFake Petsitter)
        {
            petsitters.Remove(Petsitter);
        }

        public PetsitterFake EditPetsitter(PetsitterFake petsitter)
        {
            var ExistingPetsitter = GetPetsitter(petsitter.Id);
            ExistingPetsitter.Name = petsitter.Name;
            return ExistingPetsitter;
        }

        public PetsitterFake GetPetsitter(Guid id)
        {
            return petsitters.SingleOrDefault((x=> x.Id==id));
        }

        public List<PetsitterFake> GetPetsitters()
        {
            return petsitters;
        }

        
    }
}
