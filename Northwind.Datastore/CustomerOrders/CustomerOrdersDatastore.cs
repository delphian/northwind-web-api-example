using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Datastore.CustomerOrders
{
    public class CustomerOrdersDatastore : Datastore<CustomerOrder>, ICustomerOrdersDatastore
    {
        /**
         * Constructor
         */
        public CustomerOrdersDatastore(IDatastoreConfig datastoreConfig) : base(datastoreConfig) { }
        /**
         * Read a list of customer orders based on unique integer identifiers.
         */
        public override List<CustomerOrder> Read(List<int> ids)
        {
            // Abstract the following away if we have time. Only the base query and model
            // mappings need to actually be here.
            var customerOrders = new List<CustomerOrder>();
            // Pull data from SQL server.
            using (SqlConnection sqlServer = new SqlConnection(this.DatastoreConfig.ConnectionString))
            {
                // Build query
                int i;
                StringBuilder sb = new StringBuilder("SELECT * FROM Orders WHERE Orders.OrderID IN (");
                for (i = 0; i < ids.Count(); i++)
                    sb.Append("@OrderId" + i.ToString() + ",");
                sb.Remove(sb.Length - 1, 1);
                sb.Append(")");
                SqlCommand sqlCmd = new SqlCommand(sb.ToString(), sqlServer);
                // Build query parameters
                i = 0;
                foreach (int id in ids)
                {
                    sqlCmd.Parameters.AddWithValue("@OrderId" + i.ToString(), id);
                    i++;
                }
                // Execute query.
                DataTable dataTable = new DataTable("CustomerOrders");
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
                sqlServer.Open();
                sqlAdapter.Fill(dataTable);
                sqlServer.Close();
                // Populate model.
                foreach (DataRow dataRow in dataTable.Rows)
                    customerOrders.Add(CreateModel(dataRow));
            }
            return customerOrders;
        }
        /**
         * Read a list of customer orders based on company name.
         */
        public List<CustomerOrder> ReadByCompanyName(string companyName)
        {
            // Abstract the following away if we have time. Only the base query and model
            // mappings need to actually be here.
            var customerOrders = new List<CustomerOrder>();
            // Pull data from SQL server.
            using (SqlConnection sqlServer = new SqlConnection(this.DatastoreConfig.ConnectionString))
            {
                // Build query
                var sql = @"
                    SELECT
                        Orders.*
                    FROM Orders
                        JOIN Customers ON
                            Customers.CustomerID = Orders.CustomerID
                    WHERE
                        Customers.CompanyName = @CompanyName
                ";
                SqlCommand sqlCmd = new SqlCommand(sql, sqlServer);
                // Build query parameters
                sqlCmd.Parameters.AddWithValue("@CompanyName", companyName);
                // Execute query.
                DataTable dataTable = new DataTable("CustomerOrders");
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
                sqlServer.Open();
                sqlAdapter.Fill(dataTable);
                sqlServer.Close();
                // Populate model.
                foreach (DataRow dataRow in dataTable.Rows)
                    customerOrders.Add(CreateModel(dataRow));
            }
            return customerOrders;
        }
        /**
         * Map a DataRow to a CustomerOrder model.
         */
        public override CustomerOrder MapModel(CustomerOrder customerOrder, DataRow dataRow)
        {
            customerOrder.OrderId = (int)dataRow["OrderID"];
            customerOrder.OrderDate = (dataRow.IsNull("OrderDate")) ? null : (DateTime?)dataRow["OrderDate"];
            customerOrder.RequiredDate = (dataRow.IsNull("RequiredDate")) ? null : (DateTime?)dataRow["RequiredDate"];
            customerOrder.ShippedDate = (dataRow.IsNull("ShippedDate")) ? null : (DateTime?)dataRow["ShippedDate"];
            return customerOrder;
        }
        /**
         * Create a CustomerOrder based on SQL DataRow.
         */
        public override CustomerOrder CreateModel(DataRow dataRow)
        {
            var customerOrder = new CustomerOrder();
            return MapModel(customerOrder, dataRow);
        }
    }
}
