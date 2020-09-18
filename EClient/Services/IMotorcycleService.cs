using EClient.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EClient.Services
{
    public interface IMotorcycleService
    {
        Task<List<Motorcycle>> GetAllAsync();
        Task<Motorcycle> GetAsync(Guid id);
        Task CreateAsync(Motorcycle motorcycle);

        Task DeleteAsync(Guid id);
    }
}
