using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Equatorial.PLR.Domain.Enum
{
    /// <summary>
    /// Response Status
    /// </summary>
    public enum ResponseMessageType
    {
        /// <summary>
        /// Error Type
        /// </summary>
        Error,

        /// <summary>
        /// Warning Type
        /// </summary>
        Warning,

        /// <summary>
        /// Info Type
        /// </summary>
        Info
    }
}
