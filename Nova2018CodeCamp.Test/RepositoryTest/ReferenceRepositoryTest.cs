using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Nova2018CodeCamp.Data.DatabaseModels;
using Nova2018CodeCamp.Data.Repository;
using Xunit;

namespace Nova2018CodeCamp.Test.RepositoryTest
{
    public class ReferenceRepositoryTest
    {
        private Nova2018CodeCampContext _context;

        public ReferenceRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<Nova2018CodeCampContext>()
                .UseInMemoryDatabase(databaseName: "ReferenceRepository")
                .Options;

            _context = new Nova2018CodeCampContext(options);

        }

        [Fact]
        public void AddSport_When_executed_add_sport()
        {
            var sport = new Sport()
            {
                Name = "Basketball"
            };

            var repository = new ReferenceRepository(_context);

            var id = repository.AddSport(sport);

            var sports = _context.Sport.ToListAsync();
            Assert.Single(sports.Result);
            Assert.True(sports.Result[0].Id > 0);
            Assert.Equal(sport.Name, sports.Result[0].Name);

        }


    }
}
