using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ETicaretDbContext>
    {
        //.NET CLI uzerinden migrate etmek ucun
        public ETicaretDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ETicaretDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql("User ID=postgres;Password=runle303;Host=localhost;Port=5432;Database=ETicaretAPIDb");
            return new ETicaretDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
