using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nova2018CodeCamp.Data.DatabaseModels;
using Nova2018CodeCamp.Data.Interface;
using Nova2018CodeCamp.Model.DataViewModel;

namespace Nova2018CodeCamp.Data.Worker
{
    public class ReferenceWorker
    {
        private IReferenceRepository _repository;

        public ReferenceWorker(IReferenceRepository repository)
        {
            _repository = repository;
        }

        public async Task<SportLocationView> AddSport(SportLocationView view)
        {
            var sport = new Sport { Name = view.SportName };
            view.SportId = await _repository.AddSport(sport);

            var location = new Location { Name = view.LocationName, SportId = view.SportId};
            view.LocationId = await _repository.AddLocation(location);

            return view;
        }
    }
}
