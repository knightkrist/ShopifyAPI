using Shopify.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Mock
{
    public static class Api
    {
        public static ResponseDto Call(RequestDto dto)
        {
            var guid = Guid.NewGuid();
            return new ResponseDto()
            {
                order_id = guid.ToString(),
                succeded = true,
                verified_card = true
            };
        }
    }
}
