using System.Collections.Generic;
using System.Linq;
using CM.Interface.DataAccess;
using CM.Models;
using System.Data;
using Dapper;

namespace CM.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private IDbConnection _cn;
        public ProductRepository(IDbConnection cn)
        {
            _cn = cn;

        }
        public IEnumerable<Product> GetAll()
        {
            return _cn.Query<Product>(@"SELECT [Id] AS Id,
                                          [name] AS Name,
                                          [description] AS Description,
                                          [price] AS Price,
                                          CASE WHEN [Status]  = 'Y' THEN 'true' ELSE 'false' END AS Status
                                      FROM [dbo].[cm_product]").ToList();

        }
        public Product GetById(int id)
        {
            return _cn.Query<Product>(@"SELECT [Id] AS Id,
                                          [name] AS Name,
                                          [description] AS Description,
                                          [price] AS Price,
                                          CASE WHEN [Status]  = 'Y' THEN 'true' ELSE 'false' END AS Status
                                      FROM [dbo].[cm_product]
                                      WHERE Id=@Id AND [Status]  = 'Y' ", new { Id = id }).FirstOrDefault();
        }
        public int Update(Product product)
        {
            return _cn.Execute(@"UPDATE [dbo].[cm_product] SET
                                [name] = @Name,
                                [description] = @Description,
                                [price]= @Price, 
                                [STATUS] = @Status 
                                 WHERE [Id]= @Id", new
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price, 
                Status = product.Status ? 'Y' : 'N',
                Id = product.Id
            });

        }
        public int ChangeStatus(int id, bool status)
        {
           return _cn.Execute(@"UPDATE [dbo].[cm_product]                                 
                                [STATUS] = @Status 
                                 WHERE [Id]= @Id", new
            {
                Status = status ? 'Y' : 'N',
                Id = id
            });
        }
        public int Add(Product product)
        {
            string insertQuery = @"
                INSERT INTO [dbo].[cm_product] ([name],[description],[price],[STATUS])
                VALUES (@Name,@Description,@Price,@Status) 
                SELECT CAST(SCOPE_IDENTITY() as int)";
            return _cn.Query<int> (insertQuery, new
            {                
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Status = product.Status ? 'Y' : 'N'
            }).Single();
        }
        public int Deleteproduct(int id)
        {
            string deleteQuery = @"
                DELETE from [dbo].[cm_product] WHERE [Id]= @Id ";
            return _cn.Execute(deleteQuery, new { id = id });
        }
    }
}
