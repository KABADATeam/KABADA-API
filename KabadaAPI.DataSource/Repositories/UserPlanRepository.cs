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
        

        public List<BusinessPlan> GetPlans(Guid userId)
        {
            List<BusinessPlan> yourPlans = new List<BusinessPlan>();
            User you = context.Users.FirstOrDefault(i => i.Id.Equals(userId));
            UserBusinessPlan plan = context.UserBusinessPlans.FirstOrDefault(i => i.User.Equals(you));
           // UserBusinessPlan plan = context.UserBusinessPlans.FirstOrDefault(i => i.User.Id.Equals(userId));
            yourPlans = plan.BusinessPlans;
            
                if (yourPlans != null)
                {
                    return yourPlans;
                }
                else
                {
                    throw new Exception("Plan was not found");
                }
            
            
            
        }
        public string AddInfo(string title,Guid activityId, Guid countryId ,Guid usrId)
            {
           //
            BusinessPlan UserPlan = new BusinessPlan() {
                Country = context.Countries.FirstOrDefault(i => i.Id.Equals(countryId)),
                Activity = context.Activities.FirstOrDefault(i => i.Id.Equals(activityId)),
                Title = title
            };
          User you= context.Users.FirstOrDefault(i => i.Id.Equals(usrId));
            UserBusinessPlan a = context.UserBusinessPlans.FirstOrDefault(i => i.User.Equals(you));
            try
            {
                if (a== null)
                {
                    List<BusinessPlan> Plans = new List<BusinessPlan>();
                    Plans.Add(UserPlan);
                    UserBusinessPlan UserPlansList = new UserBusinessPlan()
                    {
                        Id = Guid.NewGuid(),
                        User = context.Users.FirstOrDefault(i => i.Id.Equals(usrId)),
                        BusinessPlans = Plans

                    };
                    //a.BusinessPlans.Add(UserPlan) ;
                    context.UserBusinessPlans.Add(UserPlansList);
                    context.SaveChanges();
                    //
                }
                else
                {
                    a.BusinessPlans.Add(UserPlan);
                }
            }
      catch {
                throw new Exception("Something went wrong...");
            };
           
            


       
                    context.SaveChanges();
            return "Success";
                }
               
            }

         

            
           }


