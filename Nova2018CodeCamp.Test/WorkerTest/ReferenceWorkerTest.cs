using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Nova2018CodeCamp.Data.DatabaseModels;
using Nova2018CodeCamp.Data.Interface;
using Nova2018CodeCamp.Data.Worker;
using Nova2018CodeCamp.Model.DataViewModel;
using Xunit;

namespace Nova2018CodeCamp.Test.WorkerTest
{
    public class ReferenceWorkerTest
    {

        private Mock<IReferenceRepository> _repository;
        private ReferenceWorker _worker;

        public ReferenceWorkerTest()
        {
            _repository = new Mock<IReferenceRepository>();
            _worker = new ReferenceWorker(_repository.Object);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        public void AddSportLocation_When_executed_Then_Create_Sport_and_Location(int sportId, int locationId)
        {

            _repository.Setup(mock => mock.AddSport(It.IsAny<Sport>())).ReturnsAsync(sportId);
            _repository.Setup(mock => mock.AddLocation(It.IsAny<Location>())).ReturnsAsync(locationId);

            var view = new SportLocationView
            {
                LocationName = "Woodbridge",
                SportName = "Basketball",
                Year = 2018
            };

            var actual = _worker.AddSport(view);

            Assert.True(actual.Result.SportId == sportId);
            Assert.True(actual.Result.LocationId == locationId);
            _repository.Verify(mock => mock.AddSport(It.Is<Sport>(s => s.Name == view.SportName)), Times.Once);
            _repository.Verify(mock => mock.AddLocation(It.Is<Location>(l => l.Name == view.LocationName)), Times.Once);
        }

    }
}
