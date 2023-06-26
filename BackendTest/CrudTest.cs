using Graveyard_Backend.IRepositories;
using Graveyard_Backend.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BackendTest
{
	public class TestEnt
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public TestEnt() { }
        public TestEnt(int id,string name) {
            ID = id;
        this.Name = name;
        }
    }
    public class CrudTest
    {
        Mock<ICRUDRepository<TestEnt>> mockRepository = new Mock<ICRUDRepository<TestEnt>>();
        CRUDRepository<TestEnt> crudRepository = new CRUDRepository<TestEnt>();
        List<TestEnt> tests = new List<TestEnt>();
        TestEnt testEntity = new TestEnt(1, "test");
        TestEnt falseEntity = new TestEnt(2, "else");


        [Test]
        public void AddEntity_ReturnEntity()
        {
            var mockEntity = new Mock<ICRUDRepository<TestEnt>>();
            mockEntity.Setup(x => x.add(testEntity)).ReturnsAsync(testEntity);
            //var crud = new CRUDRepository<Test>(mockEntity.Object);
            var result = crudRepository.add(testEntity);


            //NUnit.Framework.Assert.AreEqual(mockEntity.Name, "test");


        }




        //[Fact]
        //public void Add_Entity_ExpectedBehaviour()
        //{
        //    string testName = "test";
        //    //mockRepository.Setup(x => x.add(testEntity)).ReturnsAsync(testEntity);
        //    //var result = crudRepository.add(testEntity);
        //    //Xunit.Assert.NotNull(result);
        //    //Xunit.Assert.Equal(testEntity.Name, testName);
      
            
        //}
        //[Fact]
        //public void GetByID_Entity_ExpectedBehaviour()
        //{

        //    TestEnt testEntity = new TestEnt(1, "test");
        //    mockRepository.Setup(x => x.getByID(1)).ReturnsAsync(testEntity);
        //    var result = crudRepository.getByID(1);
        //    //Xunit.Assert.NotNull(result);
        //}
        //[Fact]
        //public void GetAllFromGenericRepository()
        //{
        //    mockRepository.Setup(x => x.ListAll(1)).ReturnsAsync(tests);
        //}
    }
}
