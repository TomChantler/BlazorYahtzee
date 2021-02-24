using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorYahtzee.Models.Categories;

namespace BlazorYahtzee.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<ICategory>> GetCategoriesAsync();
    }
}
