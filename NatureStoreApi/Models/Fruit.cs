namespace NatureStoreApi.Models
{
    public class Fruit
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Origin { get; set; }
        public bool RipeOrNot { get; set; }
        public DateOnly DateAvailable { get; set; }
    }
}
