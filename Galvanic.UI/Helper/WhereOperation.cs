using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Galvanic.UI.Helper
{
    public enum WhereOperation
    {
        [StringValue("eq")]
        Equal,
        [StringValue("ne")]
        NotEqual,
        [StringValue("cn")]
        Contains
    }
}