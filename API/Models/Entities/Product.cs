namespace API.Models.Entities
{
    public class Product : BaseEntity
    {
        public int Amount { get; set; }
        public string EAN { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }
        public string Descrition { get; set; }
        public decimal MediumPrice { get; set; }
        public List<Movement> Movements { get; set; }

        public Product()
        {
            DateInclude = DateTime.Now;
            Available = true;
        }

        public Product(int amount, string ean, string name, string description = null)
        {
            Descrition = description ?? string.Empty;
            Amount = amount;
            EAN = ean;
            Name = name;
            DateInclude = DateTime.Now;
            Available = true;
        }
    }
}
