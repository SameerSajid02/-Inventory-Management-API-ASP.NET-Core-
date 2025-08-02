using ProductInventoryApi.Models;
using ProductInventoryApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ProductInventoryApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await dbContext.Products.ToListAsync();

        public async Task<Product?> GetByIdAsync(int id) =>
            await dbContext.Products.FindAsync(id);

        public async Task AddAsync(Product product) =>
            await dbContext.Products.AddAsync(product);

        public void Update(Product product) =>
            dbContext.Products.Update(product);

        public void Delete(Product product) =>
            dbContext.Products.Remove(product);

        public async Task<bool> SaveAsync() =>
            await dbContext.SaveChangesAsync() > 0;
    }
}
