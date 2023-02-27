using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos{
    //we only need name and price to create an item
    public record UpdateItemDto{
        [Required]
         public string Name {get; init;}
         [Required]
         [Range(1,1000)]
        public decimal Price {get; init;}
    }
}