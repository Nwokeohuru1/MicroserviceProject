using ProductApi.Models;

namespace ProductApi.Repository.Interface
{
    public interface IItemService
    {

        Task<List<Product>> GetItems();
        Task<Product> GetItem(int id);
        Task<bool> CreateItem(Product product);
        Task<bool> UpdateItem(Product product);
        Task<bool> DeleteItem(int id);
    }
}
