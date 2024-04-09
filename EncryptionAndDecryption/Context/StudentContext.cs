using EncryptionAndDecryption.Model;
using Microsoft.EntityFrameworkCore;

namespace EncryptionAndDecryption.Context
{
    public class StudentContext : DbContext
    {  
        public StudentContext(DbContextOptions<StudentContext> options):base(options)
        {

        }

        public DbSet<Student> StudentData { get; set; }
    }
}
