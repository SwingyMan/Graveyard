using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graveyard_Backend.IRepositories;
using Graveyard_Backend.Repositories;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Moq;
using NUnit.Framework;

namespace BackendTest
{
    
    public class BurriedTest
    {
        [Test]
        public void UpdateByID_returnBurried()
        {
            Mock<IBurriedRepository> mockRepository = new Mock<IBurriedRepository>();
            BurriedRepository burriedRepository = new UpdateByID<Burried>();
            List<TestEnt> tests = new List<TestEnt>();
            TestEnt testEntity = new TestEnt(1, "test");
            TestEnt falseEntity = new TestEnt(2, "else");





        }


    }
}
