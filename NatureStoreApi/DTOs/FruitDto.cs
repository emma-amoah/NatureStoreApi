namespace NatureStoreApi.DTOs
{
    public record FruitDto(
        int Id,
        string? Name,
        string? Origin,
        string? Description,
        DateOnly DateAvailable,
        decimal Price
    );
}
