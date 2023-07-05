using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;
using ProductApi.Repository.Interface;

namespace ProductApi.Repository
{
    public class ItemService : IItemService
    {
        private readonly ProductDbContext _productDb;
        public ItemService(ProductDbContext productDb)
        {
            _productDb = productDb;
        }
        public async Task<bool> CreateItem(Product product)
        {
            var NewItem = new Product
            {
                 ProductName = product.ProductName,
                 Description = product.Description,
                 CreatedDate = DateTime.Now,
                 ExpiryDate = product.ExpiryDate,
                 UpdatedDate = product.UpdatedDate,
                 DelFlag = product.DelFlag,
                 Quantity = product.Quantity

            };
            

            _productDb.products.Add(NewItem);
            await _productDb.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteItem(int id)
        {
            var item = await GetItem(id);
            item.DelFlag = true;
            _productDb.Update(item);
            await _productDb.SaveChangesAsync();
            return true;
        }

        public async Task<Product> GetItem(int id)
        {
            var item = await _productDb.products.Where(i => i.Id == id && i.DelFlag == false).FirstOrDefaultAsync();
            //var item = await _productDb.items.FirstOrDefaultAsync(i=>i.Id == id);
            return item;
        }

        public async Task<List<Product>> GetItems()
        {
            var items = await _productDb.products.Where(i => i.DelFlag == false).ToListAsync();
            return items;
        }

        public async Task<bool> UpdateItem(Product product)
        {
            
            var EditItem = new Product
            {
                
                ProductName = product.ProductName,
                Description = product.Description,
                UpdatedDate = DateTime.Now,
                ExpiryDate = product.ExpiryDate,
                DelFlag = product.DelFlag,
                Quantity = product.Quantity,
                Id = product.Id

            };


            _productDb.products.Update(EditItem);
            await _productDb.SaveChangesAsync();
            return true;

           
        }
    }
}