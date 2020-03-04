using System.Collections.Generic;
using System.Linq;

namespace SportStore.Models
{
    public class DataRepository : IRepository
    {
        //private List<Product> data = new List<Product>();
        private DataContext context;

        // the DataRepository object will be created at run time. Also the datacontext also put in the run time 
        public DataRepository(DataContext dataContext)
        {
            this.context = dataContext;
        }
           
        public IEnumerable<Product> Products => context.Products;

        public void AddProduct(Product product)
        {
            this.context.Products.Add(product);
            this.context.SaveChanges();
        }

        public Product GetProduct(long key)
        {
            return this.context.Products.Where(x => x.Id == key).FirstOrDefault();
        }

        public void UpdateProduct(Product product)
        {
            //this.context.Products.Update(product);
            Product p = GetProduct(product.Id);
            p.Name = product.Name;
            p.PurchasePrice = product.PurchasePrice;
            p.RetailPrice = product.RetailPrice;

            this.context.SaveChanges();
        }

        public void UpdateProducts(Product[] products)
        {
            //this.context.Products.UpdateRange(products);

            Dictionary<long, Product> data = products.ToDictionary(p => p.Id);

            // Call to database and store the product to baseline. all products are tracked in context.
            IEnumerable<Product> baseline = context.Products.Where(p => data.Keys.Contains(p.Id));

            this.context.SaveChanges();
        }
    }
}