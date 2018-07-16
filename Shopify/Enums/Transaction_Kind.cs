using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Enums
{
    [Flags]
    public enum Transaction_Kind
    {
        sale = 1,
        authorization = 2,
        capture = 3,
        refund = 4
    }
}
