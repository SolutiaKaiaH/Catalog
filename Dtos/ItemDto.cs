using System;

namespace Catalog.Dtos
{
    public record ItemDto{
        public Guid Id {get; init;} //init is only allowing setting a variable during initialization

        public string Name {get; init;}

        public decimal Price {get; init;}

        public DateTimeOffset CreatedDate {get; set;}
    }
}