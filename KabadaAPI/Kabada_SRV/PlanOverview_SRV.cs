using KabadaAPI;
using System;

namespace Kabada {
  partial class PlanOverview {
    private PlanOverviewElement me(bool comp, string de="not clear, yet"){ return new PlanOverviewElement(){ is_completed=comp, description=de}; }
    private PlanOverviewElement md(bool comp){ return me(comp, "TODO"); }

    internal void read(BLontext context, Guid planId, Guid uGuid) {
      var o=new BusinessPlansRepository(context).getPlanBLfull(planId);

    //TODOpublic PlanOverviewNace nace;  
    customer_segments=me(o.o.IsCustomerSegmentsCompleted, o.descriptionCustomerSegments);     //TODO
    value_proposition=me(o.o.IsPropositionCompleted, o.descriptionPropostion);                //TODO
    channels=me(o.o.IsChannelsCompleted, o.descriptionChannels);                              //TODO  
    customer_relationship=me(o.o.IsCustomerRelationshipCompleted, o.descriptionRelationship); //TODO 
    revenue_streams=me(o.o.IsRevenueCompleted, o.descriptionRevenue);                         //TODO
    key_resources=me(o.o.IsResourcesCompleted, o.descriptionResources);                       //TODO
    key_activities=me(o.o.Activity!=null, o.descriptionActivity);                             //TODO
    key_partners=me(o.o.IsPartnersCompleted, o.descriptionPartners);                          //TODO
    cost_structure=me(o.o.IsCostCompleted, o.descriptionCost);                                //TODO
    swot=me(o.o.IsSwotCompleted);           //TODO not clear, yet
    //TODOpublic PlanOverviewElement financial_projections;    // not clear, yet
    //TODOpublic PlanOverviewElement team_competencies;    // not clear, yet
      }
    }
  }
