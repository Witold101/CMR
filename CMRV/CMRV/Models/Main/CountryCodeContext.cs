using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CMRVLibrary.Main;

namespace CMRV.Models.Main
{
    public class CountryCodeContext:DbContext
    {
        public DbSet<CountryCode> CountryCodes { get; set; }
        public CountryCodeContext() : base("DefaultConnection")
        {
            
        }
    }
}