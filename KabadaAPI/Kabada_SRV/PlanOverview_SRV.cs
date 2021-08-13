using KabadaAPI;
using System;

namespace Kabada {
  partial class PlanOverview {
    private PlanOverviewElement me(bool comp, string de="not clear, yet"){ return new PlanOverviewElement(){ is_completed=comp, description=de}; }
    private PlanOverviewElement md(bool comp){ return me(comp, "TODO"); }

    internal void read(BLontext context, Guid planId, Guid uGuid) {
      var o=new BusinessPlansRepository(context).getPlanBLfull(planId);

    //TODOpublic PlanOverviewNace nace;  
    customer_segments=me(o.o.IsCustomerSegmentsCompleted, o.descriptionCustomerSegments);  //TODO Maybe info from the first two fields: Age groups and Gender
    value_proposition=md(o.o.IsPropositionCompleted);   //TODO // product names
    channels=md(o.o.IsChannelsCompleted);   //TODO  // Main channel type: Direct sale, Agent, etc. from this level
    customer_relationship=md(o.o.IsCustomerRelationshipCompleted);   //TODO  // maybe at the first moment selected channels, but not sure (needs more discussion)
    revenue_streams=md(o.o.IsRevenueCompleted);   //TODO// I guess, - Revenue stream names
    key_resources=md(o.o.IsResourcesCompleted);   //TODO names
    key_activities=md(o.o.Activity!=null);     //TODO  // activities names
    key_partners=md(o.o.IsPartnersCompleted);   //TODO;  // String format -> Distributors: Name #1, Name #2,.. Suppliers: Name #1, Name #2
    cost_structure=md(o.o.IsCostCompleted);   //TODO; // For cost structure - we also have names
    swot=me(o.o.IsSwotCompleted);           //TODO not clear, yet
    //TODOpublic PlanOverviewElement financial_projections;    // not clear, yet
    //TODOpublic PlanOverviewElement team_competencies;    // not clear, yet
      }
    }
  }
