using System.Collections.Generic;

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
    }
}