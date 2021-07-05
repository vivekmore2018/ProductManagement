using CM.Models;
using System.Collections.Generic;

namespace CM.Interface.Business
{
    public interface IProductManager
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        BusinessResult<Product> Update(Product product);
        int ChangeStatus(int id, bool status);
        BusinessResult<Product> Add(Product product);
        int Delete(int id);
    }
}
