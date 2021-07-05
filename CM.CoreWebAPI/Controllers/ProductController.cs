using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CM.Interface.Business;
using CM.Models;
using Swashbuckle.AspNetCore.Swagger;
using CM.CoreWebAPI.Infrastructure;
namespace CM.CoreWebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        /// <summary>  
        /// Get All Product Details  
        /// </summary>  
        /// <response code="200">Record found</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not Found</response>
        [HttpGet]
        [Route("api/Product")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Product>))]
        public ActionResult Get()
        {
            var result = _productManager.GetAll();
            if (result.Count() > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }


        /// <summary>
        /// Get Single Product if found
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Product/{id}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        /// <response code="200">return object</response>
        /// <response code="404">Not Found</response>
        public ActionResult Get(int Id)
        {
            var result = _productManager.GetById(Id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }


        /// <summary>  
        /// Create Product in to database
        /// </summary>  
        /// <response code="200">Created</response>
        /// <response code="400">Bad request</response>
        [Route("api/Product")]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ValidateModel]
        public ActionResult Create(Product product)
        {
          
            var result = _productManager.Add(product);
            if (result.Status == Interface.Business.Status.Success)
            {
                return Ok(product);
            }
            else
            {
                return BadRequest(string.Join(";", result.Errors));
            }
        }

        /// <summary>  
        /// Create Product to database
        /// </summary>  
        /// <response code="200">Updated</response>
        /// <response code="400">Bad request</response>
        [Route("api/Product")]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(int))]
        [ValidateModel]
        public ActionResult Update([FromBody] Product product)
        {
            var result = _productManager.Update(product);
            if (result.Status == Interface.Business.Status.Success)
            {
                return Ok(product.Id);
            }
            else
            {
                return BadRequest(string.Join(";", result.Errors));
            }
        }
        /// <summary>
        /// Delete product by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <response code="200">Product deleted</response>
        /// <response code="404">Not found</response>
        [Route("api/Product")]
        [HttpDelete]
        [ProducesResponseType(200)]
        public ActionResult Delete(int Id)
        {
            var result = _productManager.Delete(Id);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
