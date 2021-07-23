using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Datastore
{
    public class DatastoreConfig : IDatastoreConfig
    {
        public string ConnectionString { set; get; }
    }
}
