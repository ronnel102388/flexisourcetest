using FLEXISOURCETEST.Models;
using FLEXISOURCETEST.Services.UserService;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLEXISOURCETEST.Test.Services
{
    public class UserServiceTest
    {
        private readonly _flexiContext _dbContext;
        private readonly IUserService _userService;
        public UserServiceTest() 
        {
            // Set up a test database context
            var options = new DbContextOptionsBuilder<_flexiContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            _dbContext = new _flexiContext(options);

            // Initialize UserService with the test DbContext
            _userService = new UserService(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        [Fact]
        public void UserService_GetAllProfile_ReturnList()
        {
           
            var result = _userService.GetAllProfile();
            result.Should().NotBeNull();
        }

        [Fact]
        public void UserService_GetUser_ReturnObject()
        {
            int Id = 1;
            var result = _userService.GetUser(Id);
            result.Should().BeOfType<Task<UserProfile>>();
        }

        [Fact]
        public void UserService_Post_ReturnObject()
        {
            var item = new UserProfile()
            {
                Name = "Ronnel",
                Weight = 73,
                Height = 172,
                BirthDate = DateTime.Parse("10/23/1988"),
            };

            var result = _userService.Post(item);
            result.Should().BeOfType<Task<UserProfile>>();
        }

        [Fact]
        public void UserService_Put_ReturnObject()
        {
            var Id = 1;
            var item = new UserProfile()
            {
                Name = "Ronnel",
                Weight = 73,
                Height = 172,
                BirthDate = DateTime.Parse("10/23/1988"),
            };

            var result = _userService.Put(Id,item);
            result.Should().BeOfType<Task<UserProfile>>();
        }
    }
}
