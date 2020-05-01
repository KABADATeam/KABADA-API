using System;
using System.Collections.Generic;
using KabadaAPI.DataSource.Models;
using System.Linq;
using System.Globalization;
using System.Net;
using System.Net.Http;

namespace KabadaAPI.DataSource.Repositories
{
    public class CountryRepository
    {

        //   static HttpClient client = new HttpClient();
        public Context context1;
       
        public CountryRepository()
        {
            context1 = new Context();
        }
        
        public List<string> CountryNameList()
        {
            List<string> Culturelist = new List<string>();
            CultureInfo[] getcultureinfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo getculture in getcultureinfo)
            {
                RegionInfo regionInfo = new RegionInfo(getculture.LCID);
                if (!Culturelist.Contains(regionInfo.EnglishName))
                {
                    Culturelist.Add(regionInfo.EnglishName);
                    Country country = new Country()
                    {
                        Id = Guid.NewGuid(),
                        CountryName = regionInfo.EnglishName

                    };
                    context1.Countries.Add(country);
                    

                }

            }context1.SaveChanges();
            Culturelist.Sort();
            return Culturelist;
        }
        public List<Country> GetCountries()
        {
            List<Country> a = new List<Country>();
            a=context1.Countries.ToList();
            a.Sort((x, y) => string.Compare(x.CountryName, y.CountryName));
           
            return a;
        }
        //  public void AddCountry()
        //  {
        //User usr = context.Users.FirstOrDefault(u => u.UserName.Equals(userName));
        //User mail = context.Users.FirstOrDefault(u => u.Email.Equals(email));
        //    List<string> AddingCountry = CountryNameList();

        //  foreach (var Cname in AddingCountry) { 

        //}
        //   context.SaveChanges();

    }


}

