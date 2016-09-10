using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vendor.domain.data.abstracts
{
    /// <summary>
    /// always need to add to a 'ignore' the 'ComplexKeys' property in 'OnModelCreating' method.
    /// </summary>
    public interface ILanguage
    {
        /// <summary>
        /// always need to add to a 'ignore' the 'ComplexKeys' property in 'OnModelCreating' method.
        /// </summary>
        ///long[] ComplexKeys { get; set; }
        long EntityId { get; set; }

        long LanguageId { get; set; }

        //T Entity { get; set; }
    }
}
