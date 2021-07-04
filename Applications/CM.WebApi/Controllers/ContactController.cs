using CM.Business;
using CM.Models;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace CM.WebApi.Controllers
{
    public class ProductController : ApiController
    {
        private ProductManager _productManager;
        /// <summary>
        /// Constructor injected with depedency of contact Manager BI class
        /// </summary>
        /// <param name="productManager"></param>
        public ContactController(ProductManager productManager)
        {
            _productManager = contactManager;
        }

        /// <summary>  
        /// Get All Contact Details  
        /// </summary>  
        /// <response code="200">Record found</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not Found</response>
        [HttpGet]
        [Route("api/Product")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<Product>))]
        public IHttpActionResult Get()
        {
            var result = _productManager.GetAll();
            if (result.Count() > 0)
            {
                return Ok(result);
            }
            else
            {
                return  NotFound();
            }
        }


        /// <summary>
        /// Get Single Contact if found
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Product/{id}")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Product))]
        /// <response code="200">return object</response>
        /// <response code="404">Not Found</response>
        public IHttpActionResult Get(int Id)
        {
            var result = _productManager.GetById(Id);
            if (result !=null)
            {
                return Ok(result);
            }
            else
            {
                return  NotFound();
            }
        }


        /// <summary>  
        /// Create Contact to database
        /// </summary>  
        /// <response code="200">Created</response>
        /// <response code="400">Bad request</response>
        [Route("api/Product")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Product))]
        public IHttpActionResult Create(Product product)
        {
            var result = _productManager.AddContact(product);
            if(result.Status == Interface.Business.Status.Success)
            {
                return Ok(contact);
            }
            else
            {
                return BadRequest(string.Join(";", result.Errors));
            }
        }

        /// <summary>  
        /// Create Contact to database
        /// </summary>  
        /// <response code="200">Updated</response>
        /// <response code="400">Bad request</response>
        [Route("api/Product")]
        [HttpPut]
        public IHttpActionResult Update([FromBody] Product product)
        {
            var result = _productManager.Update(product);
            if (result.Status == Interface.Business.Status.Success)
            {               
                return Ok(contact.Id);
            }
            else
            {
                return BadRequest(string.Join(";", result.Errors));
            }
        }
        /// <summary>
        /// Delete contact by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <response code="200">Contact deleted</response>
        /// <response code="404">Not found</response>
        [Route("api/contact")]
        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            var result = _productManager.DeleteContact(Id);
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
