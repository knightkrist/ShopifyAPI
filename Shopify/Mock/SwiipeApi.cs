using Shopify.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Mock
{
    public static class SwiipeApi
    {
        public static SwiipeResponseDto Call(SwiipeRequestDto dto)
        {
            var guid = Guid.NewGuid();
            return new SwiipeResponseDto()
            {
                order_id = guid.ToString(),
                succeded = true,
                verified_card = true
            };
        }
    }
}
