using System;
using System.Collections.Generic;
using KabadaAPI.DataSource.Models;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KabadaAPI.DataSource.Repositories
{
    public class IndustryActivityRepository
    {
        protected readonly Context context;

        public IndustryActivityRepository()
        {
            context = new Context();
        }

        public List<Industry> GetIndustries()
        {
            return context.Industries.OrderBy(x => x.Code).ToList();
        }

        public List<Activity> GetActivities(Guid industryId)
        {
            return context.Activities
                .Where(s => s.Industry.Id == industryId)
                .OrderBy(x => x.Code)
                .ToList();
        }

        public void AddIndustryAndActivities(string indCode, string indTitle, string indLang, string actCode, string actTitle)
        {
            Activity act = context.Activities.FirstOrDefault(i => i.Code.Equals(actCode) && i.Industry.Language.Equals(indLang));
            Industry ind = context.Industries.FirstOrDefault(i => i.Code.Equals(indCode) && i.Language.Equals(indLang));

            if (ind == null && act == null)
            {
                Industry industry = new Industry()
                {
                    Id = Guid.NewGuid(),
                    Code = indCode,
                    Language = indLang,
                    Title = indTitle
                };

                Activity activity = new Activity()
                {
                    Id = Guid.NewGuid(),
                    Code = actCode,
                    Title = actTitle,
                    Industry = industry
                };
                context.Activities.Add(activity);
            }
            else if (ind != null && act == null)
            {
                Activity activity = new Activity()
                {
                    Id = Guid.NewGuid(),
                    Code = actCode,
                    Title = actTitle,
                    Industry = ind
                };
                context.Activities.Add(activity);
            }
            context.SaveChanges();
        }
    }
}
