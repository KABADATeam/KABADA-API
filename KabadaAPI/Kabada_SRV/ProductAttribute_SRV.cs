namespace Kabada {
    partial class ProductAttribute
    {
        public void unpack(string archived)
        {
            var t = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductAttribute>(archived);
            title = t.title;
            description = t.description;
            product_type = t.product_type;
            price_level = t.price_level;
            selected_additional_income_sources = t.selected_additional_income_sources;
            product_features = t.product_features;
            innovative_level = t.innovative_level;
            quality_level = t.quality_level;
            differentiation_level = t.differentiation_level;            
        }
    }
    }
