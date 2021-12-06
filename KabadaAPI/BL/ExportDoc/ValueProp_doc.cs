using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabadaAPI
{
    public class ValueProp_doc
    {
        public string title;
        public string prodType;
        public string description;
        public string priceLevel;
        public string addIncomeSource; //comma separated string        
        public List<string> productFeatures;
        public string innovLevel;
        public string qualityLevel;
        public string diffLevel;

        //field titles
        public static string t_prodType {get {return "Product Type: "; } }
        public static string t_description { get { return "Description: "; } }
        public static string t_priceLevel { get { return "Price Level: "; } }
        public static string t_addIncomeSource { get { return "Additional income sources: "; } }
        public static string t_productFeatures { get { return "Product features: "; } }
        public static string t_summary { get { return "Summary: "; } }
        public static string t_price { get { return "Price: "; } }
        public static string t_innov { get { return "Innovation: "; } }
        public static string t_qual { get { return "Quality: "; } }
        public static string t_diff { get { return "Differentiation: "; } }
    }
}
