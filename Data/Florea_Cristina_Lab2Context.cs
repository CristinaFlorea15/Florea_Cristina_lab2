using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Florea_Cristina_Lab2.Models;

namespace Florea_Cristina_Lab2.Data
{
    public class Florea_Cristina_Lab2Context : DbContext
    {
        public Florea_Cristina_Lab2Context (DbContextOptions<Florea_Cristina_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Florea_Cristina_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Florea_Cristina_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    }
}
