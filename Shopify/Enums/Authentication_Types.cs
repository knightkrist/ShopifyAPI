using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Enums
{
    [Flags]
    public enum Authentication_Types
    {
        DiscountEndPoint = 1,
        EndPoint = 2,
        APIKEY = 3,
        Password = 4,
        SampleEndPoint = 5
    }
}
