using DHG.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHG.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
        public DbSet<RegistroDiario> RegistrosDiarios { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<RegistroDiario>().HasKey(rd => rd.Id);
                       
            modelBuilder.Entity<RegistroDiario>().Property(rd => rd.Id).ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }

    }

}
