using System;

namespace AvailableProductsLibrary{
    public class Products{
        public Guid Id {get; set;}
        public string Name {get; set;}
        public int Quantity {get; set;}
        public int InitialPrice {get; set;}
        public decimal SellingPrice (int Markup){
            return (decimal)(InitialPrice + InitialPrice * Markup * 0.01);
        }
        public bool IsAvailable(){
            if (Quantity > 0){
                return true;
            }
            else return false;
        }
    }
}