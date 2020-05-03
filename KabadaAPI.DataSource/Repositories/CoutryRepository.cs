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
                    Country country1 = new Country()
                    {
                        Id = Guid.NewGuid(),
                        CountryName = regionInfo.EnglishName,
                        Language = regionInfo.TwoLetterISORegionName,
                        Latitude="555",
                        Longitude="999"

                    };
                    context1.Countries.Add(country1);
                   

                }

            }
            context1.SaveChanges();
            Culturelist.Sort();
            return Culturelist;
        }
        public List<Country> GetCountries()
        {
            List<Country> a = new List<Country>();
            a = context1.Countries.ToList();
            a.Sort((x, y) => string.Compare(x.CountryName, y.CountryName));

            return a;
        }
        public string GetLanguage(string country)
        {
            var lang = context1.Countries.Where(u => u.CountryName == country).FirstOrDefault();
            if (lang != null)
            {
                return lang.Language;
            }
            else { throw new Exception("Country not found"); }
 

        }
        public string GetLongitude(string country)
        {
            var lang = context1.Countries.Where(u => u.CountryName == country).FirstOrDefault();
            if (lang != null)
            {
                return lang.Longitude;
            }
            else { throw new Exception("Country not found"); }


        }
        public string GetLatitude(string country)
        {
            var lang = context1.Countries.Where(u => u.CountryName == country).FirstOrDefault();
            if (lang != null)
            {
                return lang.Latitude;
            }
            else { throw new Exception("Country not found"); }


        }
    }
}




