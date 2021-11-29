﻿using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service.Interfaces
{
    public interface IPetsittingJobService
    {
        Task<IEnumerable<PetsittingJob>> GetAsync();
        Task<PetsittingJob> GetAsync(long id);
        Task CreateAsync(AddPetsittingJobCommand addPetsittingJobCommand);
        Task UpdateAsunc(AddPetsittingJobCommand addPetsittingJobCommand);
        Task<PetsittingJob> DeleteAsync(long id);
    }
}
