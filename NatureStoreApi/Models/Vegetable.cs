using System.ComponentModel.DataAnnotations.Schema;

namespace NatureStoreApi.Models
{
    public class Vegetable
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18,2)")] // One line annotation to specify precision for the Price property
        public decimal Price { get; set; }  
        public string? Origin { get; set; }
        public bool RipeOrNot { get; set; }
        public DateOnly DateAvailable { get; set; }
    }
}
