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
    customer_segments=me(p.o.IsCustomerSegmentsCompleted, p.descriptionCustomerSegments);     //TODO
    value_proposition=me(p.o.IsPropositionCompleted, p.descriptionPropostion);
    channels=me(p.o.IsChannelsCompleted, p.descriptionChannels); 
    customer_relationship=me(p.o.IsCustomerRelationshipCompleted, p.descriptionRelationship); //TODO 
    revenue_streams=me(p.o.IsRevenueCompleted, p.descriptionRevenue);
    key_resources=me(p.o.IsResourcesCompleted, p.descriptionResources);
    //TODOkey_activities=me(o.o.Activity!=null, o.descriptionActivity);                             //TODO
    key_partners=me(p.o.IsPartnersCompleted, p.descriptionPartners);
    cost_structure=me(p.o.IsCostCompleted, p.descriptionCost);                                //TODO
    swot=me(p.o.IsSwotCompleted);           //TODO not clear, yet
    //TODOpublic PlanOverviewElement financial_projections;    // not clear, yet
    //TODOpublic PlanOverviewElement team_competencies;    // not clear, yet
      }
    }
  }
