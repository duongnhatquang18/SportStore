using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        public DataContext _context;

        public CategoryRepository(DataContext dataContext)
        {
            this._context = dataContext;
        }

        public IEnumerable<Category> Categories => _context.Categories;

        public void AddCategory(Category category)
        {
            this._context.Categories.Add(category);
            this._context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            this._context.Categories.Remove(category);
            this._context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            this._context.Categories.Update(category);
            this._context.SaveChanges();
        }
    }
}
