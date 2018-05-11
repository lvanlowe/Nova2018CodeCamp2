using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
            return view;
        }
    }
}
