using System.Collections.Generic;

namespace BookStore
{
    public class Category
    {
        public string Name { get; set; }
        public double Discount { get; set; }
    }

    public class Catalog
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

   
    public class StoreData
    {
        public List<Category> Category { get; set; }
        public List<Catalog> Catalog { get; set; }
    }

    public static class StoreDataSource
    {
        public static StoreData StoreData { get; set; }
    }
}
