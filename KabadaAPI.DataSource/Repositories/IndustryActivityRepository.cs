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

        public List<Industry> GetAllIndustriesbyLanguage(string language)
        {
            return context.Industries
                .Where(s => s.Language == language)
                           .ToList();
        }
        //public List<Industry> GetIndustriesbyLanguageAndCode(string language, string code)
        //{
        //    return context.Industries
        //        .Where(s => s.Language == language && s.Code == code)
        //        .Include(s => s.Activities)
        //                   .ToList();
        //}
        public List<Activity> GetAllActivitiesbyLanguageIndustry(string language, string industry)
        {
            return context.Activities
                .Where(s => s.Industry.Language == language && s.Industry.Code == industry)
                           .ToList();
        }
        public List<Activity> GetAllActivitiesbyLanguage(string language)
        {
            return context.Activities
                .Where(s => s.Industry.Language == language)
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
