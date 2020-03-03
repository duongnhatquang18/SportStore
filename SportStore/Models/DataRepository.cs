using System.Collections.Generic;

namespace SportStore.Models
{
    public class DataRepository : IRepository
    {
        //private List<Product> data = new List<Product>();
        private DataContext context;

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
    }
}
