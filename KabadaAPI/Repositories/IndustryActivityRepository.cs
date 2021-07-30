using System;
using System.Collections.Generic;
using KabadaAPIdao;
using System.Linq;

namespace KabadaAPI {
  public class IndustryActivityRepository : BaseRepository
    {
    
        public IndustryActivityRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}
 

        public List<Industry> GetIndustries()
        {
            return daContext.Industries
                .Where(x => x.Language.Equals("EN"))
                .OrderBy(x => x.Code)
                .ToList();
        }

        public List<Activity> GetActivities(Guid industryId)
        {
            return daContext.Activities
                .Where(s => s.Industry.Id == industryId)
                .OrderBy(x => x.Code)
                .ToList();
        }

        public List<List<Activity>> GetActivitiesByKeyword(string planTitle)
        {            
            List<List<Activity>> allLists = new List<List<Activity>>();
            string[] words = planTitle.Split(' ');
            foreach (string word in words)
            {
             
                List<Activity> act = daContext.Activities.Where(s => s.Title.Contains(word)).ToList();
                List<Activity> actWithoutNull = new List<Activity>();
                if (act.Count != 0) {allLists.Add(act.Distinct().ToList()) ; }

                //EGO: the code below is disabled because it does not work properly; 
                //     should be refined later if necessary
                //
                //if ((word != null )&& (allLists.Count==0))
                // {
                //    WebClient client = new WebClient();

                //    string response = client.DownloadString("http://wikisynonyms.ipeirotis.com/api/"+word+"");

                //     dynamic obj = JsonConvert.DeserializeObject<dynamic>(response);
                //     if (obj!=null&&obj["message"]=="success")
                //     {
                //         List<string> synonyms = new List<string>();
                //         string synonym;
                //         foreach (dynamic term in obj["terms"])
                //         {
                //             synonym = term["term"].ToString();
                //            if(synonym!=null)
                //             synonyms.Add(synonym);
                //         }
                //         foreach (string synonim in synonyms)
                //         {
                //             List<Activity> syn = context.Activities.Where(s => s.Title.Contains(synonim)).ToList();
                //             if (syn.Count != 0) { allLists.Add(syn); }

                //         }
                //     }
                // }

            }
            allLists.RemoveAll(x => x == null);
            return allLists.Distinct().ToList();
        }
          
        

        public void AddIndustryAndActivities(string indCode, string indTitle, string indLang, string actCode, string actTitle)
        {
            Activity act = daContext.Activities.FirstOrDefault(i => i.Code.Equals(actCode) && i.Industry.Language.Equals(indLang));
            Industry ind = daContext.Industries.FirstOrDefault(i => i.Code.Equals(indCode) && i.Language.Equals(indLang));

            if (ind == null && act == null)
            {
                Industry industry = new Industry()
                {                   
                    Code = indCode,
                    Language = indLang,
                    Title = indTitle
                };

                Activity activity = new Activity()
                {                  
                    Code = actCode,
                    Title = actTitle,
                    Industry = industry
                };
                daContext.Activities.Add(activity);
            }
            else if (ind != null && act == null)
            {
                Activity activity = new Activity()
                {           
                    Code = actCode,
                    Title = actTitle,
                    Industry = ind
                };
                daContext.Activities.Add(activity);
            }
            daContext.SaveChanges();
        }        
    protected override object[] getAll4snap() {
      var r=daContext.Activities.ToArray();
      foreach(var o in r)
        o.Industry=null;
      return r;
      }

    protected override string myTable => "Activities";

    protected override bool loadData(string json, bool overwrite, bool oldDeleted) {
      return loadDataRow<KabadaAPIdao.Activity, Guid>(daContext.Activities, json, overwrite, oldDeleted);
      }

    //protected override bool loadData(string json, bool overwrite) {
    //  var o=Newtonsoft.Json.JsonConvert.DeserializeObject<KabadaAPIdao.Activity>(json);
    //  daContext.Activities.Add(o);
    //  return true;
    //  }
    }
  }
