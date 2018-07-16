using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Enums
{
    [Flags]
    public enum Financial_Status
    {
        pending = 1,
        authorized = 2,
        partially_paid =3,
        paid = 4,
        partially_refunded = 5,
        refunded = 6,
        voided = 7
    }
}
