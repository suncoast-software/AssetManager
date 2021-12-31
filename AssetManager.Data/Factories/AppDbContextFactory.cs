using AssetManager.Data.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Data.Factories
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var connStr = Configuration.GetConnectionString();
            var options = new DbContextOptionsBuilder<AppDbContext>();

            options.UseNpgsql(connStr);
            return new AppDbContext(options.Options);
        }
    }
}
