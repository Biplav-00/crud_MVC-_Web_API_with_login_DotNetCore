using crud_api.Model;
using Microsoft.EntityFrameworkCore;

namespace crud_api.Data
{
    public class PersonApiDbContext : DbContext
    {
        public PersonApiDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Person> tbl_Person { get; set; }
        public DbSet<Device> tbl_Device { get; set; }

        public DbSet<User> tbl_User { get; set; }

        
    }
}
