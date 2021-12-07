using KabadaAPI;
using System;

namespace Kabada {
  partial class PlanOverview {
    private PlanOverviewElement me(bool comp, string de="not clear, yet"){ return new PlanOverviewElement(){ is_completed=comp, description=de}; }
    private PlanOverviewElement md(bool comp){ return me(comp, "TODO"); }

    internal void read(BLontext context, Guid planId, Guid uGuid) {
      var pR=new BusinessPlansRepository(context);
      var p=pR.getPlanBLfull(planId, context.userGuid);
      p.textSupport=new TexterRepository(context);
     
      //var t=pR.joinRO(planId);

    // nace;
    if(p.activity!=null){
      nace=new PlanOverviewNace();
      var w=p.activity;
      nace.activity_code=w.Code;
      nace.activity_title=w.Title;
      if(p.industry!=null){
        nace.industry_code=p.industry.Code;
        nace.industry_title=p.industry.Title;
        }
      }
    this.planImage=p.o.Img;
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
    assets=me(p.o.IsAssetsCompleted);                                                         //TODO not clear, yet
    fixed_and_variables_costs=me(p.o.IsFixedVariableCompleted);                               //TODO not clear, yet
    sales_forecast=me(p.o.IsSalesForecastCompleted);                                          //TODO not clear, yet
    business_start_up_investments=me(p.o.IsBusinessInvestmentsCompleted);                     //TODO not clear, yet
    cash_flow=me(false);                                                       //"is_cash_flow_completed" TODO not clear, yet
    personal_characteristics=me(false);                                       // not clear, yet // no such variable,yet - still not developed
    reasons=me(false);;                                                       // not clear, yet // no such variable,yet - still not developed
    ////TODOpublic PlanOverviewElement financial_projections;    // not clear, yet
    team_competencies=me(false);                                             // not clear, yet // no such variable,yet - still not developed
    }
  }
}
