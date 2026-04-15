using Microsoft.EntityFrameworkCore;
using ManagementSystemAPI.Core.Models;
using ManagementSystemAPI.Data.Repositories;
using ManagementSystemAPI.Data;
using ManagementSystemAPI.Core.Models.Domain;

namespace ManagementSystemAPI.Tests
{
    public class BookTest
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task CreateUser_ShouldAddUserToDatabase()
        {
            // Arrange
            var context = GetDbContext();
            var repo = new UserRepository(context);

            var user = new User
            {
                Name = "Mariano",
                Email = "mariano@test.com"
            };

            // Act
            var result = await repo.Create(user);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Mariano", result.Name);

            var userInDb = await context.Users.FirstOrDefaultAsync();
            Assert.NotNull(userInDb);
            Assert.Equal("mariano@test.com", userInDb.Email);
        }
    }
}