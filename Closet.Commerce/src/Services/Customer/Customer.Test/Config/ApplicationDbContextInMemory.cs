using Customer.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Customer.Test.Config
{
    public static class ApplicationDbContextInMemory
    {
        public static ApplicationDbContext Get()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Customer.db")
                .Options;
            return new ApplicationDbContext(options);
        }
    }
}