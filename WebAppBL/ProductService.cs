using AutoMapper;
using System;
using System.Collections.Generic;
using WebAppBL.Models;
using WebAppDAL;
using WebAppDAL.Entities;

namespace WebAppBL
{
    public class ProductService
    {
        private ProductsRepository _productsRepository;
        private IMapper _mapper;

        public ProductService(
            IMapper mapper,
            ProductsRepository productsRepository)
        {
            _mapper = mapper;
            _productsRepository = productsRepository;
        }

        public Guid AddProduct(Product product)
        {
            var dbProduct = _mapper.Map<ProductDto>(product);

            return _productsRepository.Add(dbProduct);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var dbItems = _productsRepository.GetAll();

            return _mapper.Map<IEnumerable<Product>>(dbItems);
        }

        public Product GetProductById(Guid id)
        {
            var dbProduct = _productsRepository.GetById(id);

            return _mapper.Map<Product>(dbProduct);
        }

        public bool RemoveProduct(Guid id)
        {
            return _productsRepository.RemoveById(id);
        }

        public bool UpdateProduct(Product product)
        {
            return _productsRepository.Update(_mapper.Map<ProductDto>(product));
        }
    }
}
