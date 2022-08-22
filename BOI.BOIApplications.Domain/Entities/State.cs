namespace BOI.BOIApplications.Domain.Entities
{
    public class State
    {
        //public int StateId { get; set; }
        //public string? StateName { get; set; }
        public int id { get; set; }
        public string? name { get; set; }
        public ICollection<LGA>? LocalGovtArea { get; set; }
    }
}
