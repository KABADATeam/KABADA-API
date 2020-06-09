using System;
using System.Collections.Generic;
using KabadaAPI.DataSource.Models;
using System.Linq;
using System.Globalization;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.IO;

namespace KabadaAPI.DataSource.Repositories
{
    public class CountryRepository
    {

        public Context context;

        public CountryRepository()
        {
            context = new Context();
        }

        public List<Country> GetCountries()
        {
            var list = context.Countries.ToList();
            return list.OrderBy(x => x.Title).ToList();
        }
    }
}




