namespace Nova2018CodeCamp.Data.DatabaseModels
{
    public partial class Coach
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int LocationId { get; set; }

        public Location Location { get; set; }
    }
}
