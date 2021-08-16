using KabadaAPI;
using System;

namespace Kabada {
  partial class PlanOverview {
    private PlanOverviewElement me(bool comp, string de="not clear, yet"){ return new PlanOverviewElement(){ is_completed=comp, description=de}; }
    private PlanOverviewElement md(bool comp){ return me(comp, "TODO"); }

    internal void read(BLontext context, Guid planId, Guid uGuid) {
      var p=new BusinessPlansRepository(context).getPlanBLfull(planId);
      p.textSupport=new TexterRepository(context);

    // nace;
    if(p.o.Activity!=null){
      nace=new PlanOverviewNace();
      var w=p.o.Activity;
      nace.activity_code=w.Code;
      nace.activity_title=w.Title;
      if(w.Industry!=null){
        nace.industry_code=w.Industry.Code;
        nace.industry_title=w.Industry.Title;
        }
      }
    customer_segments=me(p.o.IsCustomerSegmentsCompleted, p.descriptionCustomerSegments);     //TODO Maybe info from the first two fields: Age groups and Gender
    value_proposition=me(p.o.IsPropositionCompleted, p.descriptionPropostion);
    channels=me(p.o.IsChannelsCompleted, p.descriptionChannels); 
    customer_relationship=me(p.o.IsCustomerRelationshipCompleted, p.descriptionRelationship); //TODO maybe at the first moment selected channels, but not sure (needs more discussion) 
    revenue_streams=me(p.o.IsRevenueCompleted, p.descriptionRevenue);
    key_resources=me(p.o.IsResourcesCompleted, p.descriptionResources);
    key_activities=me(p.o.IsActivitiesCompleted, p.descriptionActivities);
    key_partners=me(p.o.IsPartnersCompleted, p.descriptionPartners);
    cost_structure=me(p.o.IsCostCompleted, p.descriptionCost);
    swot=me(p.o.IsSwotCompleted);                                                             //TODO not clear, yet
    //TODOpublic PlanOverviewElement financial_projections;    // not clear, yet
    //TODOpublic PlanOverviewElement team_competencies;    // not clear, yet
      }
    }
  }
