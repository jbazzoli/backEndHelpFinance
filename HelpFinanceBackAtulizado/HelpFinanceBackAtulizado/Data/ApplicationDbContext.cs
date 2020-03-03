using helpFinanceDotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace helpFinanceDotNet.Data
{
    public class ApplicationDbContext : DbContext
    {       
         public virtual DbSet<Debit> Debit { get; set; }

         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}