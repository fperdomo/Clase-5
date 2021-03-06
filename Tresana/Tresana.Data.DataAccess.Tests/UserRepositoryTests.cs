﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Tresana.Data.DataAccess;
using Tresana.Data.Entities;
using Xunit;

namespace Tresana.Data.Repository.Tests
{
    public class UserRepositoryTests
    {
        [Fact]
        public void GetAllUsersTest()
        {

            var data = GetUserList();
            var set = new Mock<DbSet<User>>().SetupData(data);

            var context = new Mock<TresanaContext>();
            context.Setup(ctx => ctx.Set<User>()).Returns(set.Object);

            var unitOfWork = new UnitOfWork(context.Object);

            IEnumerable<User> result = unitOfWork.UserRepository.Get();
            
            Assert.Equal(result.Count(), data.Count);

        }

        private List<User> GetUserList()
        {
            return new List<User>
            {
                new User()
                {
                    Name = "Gabriel",
                    LastName = "Piffaretti",
                    UserName = "piffarettig",
                    Mail = "piffarettig@gmail.com",
                    Id = 1
                },
                new User()
                {
                    Name = "ignacio",
                    LastName = "valle",
                    UserName = "ivalle",
                    Mail = "ignaciovalle@gmail.com",
                    Id = 2
                }
            };
        }
    }
}
