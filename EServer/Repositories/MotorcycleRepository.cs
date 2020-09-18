using EServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EServer.Repositories
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly Context _dbContext;
        private readonly ILogger<MotorcycleRepository> _logger;

        public MotorcycleRepository(Context dbContext, ILogger<MotorcycleRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<Motorcycle>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Set<Motorcycle>().ToListAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve motorcycles");
            }

        }

        public async Task<Motorcycle> GetAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException($"id must not be null");
            }

            try
            {
                return await _dbContext.Set<Motorcycle>().FindAsync(id).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw new Exception($"Couldn't retrieve motorcycle with id: {id}");
            }
        }

        public async Task AddAsync(Motorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException($"{nameof(motorcycle)} must not be null");
            }

            try
            {
                await _dbContext.Set<Motorcycle>().AddAsync(motorcycle).ConfigureAwait(false);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(motorcycle)} could not be saved");
            }
        }

        public async Task DeleteAsync(Motorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException($"{nameof(motorcycle)} must not be null");
            }

            try
            {
                _dbContext.Set<Motorcycle>().Remove(motorcycle);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(motorcycle)} could not be saved");
            }
        }
    }
}
