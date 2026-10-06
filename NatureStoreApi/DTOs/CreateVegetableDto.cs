using System.ComponentModel.DataAnnotations;

namespace NatureStoreApi.DTOs;

public record CreateVegetableDto( // Validation attributes added to the properties of CreateVegetableDto
    [property: Required(ErrorMessage = "Name is required")]
    [property: StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    String? Name,

    [property: StringLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
    String? Description,

    [property: Required(ErrorMessage = "Origin is required")]
    [property: StringLength(100, ErrorMessage = "Origin cannot exceed 100 characters")]
    String? Origin,

    [property: Required(ErrorMessage = "RipeOrNot is required")]
    bool RipeOrNot,

    [property: Required(ErrorMessage = "DateAvailable is required")]
    DateOnly DateAvailable,

    [property: Required(ErrorMessage = "Price is required")]
    [property: Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
    decimal Price
);

