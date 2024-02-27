using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DatabaseProjectPV.classes
{

    /// <summary>
    /// Represents a generic repository interface for CRUD operations.
    /// </summary>
    /// <typeparam name="T">The type of entity the repository operates on.</typeparam>
    public interface IRepozitory<T> where T : IBaseClass
    {
        /// <summary>
        /// Retrieves an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>The entity with the specified ID, or null if not found.</returns>


        T GetByID(int id);
        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="element">The entity to update.</param>

        void Update(T element);
        /// <summary>
        /// Saves a new entity.
        /// </summary>
        /// <param name="element">The entity to save.</param>
        
        void Save(T element);
        /// <summary>
        /// Deletes an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        void Delete(int id);
        /// <summary>
        /// Imports entities from an external data source.
        /// </summary>
        /// <param name="fileName">The name of the file containing the data to import.</param>
        void Import(string fileName);
    }
}
