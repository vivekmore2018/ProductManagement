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
        public ProductManager(IProductRepository contactRepository)
        {
            _productRepository = contactRepository;
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
            if (Product == null)
            {
                result.Errors.Add("Invalid contact object");
                return result;
            }
            var id = _productRepository.AddProduct(contact);
            if (id > 0)
            {
                contact.Id = id;
                result.Value = contact;
            }

            return result;
        }

        public int Delete(int id)
        {
            return _productRepository.DeleteContact(id);
        }
    }
}
