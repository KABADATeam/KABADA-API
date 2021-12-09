using System;

namespace Kabada {
  public partial class PlanOverview {
    public PlanOverviewNace nace;
    public PlanOverviewElement customer_segments;  // Maybe info from the first two fields: Age groups and Gender
    public PlanOverviewElement value_proposition;  // product names
    public PlanOverviewElement channels;   // Main channel type: Direct sale, Agent, etc. from this level
    public PlanOverviewElement customer_relationship;  // maybe at the first moment selected channels, but not sure (needs more discussion)
    public PlanOverviewElement revenue_streams;   // I guess, - Revenue stream names
    public PlanOverviewElement key_resources;   // names
    public PlanOverviewElement key_activities;  // activities names
    public PlanOverviewElement key_partners;  // String format -> Distributors: Name #1, Name #2,.. Suppliers: Name #1, Name #2
    public PlanOverviewElement cost_structure; // For cost structure - we also have names
    public PlanOverviewElement swot;           // not clear, yet

    public PlanOverviewElement assets;           // not clear, yet
    public PlanOverviewElement fixed_and_variables_costs;           // not clear, yet
    public PlanOverviewElement sales_forecast;           // not clear, yet
    public PlanOverviewElement business_start_up_investments;           // not clear, yet
    public PlanOverviewElement cash_flow;           // not clear, yet
    public PlanOverviewElement personal_characteristics;           // not clear, yet
    public PlanOverviewElement reasons;           // not clear, yet // no such variable,yet - still not developed

    public PlanOverviewElement team_competencies;    // not clear, yet
    public Guid? planImage;
    }
  }
