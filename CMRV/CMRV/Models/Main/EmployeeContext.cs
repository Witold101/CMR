using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CMRVLibrary.Main;
using Microsoft.Ajax.Utilities;

namespace CMRV.Models.Main
{
    public class EmployeeContext:DbContext,IEmployee
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<TypePhone> TypePhones { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CountryCode> CountryCodes { get; set; } 

        public EmployeeContext() : base("DefaultConnection")
        {
            
        }
        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public void DellEmpioyee(Employee employee)
        {
                Employees.Remove(employee);
        }

        public Employee GetEmployee(int id)
        {
            return Employees.Find(id);
        }

        public void EditEmployee(Employee employee)
        {
            Employee empl= Employees.Find(employee.Id);
            empl.Name = employee.Name;
            empl.FullName = employee.FullName;
            empl.AspNetUsersId = employee.AspNetUsersId;
            empl.Email = employee.Email;
            empl.Position = employee.Position;
            empl.RoleId = employee.RoleId;
            empl.PhoneId = employee.PhoneId;
            empl.DateRegistration = employee.DateRegistration;
        }
    }
}