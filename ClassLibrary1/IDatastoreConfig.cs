﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Datastore
{
    public interface IDatastoreConfig
    {
        string ConnectionString { set; get; }
    }
}
