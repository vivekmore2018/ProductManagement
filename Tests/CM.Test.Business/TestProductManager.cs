using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CM.Interface.DataAccess;
using CM.Business;
using CM.Models;
using CM.Interface.Business;

namespace CM.Test.Business
{
    [TestClass]
    public class TestProductManager
    {
        private Mock<IProductRepository> mockIProductRepository;
        private ProductManager prodductManager;

        [TestInitialize]
        public void Setup()
        {
            mockIProductRepository = new Mock<IProductRepository>();
            prodductManager = new ProductManager(mockIProductRepository.Object);
        }
        
        [TestMethod]
        public void TestSucessAddProduct()
        {
            //Arrange
            var inputProduct = new Product() { Name = "name", Description = "lastname", Price = 3500, Status = true };

            //mockOrgManager.Setup(x => x.GetOrgAttributesFeatureMatrix(It.IsAny<int>())).Returns(() => MockAttibuteDataProvider.GetOrgAttributesFeatureMatrix_Success());
            mockIProductRepository.Setup(x => x.Add(It.IsAny<Product>())).Returns(2);

            //Act
            var result = prodductManager.Add(inputProduct);

            //Assert
            Assert.IsInstanceOfType(result, typeof(BusinessResult<Product>));
            Assert.AreEqual(result.Status, Status.Success);
            Assert.AreEqual(0, result.Errors.Count);
            Assert.AreEqual(result.Value.Id, 2);

        }
    }
}
