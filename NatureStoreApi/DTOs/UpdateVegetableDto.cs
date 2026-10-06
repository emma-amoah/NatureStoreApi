// Structural record type change for updating a vegetable, inheriting from CreateVegetableDto
using NatureStoreApi.DTOs;

public record UpdateVegetableDto(
    string? Name,
    string? Description,
    string? Origin,
    bool RipeOrNot,
    DateOnly DateAvailable,
    decimal Price
) : CreateVegetableDto(Name, Description, Origin, RipeOrNot, DateAvailable, Price);
