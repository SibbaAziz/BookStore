using System;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            BookStore bookStore = new BookStore();

            bookStore.Import(json);

            Console.WriteLine($"Quantity of 'Ayn Rand - FountainHead' : {bookStore.Quantity("Ayn Rand - FountainHead")}");
            Console.WriteLine($"Buy 'J.K Rowling - Goblet Of fire' and 'Isaac Asimov - Foundation' : {bookStore.Buy("J.K Rowling - Goblet Of fire", "Isaac Asimov - Foundation")}");
            Console.ReadLine();
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
