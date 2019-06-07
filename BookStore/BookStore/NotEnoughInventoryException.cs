using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public interface INameQuantity
    {
        string Name { get; }
        int Quantity { get; }
    }

    public class NameQuantity : INameQuantity
    {
        public string Name
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }
    }

    public class NotEnoughInventoryException : Exception
    {
        public NotEnoughInventoryException(IEnumerable<INameQuantity> missing)
        {
            Missing = missing;
        }
        public IEnumerable<INameQuantity> Missing { get; }
    }
}
