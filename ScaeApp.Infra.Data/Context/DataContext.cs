using Microsoft.EntityFrameworkCore;
using ScaeApp.Domain.Entities;
using ScaeApp.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaeApp.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("BDScaeApp");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
        }

        public DbSet<Cliente> Cliente { get; set; }
    }
}
