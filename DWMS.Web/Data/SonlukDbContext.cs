using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWMS.Domain;
using Microsoft.EntityFrameworkCore;

namespace DWMS.Web.Data
{
    public class SonlukDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=10.1.22.1;Initial Catalog=YCLSY;User ID=sa;Password=Sonluk2017;MultipleActiveResultSets =true"
            );
        }
        public DbSet<BarCode> Leagues { get; set; }
    }
}
