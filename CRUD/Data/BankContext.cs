using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {

        }
        
        public DbSet<ContactModel> Contacts { get; set; }
    }
}
