namespace NatureStoreApi.DTOs;

public record CreateVegetableDto(
    String? Name,
    String? Description,
    String? Origin,
    bool RipeOrNot,
    DateOnly DateAvailable,
    decimal Price
);

