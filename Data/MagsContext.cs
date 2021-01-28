using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mags.Models;

namespace Mags.Data
{
    public class MagsContext : DbContext
    {
        public MagsContext (DbContextOptions<MagsContext> options)
            : base(options)
        {
        }

        public DbSet<Mags.Models.Produs> Produs { get; set; }

        public DbSet<Mags.Models.Comanda> Comanda { get; set; }

        public DbSet<Mags.Models.Stoc> Stoc { get; set; }

        public DbSet<Mags.Models.Receptie> Receptie { get; set; }


    }
}
