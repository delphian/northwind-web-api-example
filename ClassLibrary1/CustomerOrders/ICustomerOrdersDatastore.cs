using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Datastore.CustomerOrders
{
    public interface ICustomerOrdersDatastore : IDatastore<CustomerOrder>
    {
        /**
         * Read a list of customer orders based on company name.
         */
        List<CustomerOrder> ReadByCompanyName(string companyName);
    }
}
