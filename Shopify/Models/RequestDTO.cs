using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Models
{
    public class RequestDTO
    {
        public OrderDTO order { get; set; }
    }

    public class OrderDTO
    {
        public IEnumerable<LineItemDTO> line_items { get; set; }
        public CustomersDTO customer { get; set; }
        public AddressDTO shipping_address { get; set; }
        public AddressDTO billing_address { get; set; }
        public IEnumerable<TransactionsDTO> transactions { get; set; }
        public string financial_status { get; set; }
        public IEnumerable<DiscountsDTO> discount_codes { get; set; }
    }

    public class LineItemDTO
    {
        public string variant_id { get; set; }
        public int quantity { get; set; }
        public string price { get; set; }
        //public string name { get; set; }
        //public string title { get; set; }
    }

}
