using System;
using System.Collections.Generic;
using KabadaAPI.DataSource.Models;
using System.Linq;
using System.Globalization;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace KabadaAPI.DataSource.Repositories
{
    public class CountryRepository
    {

        
        public Context context1;

        public CountryRepository()
        {
            context1 = new Context();
        }

        public List<string> CountryNameList()
        {
            WebClient client = new WebClient();
            string stringPageCode = client.DownloadString("https://restcountries.eu/rest/v2");
            dynamic dataList = JsonConvert.DeserializeObject<dynamic>(stringPageCode);
            List < string >names= new List<string>();
            for (int i = 0; i < 250; i++)
            {
                string code = dataList[i]["topLevelDomain"][0].ToString();
                if (code.Length > 1)
                    code = code.Substring(1, code.Length - 1);
                else code = "non";
                string lang = dataList[i]["name"];
                string coords = dataList[i]["latlng"].ToString();
                string latit;
                string longi;
                if (coords.Length > 5)
                {
                    int start = coords.IndexOf(",") + 3;
                    int end = coords.Length - 3;
                    int startIndex = coords.IndexOf("  "); ;
                    int endIndex = coords.IndexOf(",");
                    longi = coords.Substring(startIndex, endIndex - startIndex);
                    latit = coords.Substring(start, end - start);
                }
                else { latit = "non";longi = "non"; }

                Country country1 = new Country()
                {
                    Id = Guid.NewGuid(),
                    CountryName = lang,
                    Language = code,
                    Latitude = latit,
                    Longitude = longi

                };
                names.Sort();
                names.Add(code);
                context1.Countries.Add(country1);
                context1.SaveChanges();
                
            }
            //
            /*
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
            return Culturelist;*/
            return names;
        }
        public List<Country> GetCountries()
        {
            List<Country> a = new List<Country>();
            a = context1.Countries.ToList();
            a.Sort((x, y) => string.Compare(x.CountryName, y.CountryName));

            return a;
        }
        public List<string> GetList()
        {
            

            List<string> names = new List<string>();
           List<Country> a1 = context1.Countries.ToList();
            foreach (Country row in a1)
                names.Add(row.CountryName);
            names.Sort();
            return names;
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




