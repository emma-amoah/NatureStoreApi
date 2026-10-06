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
    ) : CreateVegetableDto(Name, Description, Origin, RipeOrNot, DateAvailable, Price); // Inherits from CreateVegetableDto

}