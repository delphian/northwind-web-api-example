using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Datastore
{
    /**
     * Make life easy and provide default exceptions to all datastores.
     * 
     * All derived datastores must inerit this!
     */
    public abstract class Datastore<T> : IDatastore<T>
    {
        protected IDatastoreConfig DatastoreConfig { set; get; }
        /**
         * Constructor
         */
        protected Datastore(IDatastoreConfig datastoreConfig)
        {
            this.DatastoreConfig = datastoreConfig;
        }
        /**
         * Create stored objects.
         */
        public virtual void Create(List<T> objs)
        {
            throw new NotImplementedException();
        }
        /**
         * Read stored objects based on unique string identifiers.
         */
        public virtual List<T> Read(List<string> ids)
        {
            throw new NotImplementedException();
        }
        /**
         * Read stored objects based on unique integer identifiers.
         */
        public virtual List<T> Read(List<int> ids)
        {
            throw new NotImplementedException();
        }
        /**
         * Update stored objects.
         */
        public virtual void Update(List<T> objs)
        {
            throw new NotImplementedException();
        }
        /**
         * Read stored objects based on unique string identifiers.
         */
        public virtual void Delete(List<string> ids)
        {
            throw new NotImplementedException();
        }
        /**
         * Read stored objects based on unique integer identifiers.
         */
        public virtual void Delete(List<int> ids)
        {
            throw new NotImplementedException();
        }
        /**
         * Map a DataRow to a CustomerOrder model.
         */
        public abstract T MapModel(T model, DataRow dataRow);
        /**
         * Create a CustomerOrder based on SQL DataRow.
         */
        public abstract T CreateModel(DataRow dataRow);
    }
}
