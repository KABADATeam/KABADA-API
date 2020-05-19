using KabadaAPI.DataSource.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace KabadaAPI.DataSource.Repositories
{
  public  class UserPlanRepository
    {
        
            protected Context context;

            public UserPlanRepository()
            {
                context = new Context();
            }
        /* public List<Selection> GetSelections()
          {
              return context.Selections.ToList();
          }

                public List<Selection> GetSelection(title, actName, indName, selectedCountry, user)
          {
          Selection selection =new Selection();
          {
                    Id = Guid.NewGuid(),
                    UserID = usr,
                    PlanTitle = title,
                    CountryID=GetID(selectedCountry),//aaaaaaaaaaaaaaaaaaaaaa
                    NaceID = indId.Id,
                    ActionID=actId.Id
            
            }
              return context.Selections.ToList();
          }
               */


        public string AddInfo(string title,Guid activityId, Guid countryId ,Guid usrId)
            {
           //
            BusinessPlan UserPlan = new BusinessPlan() {
                Country = context.Countries.FirstOrDefault(i => i.Id.Equals(countryId)),
                Activity = context.Activities.FirstOrDefault(i => i.Id.Equals(activityId)),
                Title = title
            }; 
            
            UserBusinessPlan a= context.UserBusinessPlans.FirstOrDefault(i => i.Id.Equals(usrId));
            try
            {
                if (a != null)
                {
                    a.BusinessPlans.Add(UserPlan);
                }
                else
                {
                    List<BusinessPlan> Plans = new List<BusinessPlan>();
                    Plans.Add(UserPlan);
                    UserBusinessPlan UserPlansList = new UserBusinessPlan()
                    {
                        Id = Guid.NewGuid(),
                        User = context.Users.FirstOrDefault(i => i.Id.Equals(usrId)),
                        BusinessPlans = Plans

                    };
                    context.UserBusinessPlans.Add(UserPlansList);
                    context.SaveChanges();
                    // Plans.Add(UserPlan);
                }
            }
      catch {
                throw new Exception("Something went wrong...");
            };
           
            


           
           /* UserBusinessPlan UserPlansList = new UserBusinessPlan()
                {
                    Id = Guid.NewGuid(),
                    User = context.Users.FirstOrDefault(i => i.Id.Equals(usrId)),
                    BusinessPlans=Plans

            };*/

                    //context.UserBusinessPlans.Add(UserPlansList);
                    context.SaveChanges();
            return "Sucess";
                }
               
            }

         

            
           }


