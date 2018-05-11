using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nova2018CodeCamp.Data.DatabaseModels;
using Nova2018CodeCamp.Data.Interface;

namespace Nova2018CodeCamp.Data.Repository
{
    public class ReferenceRepository : IReferenceRepository
    {
        private Nova2018CodeCampContext _context;

        public ReferenceRepository(Nova2018CodeCampContext context)
        {
            _context = context;
        }

        public async Task<int> AddSport(Sport sport)
        {
            _context.Sport.Add(sport);
            var isGood = await _context.SaveChangesAsync();
            return sport.Id;
        }

        public Task<int> AddLocation(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
