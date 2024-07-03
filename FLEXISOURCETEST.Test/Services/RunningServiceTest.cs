using FLEXISOURCETEST.Models;
using FLEXISOURCETEST.Services.RunningService;
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
    public class RunningServiceTest
    {
        private readonly _flexiContext _dbContext;
        private readonly IRunningService _runningService;
        private readonly IUserService _userService;
        public RunningServiceTest()
        {
            // Set up a test database context
            var options = new DbContextOptionsBuilder<_flexiContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            _dbContext = new _flexiContext(options);
            _userService = new UserService(_dbContext);
            // Initialize UserService with the test DbContext
            _runningService = new RunningService(_dbContext,_userService);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        [Fact]
        public void RunningService_Put_ReturnObject()
        {
            var Id = 1;
            var item = new RunningActivity()
            {
                UserId = Id,
                Location = "San Mateo",
                StartTime = DateTime.Parse("7/3/2024 5:00 PM"),
                EndTime = DateTime.Parse("7/3/2024 8:00 PM"),
                DistanceKm = 170

            };

            var result = _runningService.PostRunning(Id, item);
            result.Should().BeOfType<Task<UserProfile>>();
        }
    }
}
