using CodeByStudent.Tools;
using Entity.Concreate;


namespace DataAccessLayer.Abstract

{
    public interface ICategory
    {

        PaginatedList<Category> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
        Category GetItem(int id);
        Category Create(Category category);
        Category Edit(Category category);
        Category Delete(Category category);
    }
}
