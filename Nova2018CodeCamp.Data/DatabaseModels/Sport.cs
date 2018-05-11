using System.Collections.Generic;

namespace Nova2018CodeCamp.Data.DatabaseModels
{
    public partial class Sport
    {
        public Sport()
        {
            Location = new HashSet<Location>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool CanRegister { get; set; }

        public ICollection<Location> Location { get; set; }
    }
}
