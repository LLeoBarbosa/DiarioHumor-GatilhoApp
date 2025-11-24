using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHG.DataAccess.Context
{
    public class DiarioDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();         
                       
            string connectionString = "Data Source=DESKTOP-LQU3KL7\\MSSQLSERVER14;Initial Catalog=db_humorgatilho;Integrated Security=True;TrustServerCertificate=True";
                   
            optionsBuilder.UseSqlServer(connectionString);                     

            return new ApplicationDbContext(optionsBuilder.Options);

        }
    }
}
