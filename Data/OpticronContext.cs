using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Opticron.Models;

namespace Opticron.Data
{
    public class OpticronContext : DbContext
    {
        public OpticronContext (DbContextOptions<OpticronContext> options)
            : base(options)
        {
        }

        public DbSet<Opticron.Models.NavigationCards> NavigationCards { get; set; } = default!;
        public DbSet<Opticron.Models.SpecialOffers> SpecialOffers { get; set; } = default!;
        public DbSet<Opticron.Models.ProductCategories> ProductCategories { get; set; } = default!;
    }
}
