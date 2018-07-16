//using Shopify.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Shopify.Models
{
    public class RequestPayload
    {
        public IEnumerable<CartDTO> cart_items { get; set; }
        public CustomersDTO customers { get; set; }
        
        public AddressDTO shipping_address { get; set; }
        public AddressDTO billing_address { get; set; }
        public IEnumerable<TransactionsDTO> transactions { get; set; }
        public string financial_status { get; set; }
        
        public bool swiipeaccount { get; set; }
        public IEnumerable<DiscountsDTO> discounts_code { get; set; }
        //public string discounts_code { get; set; }
    }

    public class CartDTO
    {
        public int quantity { get; set; }
        public string product_id { get; set; }
        public string variant_id { get; set; }

        public string rprice { get; set; }
        public string rname { get; set; }
        public string rtitle { get; set; }
    }



}
