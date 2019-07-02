using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp.BusinessLogic.Interface;
using CustomerApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApp.Service.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBusinessLogic _customeBusinessLogic;
        public CustomerController(ICustomerBusinessLogic customerBusinessLogic)
        {
            this._customeBusinessLogic = customerBusinessLogic;
        }

        /// <summary>
        /// Returns all customers including addresses
        /// </summary>
        [HttpGet("GetCustomerList")]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
                var result = await this._customeBusinessLogic.GetCustomersList();
                if (!result.Any())
                {
                    return new NotFoundResult();
                }
                return new OkObjectResult(result);
        }

        /// <summary>
        /// Returns a customer based on the customer id passed in the parameter
        /// </summary>
        [HttpGet("GetCustomer/{id}")]
        public ActionResult<Customer> Get(int id)
        {
                var result = this._customeBusinessLogic.GetCustomer(id);
                if (result == null)
                {
                    return new NotFoundResult();
                }
                return new OkObjectResult(result);
        }

        /// <summary>
        /// Reads customer object from body and insert a new record into the customer list object
        /// </summary>
        [HttpPost("CreateCustomer")]
        public async Task<ActionResult> Post([FromBody] Customer customer)
        {
            if(customer == null)
            {
                return new BadRequestResult();
            }

            var newlyCreatedCustomer = await this._customeBusinessLogic.CreateCustomer(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.ID }, customer);
        }

        /// <summary>
        /// Reads customer object from body and update the existing record in the customers list object
        /// </summary>
        [HttpPatch("UpdateCustomer/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Customer customer)
        {
            if (customer == null)
            {
                return new NoContentResult();
            }

            var customerToUpdate = await this._customeBusinessLogic.GetCustomer(customer.ID);
            if(customerToUpdate == null)
            {
                return new NotFoundResult();
            }

            var updatedCustomer = await this._customeBusinessLogic.UpdateCustomer(customer);
            return new OkObjectResult(updatedCustomer);
        }

        /// <summary>
        /// Deletes customer from customers list object based on id passed in as parameter
        /// </summary>
        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var customerToDelete = await this._customeBusinessLogic.GetCustomer(id);
            if (customerToDelete == null)
            {
                return new NotFoundResult();
            }

            await this._customeBusinessLogic.DeleteCustomer(id);
            return Ok();
        }
    }
}
