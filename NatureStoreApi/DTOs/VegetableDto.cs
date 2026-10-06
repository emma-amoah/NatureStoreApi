namespace NatureStoreApi.DTOs
{
    public record VegetableDto(
        int Id,
        string? Name,
        string? Description,
        string? Origin,
        bool RipeOrNot,
        DateOnly DateAvailable,
        decimal Price
    );

}