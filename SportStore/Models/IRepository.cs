using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models
{
    public class IRepository
    {
        IEnumerable<Product> Products { get; }
        void AddProduct(Product product);
    }
}
