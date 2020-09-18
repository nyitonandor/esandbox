using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace EServer.Models
{
    public class Context : DbContext
    {

        private readonly IConfiguration _configuration;
        public Context(IConfiguration configuration, DbContextOptions<Context> options) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Motorcycle> Motorcycles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) {
            dbContextOptionsBuilder.UseSqlServer(_configuration.GetConnectionString("EServerConnectionString"));
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //    modelBuilder.Entity<Motorcycle>().HasData(new
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "Yamaha XJ6",
        //        SerialNumber = "no serial number"
        //    });
        //}
    }
}
