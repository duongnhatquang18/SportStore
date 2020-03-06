using SportStore.Models.Paging;
using System.Collections.Generic;

namespace SportStore.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);

        // Paging
        PagedList<Category> GetCategories(QueryOptions queryOptions);
    }
}
