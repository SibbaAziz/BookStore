using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace BookStore
{
    public class BookStore : IStore
    {
        public void ValidBasket(params string[] basketByNames)
        {
            var copies = new Dictionary<string, int>();
            List<NameQuantity> missing = new List<NameQuantity>();

            foreach (var item in basketByNames)
            {
                if (copies.ContainsKey(item))
                {
                    copies[item] = copies[item] + 1;
                }
                else
                {
                    copies.Add(item, 1);
                }
            }

            foreach (var item in copies)
            {
                var book = StoreDataSource.StoreData.Catalog.FirstOrDefault(c => c.Name == item.Key);
                if (book.Quantity < item.Value)
                    missing.Add(new NameQuantity() { Name = book.Name, Quantity = book.Quantity });
            }

            if (missing.Any())
                throw new NotEnoughInventoryException(missing);
            
        }
        public double Buy(params string[] basketByNames)
        {
            ValidBasket(basketByNames);

            if (basketByNames.Count() == 1)
                return StoreDataSource.StoreData.Catalog.FirstOrDefault(c => c.Name == basketByNames[0])?.Price ?? 0;

            var books = StoreDataSource.StoreData.Catalog.Where(c => basketByNames.Contains(c.Name));
            var categories = books.Select(c => c.Category).Distinct();
            var sameCategory = categories.Count() == 1;
            var isDistinct = basketByNames.Distinct().Count() == basketByNames.Count();
            if (sameCategory && isDistinct)
            {
                var category = categories.FirstOrDefault();
                var discount = StoreDataSource.StoreData.Category.FirstOrDefault(c => c.Name == category).Discount;
                return books.Sum(c => c.Price) * (1 - discount);
            }

           
            double price = 0;
            List<string> copies = new List<string>();
            foreach (var item in basketByNames)
            {
                var book = StoreDataSource.StoreData.Catalog.FirstOrDefault(c => c.Name == item);
                var otherBookInSameCategory = books.Where(c => c.Category == book.Category).Count() > 1;
                if (!copies.Contains(book.Name) && otherBookInSameCategory)
                {
                    var discount = StoreDataSource.StoreData.Category.FirstOrDefault(c => c.Name == book.Category).Discount;
                    price += book.Price * (1 - discount);
                }
                else
                {
                    price += book.Price;
                }
                copies.Add(item);
            }

            return price;
        }

        public void Import(string catalogAsJson)
        {
            StoreDataSource.StoreData = JsonConvert.DeserializeObject<StoreData>(catalogAsJson);
        }

        public int Quantity(string name)
        {
            return StoreDataSource.StoreData.Catalog.Where(c => c.Name == name).Sum(c => c.Quantity);
        }
    }
}
