using CM.Models;
using System.Collections.Generic;

namespace CM.Interface.DataAccess
{
    public interface IProductRepository
    {
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>List of product model</returns>
        IEnumerable<Product> GetAll();
        /// <summary>
        /// Get Single product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return single product</returns>
        Product GetById(int id);
        /// <summary>
        /// Update existing product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>return rowaffected</returns>
        int Update(Product product);
        /// <summary>
        /// Change status of product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns>return rowaffected</returns>
        int ChangeStatus(int id, bool status);
        /// <summary>
        /// Add new product in to database
        /// </summary>
        /// <param name="product">New product object</param>
        /// <returns>return newly added id</returns>
        int Add(Product product);
        /// <summary>
        /// Delete product from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return rowaffected</returns>
        int Deleteproduct(int id);
    }
}
