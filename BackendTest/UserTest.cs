using Castle.Core.Resource;
using Graveyard_Backend.Controllers;
using Graveyard_Backend.IRepositories;
using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using ILogger = Serilog.ILogger;
namespace BackendTest
{
	public class UserTest
    {
        Mock<ICustomerRepository> repository = new Mock<ICustomerRepository>();
        Customer customers =
            new Customer()
            {
                CustomerId = 1,
                Name = "Grzegorz",
                LastName = "Mazurkiewicz",
                Email = "grzegorz.mazurkiewicz@gmail.com",
                Date_of_creation = DateTime.Now,
                Owned_role = Role.User,
                Password = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3",
            };
        [Fact]
        public void CheckFindingByEmail()
        {
            repository.Setup(x=>x.getByEmail(It.IsAny<string>())).ReturnsAsync(customers);
        }
        [Fact]
        public void CheckFindingByEmailAndPassword()
        {

        }
    }
}