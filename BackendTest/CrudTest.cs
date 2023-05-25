using Graveyard_Backend.IRepositories;
using Graveyard_Backend.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTest
{
	public class Test
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public Test() { }
        public Test(int id,string name) {
            ID = id;
        this.Name = name;
        }
    }
    public class CrudTest
    {
        Mock<ICRUDRepository<Test>> mockRepository = new Mock<ICRUDRepository<Test>>();
        CRUDRepository<Test> crudRepository = new CRUDRepository<Test>();
        List<Test> tests = new List<Test>();
        Test testEntity = new Test(1, "test");
        Test falseEntity = new Test(2, "else");

        [Fact]
        public void Add_Entity_ExpectedBehaviour()
        {
            string testName = "test";
            mockRepository.Setup(x => x.add(testEntity)).ReturnsAsync(testEntity);
            var result = crudRepository.add(testEntity);
            Assert.NotNull(result);
            Assert.Equal(testEntity.Name, testName);
      
            
        }
        [Fact]
        public void GetByID_Entity_ExpectedBehaviour()
        {

            Test testEntity = new Test(1, "test");
            mockRepository.Setup(x => x.getByID(1)).ReturnsAsync(testEntity);
            var result = crudRepository.getByID(1);
            Assert.NotNull(result);
        }
        [Fact]
        public void GetAllFromGenericRepository()
        {
            mockRepository.Setup(x => x.ListAll(1)).ReturnsAsync(tests);
        }
    }
}
