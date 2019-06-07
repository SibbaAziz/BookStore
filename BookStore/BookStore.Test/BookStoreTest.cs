using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStore.Test
{
    [TestClass]
    public class BookStoreTest
    {
        [TestMethod]
        public void GivenBookStore_WhenBuyOneBook_ThenPriceShouldBeThePriceInTheCatalog()
        {
            var bookStore = new BookStore();
            bookStore.Import(json);
            Assert.AreEqual(8, bookStore.Buy("J.K Rowling - Goblet Of fire"));
        }

        [TestMethod]
        public void GivenBookStore_WhenBuyManyBookOfSameCategory_ThenApplyDiscount()
        {
            var bookStore = new BookStore();
            bookStore.Import(json);
            Assert.AreEqual(18, bookStore.Buy("J.K Rowling - Goblet Of fire", "Robin Hobb - Assassin Apprentice"));
        }

        [TestMethod]
        public void GivenBookStore_WhenBuy_ThenOnlyFirtCopyOfCategoryHasDiscount()
        {
            var bookStore = new BookStore();
            bookStore.Import(json);
            Assert.AreEqual(30, bookStore.Buy("J.K Rowling - Goblet Of fire", "Robin Hobb - Assassin Apprentice", "Robin Hobb - Assassin Apprentice"));

            Assert.AreEqual(69.95, bookStore.Buy("Ayn Rand - FountainHead", "Isaac Asimov - Foundation", "Isaac Asimov - Robot series", "J.K Rowling - Goblet Of fire", "J.K Rowling - Goblet Of fire", "Robin Hobb - Assassin Apprentice", "Robin Hobb - Assassin Apprentice"));
        }

        [TestMethod]
        [ExpectedException(typeof(NotEnoughInventoryException))]
        public void GivenBookStore_WhenInvalidbasket_ThenShouldThrowException()
        {
            var bookStore = new BookStore();
            bookStore.Import(json);
            Assert.AreEqual(0, bookStore.Buy("Isaac Asimov - Foundation", "Isaac Asimov - Foundation"));
        }

        const string json = @"{ 
   'Category':[
      {
         'Name':'Science Fiction',
         'Discount':0.05
      },
      {
         'Name':'Fantastique',
         'Discount':0.1
      },
      {
         'Name':'Philosophy',
         'Discount':0.15
      }
   ],
   'Catalog':[
      {
         'Name':'J.K Rowling - Goblet Of fire',
         'Category':'Fantastique',
         'Price':8,
         'Quantity':2
      },
      {
         'Name':'Ayn Rand - FountainHead',
         'Category':'Philosophy',
         'Price':12,
         'Quantity':10
      },
      {
         'Name':'Isaac Asimov - Foundation',
         'Category':'Science Fiction',
         'Price':16,
         'Quantity':1
      },
      {
         'Name':'Isaac Asimov - Robot series',
         'Category':'Science Fiction',
         'Price':5,
         'Quantity':1
      },
      {
         'Name':'Robin Hobb - Assassin Apprentice',
         'Category':'Fantastique',
         'Price':12,
         'Quantity':8
      }
   ]
}";
    }
}
