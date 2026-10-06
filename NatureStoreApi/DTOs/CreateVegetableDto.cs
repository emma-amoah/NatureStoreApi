namespace NatureStoreApi.DTOs
{
    public record CreateVegetableDto
    {
        public string Name { get; init; } = string.Empty;
        public string Origin { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public bool RipeOrNot { get; init; }
        public DateTime DateAvailable { get; init; }
    }

}
