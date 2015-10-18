using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMRVLibrary.Main
{
    public interface IEmployee
    {
        void AddEmployee(Employee employee);
        void DellEmpioyee(Employee employee);
        Employee GetEmployee(int id);
        void EditEmployee(Employee employee);
    }
}
