﻿using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service.Interfaces
{
    public interface IPetService
    {
        Task CreateAsync(Pet pet);
        Task<IEnumerable<Pet>> GetAsync();
        Task<Pet> GetAsync(long id);
        Task<Pet> DeleteAsync(long id);
    }
}
