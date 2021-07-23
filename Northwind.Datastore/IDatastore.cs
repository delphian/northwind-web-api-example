using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Datastore
{
    /**
     * Save and retrieve models into persistent storage.
     * 
     * Each datastore implementation must inherit this.
     */
    public interface IDatastore<T>
    {
        /**
         * Create stored objects.
         */
        void Create(List<T> objs);
        /**
         * Read stored objects based on unique string identifiers.
         */
        List<T> Read(List<string> ids);
        /**
         * Read stored objects based on unique integer identifiers.
         */
        List<T> Read(List<int> ids);
        /**
         * Update stored objects.
         */
        void Update(List<T> objs);
        /**
         * Delete stored objects based on unique string identifiers.
         */
        void Delete(List<string> ids);
        /**
         * Delete stored objects based on unique integer identifiers.
         */
        void Delete(List<int> ids);
        /**
         * Map a DataRow to a model.
         */
        T MapModel(T model, DataRow dataRow);
        /**
         * Create a model based on SQL DataRow.
         */
        T CreateModel(DataRow dataRow);
    }
}
