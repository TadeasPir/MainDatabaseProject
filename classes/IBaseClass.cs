using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProjectPV.classes
{
    /// <summary>
    /// Represents an interface for classes with an ID property.
    /// </summary>
    /// 
    public interface IBaseClass
    {
        /// <summary>
        /// Gets or sets the ID of the object.
        /// </summary>

        int ID { get; set; }
    }
}
