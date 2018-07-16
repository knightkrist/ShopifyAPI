using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.DTO
{
    public class ShopifyRuleDto
    {
        public string allocation_method { get; set; }
        public string title { get; set; }
        public string id { get; set; }
        public string value_type { get; set; }
        public string value { get; set; }
        public string target_type { get; set; }
        public string starts_at { get; set; }
        public string ends_at { get; set; }

        public List<string> entitled_product_ids { get; set; }
        public List<string> entitled_variant_ids { get; set; }
        public List<string> entitled_collection_ids { get; set; }
        public List<string> entitled_country_ids { get; set; }
        public List<string> prerequisite_product_ids { get; set; }
        public List<string> prerequisite_variant_ids { get; set; }
        public List<string> prerequisite_collection_ids { get; set; }
        public List<string> prerequisite_saved_search_ids { get; set; }
        public List<string> prerequisite_customer_ids { get; set; }
        public ShopifyRangeDto prerequisite_quantity_range { get; set; }

    }
}
