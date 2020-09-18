using EServer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EServer.Repositories
{
    public interface IMotorcycleRepository
    {
        Task<List<Motorcycle>> GetAllAsync();

        Task<Motorcycle> GetAsync(Guid id);

        Task AddAsync(Motorcycle motorcycle);

        Task DeleteAsync(Motorcycle motorcycle);
    }
}
