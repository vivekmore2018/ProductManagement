using CM.Models;
using System.Collections.Generic;

namespace CM.Interface.Business
{
    public interface IProductManager
    {
        IEnumerable<Product> GetAll();
        Contact GetById(int id);
        BusinessResult<Product> Update(Product contact);
        int ChangeStatus(int id, bool status);
        BusinessResult<Product> Add(Product contact);
        int Delete(int id);
    }
}
