using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KabadaAPIdao
{
    public class BusinessPlan
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? CountryId { get; set; }
        public Country Country { get; set; }

        public Guid? ActivityID { get; set; }
        public Activity Activity { get; set; }

        [Required]
        public string Title { get; set; }

        public Guid? LanguageId { get; set; }
        public Language Language { get; set; }

        // [vp]
        public Guid? Img { get; set; }
        public DateTime Created { get; set; }
        [Range(0,100)]
        public int Completed { get; set; }
        public bool Public { get; set; }
        public User User { get; set; }
        public bool IsSwotCompleted { get; set; }
        public bool IsResourcesCompleted { get; set; }
        public bool IsPartnersCompleted { get; set; }
        public bool IsPropositionCompleted { get; set; }
        public bool IsCostCompleted { get; set; }
        public bool IsRevenueCompleted { get; set; }
        public bool IsChannelsCompleted { get; set; }
        public bool IsCustomerSegmentsCompleted { get; set; }
        public bool IsCustomerRelationshipCompleted { get; set; }
        public bool IsActivitiesCompleted { get; set; }
        public bool IsBusinessInvestmentsCompleted { get; set; }
        public string AttrVal { get; set; }
        public bool IsFixedVariableCompleted { get; set; }
        public bool IsSalesForecastCompleted { get; set; }
        public bool IsAssetsCompleted { get; set; }
        public BusinessPlan clone(){ return (BusinessPlan)this.MemberwiseClone(); }
    }
}
