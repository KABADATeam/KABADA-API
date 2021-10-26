using System;

namespace Kabada {
    public class BusinessPlan
    {       
        public Guid Id { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? ActivityId { get; set; }
        public string Title { get; set; }
        public Guid? Img { get; set; }
        public Guid LanguageId { get; set; }

    }
}
