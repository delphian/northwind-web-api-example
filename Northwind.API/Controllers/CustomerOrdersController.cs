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
    /// <summary>API for customer orders.</summary>
    /// <remarks>
    /// TODO : These should all be wrapped into a generic response object. Don't return raw arrays.
    /// </remarks>
    public class CustomerOrdersController : ApiController
    {
        private readonly ICustomerOrdersDatastore datastore;
        /// <summary>Constructor for dependency injection.</summary>
        public CustomerOrdersController(ICustomerOrdersDatastore customerOrdersDS)
        {
            this.datastore = customerOrdersDS;
        }
        /// <summary>Get a single company order.</summary>
        [JwtAuthentication]
        public CustomerOrder Get(int id)
        {
            var results = datastore.Read(new int[] { id }.ToList());
            return results.FirstOrDefault<CustomerOrder>();
        }
        /// <summary>Get all orders of a company.</summary>
        /// <remarks>
        /// Doesn't fit into url pattern, but use the requested method name.
        /// </remarks>
        [AllowAnonymous]
        [HttpGet, Route("api/GetCustomerOrders/{companyName}")]
        public List<CustomerOrder> GetCustomerOrders(string companyName)
        {
            var results = datastore.ReadByCompanyName(companyName);
            return results;
        }
        /// <summary>Create a new customer order.</summary>
        [JwtAuthentication]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }
        /// <summary>Update an existing customer order.</summary>
        [JwtAuthentication]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }
        /// <summary>Delete a customer order.</summary>
        [JwtAuthentication]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}