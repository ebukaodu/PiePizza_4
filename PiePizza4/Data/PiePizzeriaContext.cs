using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PiePizza3.Models;

    public class PiePizzeriaContext : DbContext
    {
        public PiePizzeriaContext (DbContextOptions<PiePizzeriaContext> options)
            : base(options)
        {
        }

        public DbSet<PiePizza3.Models.Pie> Pie { get; set; }
    }
