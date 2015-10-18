using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMRVLibrary.Main
{
    public class Phone
    {
        public int Id { get; set; }
        public int CountryKodeId { get; private set; }
        public string Namber { get; set; }
        public int TypePhoneId { get;private set; }
        public ICollection<TypePhone> TypePhones { get; private set; }
        public ICollection<CountryCode> CountryCodes { get; private set; } 

        public Phone(int typePhoneId, int countryCodeId,ICollection<TypePhone> typePhones,
            ICollection<CountryCode> countryCodes  )
        {
            TypePhones=new List<TypePhone>(typePhones);
            CountryCodes=new List<CountryCode>(countryCodes);
            TypePhoneId = typePhoneId;
            CountryKodeId = countryCodeId;
        }
    }
}
