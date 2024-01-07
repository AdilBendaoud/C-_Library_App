namespace please2.Models
{
    public class Livre
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string img {  get; set; }
        public double price { get; set; }
        public Author author { get; set; }
        public Category category { get; set; }
        public string edition { get; set; }
        public DateTime distribution { get; set; }
        public string description { get; set; }

    }
}
