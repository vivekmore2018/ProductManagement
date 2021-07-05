using System.Collections.Generic;
using CM.Interface.Business;
using CM.Models;
using CM.Interface.DataAccess;
using System.Text.RegularExpressions;

namespace CM.Business
{
    public class ProductManager : IProductManager
    {
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }
        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }
        public BusinessResult<Product> Update(Product product)
        {
            BusinessResult<Product> result = new BusinessResult<Product>();
            return result;
        }
        public int ChangeStatus(int id, bool status)
        {
            return _productRepository.ChangeStatus(id, status);
        }
        public BusinessResult<Product> Add(Product product)
        {
            BusinessResult<Product> result = new BusinessResult<Product>();
            if (product == null)
            {
                result.Errors.Add("Invalid product object");
                return result;
            }
            var id = _productRepository.Add(product);
            if (id > 0)
            {
                product.Id = id;
                result.Value = product;
            }

            return result;
        }

        public int Delete(int id)
        {
            return _productRepository.Deleteproduct(id);
        }
    }
}
