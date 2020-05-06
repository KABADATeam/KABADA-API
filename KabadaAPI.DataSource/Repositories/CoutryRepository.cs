﻿using System;
using System.Collections.Generic;
using KabadaAPI.DataSource.Models;
using System.Linq;
using System.Globalization;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
//using 

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
            List<string> names = new List<string>();
            for (int i = 0; i < 250; i++)
            {
                string code = "EN";//dataList[i]["topLevelDomain"][0].ToString();
                                   //  if (code.Length > 1)
                                   //    code = code.Substring(1, code.Length - 1);
                                   //else code = "non";
                string lang = dataList[i]["name"];
                string coords = dataList[i]["latlng"].ToString();
                string nr = dataList[i]["numericCode"].ToString();
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
                else { latit = "non"; longi = "non"; }

                Country country1 = new Country()
                {
                    Id = Guid.NewGuid(),
                    CountryName = lang,
                    Language = code,
                    Latitude = latit,
                    Longitude = longi,
                    CountryNr=nr

                };
                names.Sort();
                names.Add(lang);
                context1.Countries.Add(country1);


                context1.SaveChanges();

            }
            for (int i = 0; i < 250; i++)
            {
                string code = "IT";//dataList[i]["topLevelDomain"][0].ToString();
                                   //  if (code.Length > 1)
                                   //    code = code.Substring(1, code.Length - 1);
                                   //else code = "non";
                string lang1 = dataList[i]["translations"]["it"];
                string coords = dataList[i]["latlng"].ToString();
                string nr = dataList[i]["numericCode"].ToString();
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
                else { latit = "non"; longi = "non"; }

                Country country2 = new Country()
                {
                    Id = Guid.NewGuid(),
                    CountryName = lang1,
                    Language = code,
                    Latitude = latit,
                    Longitude = longi,
                    CountryNr = nr

                };
                names.Sort();

                if (country2.CountryName != null)
                {
                    names.Add(lang1);
                    context1.Countries.Add(country2);
                }


                context1.SaveChanges();

            }
            for (int i = 0; i < 250; i++)
            {
                string code = "PT";//dataList[i]["topLevelDomain"][0].ToString();
                                   //  if (code.Length > 1)
                                   //    code = code.Substring(1, code.Length - 1);
                                   //else code = "non";
                string lang2 = dataList[i]["translations"]["pt"];
                string coords = dataList[i]["latlng"].ToString();
                string nr = dataList[i]["numericCode"].ToString();
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
                else { latit = "non"; longi = "non"; }

                Country country3 = new Country()
                {
                    Id = Guid.NewGuid(),
                    CountryName = lang2,
                    Language = code,
                    Latitude = latit,
                    Longitude = longi,
                    CountryNr=nr

                };
                names.Sort();

                if (country3.CountryName != null)
                {
                    names.Add(lang2);
                    context1.Countries.Add(country3);
                }
                context1.SaveChanges();
            }

            //==========================================================================
         //   var jsonText = File.ReadAllText("filepath");
         //   var sponsors = JsonConvert.DeserializeObject<IList<SponsorInfo>>(jsonText);
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
        public List<string> GetList(string language)
        {
            

            List<string> names = new List<string>();
           List<Country> a1 = context1.Countries.ToList();
            foreach (Country row in a1)
                if(row.Language==language)
                names.Add(row.CountryName);
            names.Sort();
            return names;
        }

      /*  public string GetLanguage(string country,string language)
        {
            var lang = context1.Countries.Where(u => u.CountryName == country && u.Language==language).FirstOrDefault();
            if (lang != null)
            {
                return lang.Language;
            }
            else { throw new Exception("Country not found"); }
 

        }*/

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




