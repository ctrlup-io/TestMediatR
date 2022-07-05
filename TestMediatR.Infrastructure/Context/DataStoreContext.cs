using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMediatR.Infrastructure.Entities;

namespace TestMediatR.Infrastructure.Context
{
    public  class DataStoreContext : DbContext
    {
     
        public DataStoreContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>()
                .Property(i => i.Id)
                .HasDefaultValueSql("newid()");
        }
        public DbSet<ProductEntity> Product { get; set; }
    }
}
