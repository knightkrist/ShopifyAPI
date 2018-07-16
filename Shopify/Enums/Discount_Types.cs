using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Enums
{
    [Flags]
    public enum Discount_Types
    {
        percentage = 1,
        fixed_amount = 2
    }
}
