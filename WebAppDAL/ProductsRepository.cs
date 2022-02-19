using System;
using System.Collections.Generic;
using System.Linq;
using WebAppDAL.Entities;

namespace WebAppDAL
{
    public class ProductsRepository
    {
        private readonly EfWebAppContext _dbContext;

        public ProductsRepository(EfWebAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guid Add(ProductDto product)
        {
            product.Id = Guid.NewGuid();
            _dbContext.Products.Add(product);

            _dbContext.SaveChanges();

            return product.Id;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public ProductDto GetById(Guid id)
        {
            return _dbContext.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool RemoveById(Guid id)
        {
            var product = new ProductDto()
            {
                Id = id,
            };
            _dbContext.Products.Remove(product);
            var result = _dbContext.SaveChanges();

            return result != 0;
        }

        public bool Update(ProductDto product)
        {
            _dbContext.Products.Update(product);
            var result = _dbContext.SaveChanges();

            return result != 0;
        }
    }
}
