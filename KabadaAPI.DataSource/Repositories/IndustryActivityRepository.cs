using System;
using System.Collections.Generic;
using KabadaAPI.DataSource.Models;
using System.Text;
using System.Linq;

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
            return context.Industries.ToList();
        }

        public List<Activity> GetActivities()
        {
            return context.Activities.ToList();
        }

        public List<Activity> GetActivity(string industry)
        {
            return context.Activities
                .Where(s => s.Industry.Code == industry)
                           .ToList();
        }
        public void AddIndustry(string code, string title)
        {
            Industry ind = context.Industries.FirstOrDefault(i => i.Code.Equals(code));

            if (ind == null)
            {
                Industry industry = new Industry()
                {
                    Id = Guid.NewGuid(),
                    Code = code,
                    Title = title
                };

                context.Industries.Add(industry);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Such industry already exists");
            }
        }

        public void AddActivity(string code, string title, string industry)
        {
            Activity act = context.Activities.FirstOrDefault(i => i.Code.Equals(code));
            Industry ind = context.Industries.FirstOrDefault(i => i.Code.Equals(industry));

            if (act == null && ind != null)
            {
                Activity activity = new Activity()
                {
                    Id = Guid.NewGuid(),
                    Code = code,
                    Title = title,
                    Industry = ind
                };

                context.Activities.Add(activity);

                context.SaveChanges();
            }
            else
            {
                throw new Exception("Such activity already exists");
            }
        }

        //public void AddIndustryAndActivities(string indCode, string indTitle, List<Activity> activities)
        //{
        //    Industry industry = new Industry()
        //    {
        //        Id = Guid.NewGuid(),
        //        Code = indCode,
        //        Title = indTitle
        //    };

        //    foreach (var act in activities)
        //    {
        //        Activity activity = new Activity()
        //        {
        //            Id = Guid.NewGuid(),
        //            Code = act.Code,
        //            Title = act.Title,
        //            Industry = industry
        //        };
        //        context.Activities.Add(activity);
        //        context.SaveChanges();
        //    }

        //}
    }
}
