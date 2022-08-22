namespace BOI.BOIApplications.Domain.Entities
{
    public class Country
    {
        //public int CountryID { get; set; }
        //public string? CountryName { get; set; }
        public int id { get; set; }
        public string? name { get; set; }
        public ICollection<State>? States { get; set; }
    }
}
