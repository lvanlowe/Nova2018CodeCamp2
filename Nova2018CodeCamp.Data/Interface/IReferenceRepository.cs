using System.Threading.Tasks;
using Nova2018CodeCamp.Data.DatabaseModels;

namespace Nova2018CodeCamp.Data.Interface
{
    public interface IReferenceRepository
    {
        Task<int> AddSport(Sport sport);
        Task<int> AddLocation(Location location);

    }
}