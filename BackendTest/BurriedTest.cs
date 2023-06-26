using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graveyard_Backend.DTOs;
using Graveyard_Backend.IRepositories;
using Graveyard_Backend.Repositories;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Moq;
using NUnit.Framework;

namespace BackendTest
{
    
    public class BurriedTest
    {
        DateOnly data1 = new DateOnly(2015, 10, 21);
        DateOnly data2 = new DateOnly(2023, 6, 21);

        //var testowy = new Burried("name", "lastname", data1, data2);
        

        Mock<IBurriedRepository> mockRepository = new Mock<IBurriedRepository>();
        //BurriedRepository burriedRepository = new UpdateById<Burried>();
        List<TestEnt> tests = new List<TestEnt>();
        TestEnt testEntity = new TestEnt(1, "test");
        TestEnt falseEntity = new TestEnt(2, "else");
        [Test]
        public void UpdateByID_returnBurried()
        {
            Mock<IBurriedRepository> mockEntity = new Mock<IBurriedRepository>();
            //mockEntity.Setup(x => x.UpdateById()).Returns(mockEntity);






        }


    }
}
