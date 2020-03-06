using SportStore.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }

        Product GetProduct(long key);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void UpdateProducts(Product[] products);
        void DeleteProduct(Product product);

        // Paging
        PagedList<Product> GetProduct(QueryOptions queryOptions);
    }
}
