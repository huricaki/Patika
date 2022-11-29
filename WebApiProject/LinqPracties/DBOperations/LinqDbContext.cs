using Microsoft.EntityFrameworkCore;

namespace LinqPRACTİCES.DBOperations
{
    public class LinqDbContext:DbContext
    {
        public DbSet<Student> Students{get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseInMemoryDatabase(databaseName:"LinqDb");

        }
    }
}