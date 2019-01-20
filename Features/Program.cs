using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee{ EmployeeId = 1, EmployeeName = "Scott" },
                new Employee{ EmployeeId = 2, EmployeeName = "Chris"}
            };

            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee{ EmployeeId = 3, EmployeeName = "Alex" }
            };

            Console.WriteLine(sales.Count());
            //Without LINQ                      //can switch to sales here and still work due to IEnumerator
            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.EmployeeName);
            }

            //Both an array and lists implent IEnumerable<T> which allows us to use the below for both collections
            //foreach(var person in developers)
            //{
            //    Console.WriteLine(person.EmployeeName);
            //}
        }
    }
}
