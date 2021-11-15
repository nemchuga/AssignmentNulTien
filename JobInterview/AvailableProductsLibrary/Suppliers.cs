using System;
using System.Collections.Generic;
namespace AvailableProductsLibrary{
    public class Suppliers{
        public Guid Id{get; set;}
        public string Name{get; set;}
        public byte Markup{get; set;}
        public List<Products> ListOfProducts {get; set;} = new List<Products>();
        
    }
}
