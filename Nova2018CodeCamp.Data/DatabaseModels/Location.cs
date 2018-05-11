using System.Collections.Generic;

namespace Nova2018CodeCamp.Data.DatabaseModels
{
    public partial class Location
    {
        public Location()
        {
            Coach = new HashSet<Coach>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int SportId { get; set; }

        public Sport Sport { get; set; }
        public ICollection<Coach> Coach { get; set; }
    }
}
