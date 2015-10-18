using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMRVLibrary.Main
{
    public class Employee:Person
    {
        //Ссылка на таблицу с зарегистрированными пользователями
        public int AspNetUsersId { get; set; }
        public string Email { get; set; }
        // Должность
        public string Position { get; set; }
        //Ссылка на таблицу с ролями
        public int RoleId { get; set; }
        public int PhoneId { get; set; }
        public DateTime DateRegistration { get; set; }
        public ICollection<Phone> Phones { get;private set; }
        public ICollection<Role> Roles { get; private set; }

        public Employee(ICollection<Phone> phones,ICollection<Role>roles)
        {
            Roles=new List<Role>(roles);
            Phones=new List<Phone>(phones);
        }
    }
}
