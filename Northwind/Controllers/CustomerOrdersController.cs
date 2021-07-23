using Northwind.API.Filters;
using Northwind.Datastore.CustomerOrders;
using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Northwind.API.Controllers
{
    /**
     * TODO : These should all be wrapped into a generic response object. Don't return raw arrays!
     */
    public class CustomerOrdersController : ApiController
    {
        private readonly ICustomerOrdersDatastore datastore;
        /**
         * Constructor for dependency injection.
         */
        public CustomerOrdersController(ICustomerOrdersDatastore customerOrdersDS)
        {
            this.datastore = customerOrdersDS;
        }
        /**
         * Get a single company order
         */
        [AllowAnonymous]
        public CustomerOrder Get(int id)
        {
            var results = datastore.Read(new int[] { id }.ToList());
            return results.FirstOrDefault<CustomerOrder>();
        }
        /**
         * Get all company orders
         * 
         * TODO : Doesn't really fit into our url pattern, but use the required method name.
         */
        [AllowAnonymous]
        [HttpGet, Route("api/GetCustomerOrders/{companyName}")]
        public List<CustomerOrder> GetCustomerOrders(string companyName)
        {
            var results = datastore.ReadByCompanyName(companyName);
            return results;
        }
        /**
         * Create a new customer order.
         * 
         * POST api/customerOrders
         */
        [JwtAuthentication]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }
        /**
         * Update an existing customer order.
         * 
         * PUT api/customerOrders/5
         */
        [JwtAuthentication]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }
        /**
         * Delete a customer order.
         * 
         * DELETE api/customerOrders/5
         */
        [JwtAuthentication]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}