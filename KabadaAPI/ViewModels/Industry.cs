using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabadaAPI {
    public class Industry
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public List<ActivityView> Activities { get; set; }
    }
}
