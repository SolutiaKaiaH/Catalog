using System;

namespace Catalog.Entities{
    //record is like a class
    public record Item{
        public Guid Id {get; init;} //init is only allowing setting a variable during initialization

        public string Name {get; init;}

        public decimal Price {get; init;}

        public DateTimeOffset CreatedDate {get; set;}
    }
}