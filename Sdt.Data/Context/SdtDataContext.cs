using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sdt.Domain.Entities;

namespace Sdt.Data.Context
{
    public class SdtDataContext : DbContext
    {
        public DbSet<Autor> Autoren { get; set; }
        public DbSet<Spruch> Sprueche { get; set; }

        public SdtDataContext(DbContextOptions<SdtDataContext> options) : base(options)
        {
           // Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }
    }
}
