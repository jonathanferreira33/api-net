namespace API.Models.Entities
{
    public class Vacation : BaseEntity
    {
        public DateTime start { get; set; }
        public int numberOfdays { get; set; }
        public DateTime end { get; set; }
    }
}
