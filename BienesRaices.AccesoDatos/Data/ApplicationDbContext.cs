using BienesRaices.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BienesRaices.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Models
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Propiedade> Propiedade { get; set; }
    }
}