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
            //delegate type
            Func<int, int> square = x => x * x;
            Func<int, int, int> add = (x, y) => {
                int temp = x + y;
                return temp;
            };

            //always returns void
            Action<int> write = x => Console.WriteLine(x);
            //utilizing the write action
            write(square(add(3,5)));

            //IEnumerable<Employee> can use var for implicit typing 
            var developers = new Employee[]
            {
                new Employee{ EmployeeId = 1, EmployeeName = "Scott" },
                new Employee{ EmployeeId = 2, EmployeeName = "Chris"}
            };

            //IEnumerable<Employee> can use var for implicit typing
            var sales = new List<Employee>()
            {
                new Employee{ EmployeeId = 3, EmployeeName = "Alex" }
            };

            //Method syntax
            var query = developers.Where(e => e.EmployeeName.Length == 5)
                .OrderByDescending(e => e.EmployeeName)
                .Select(e => e).Count();

            //Query syntax
            var queryTwo = from developer in developers
                           where developer.EmployeeName.Length == 5
                           orderby developer.EmployeeName descending
                           select developer;

            foreach (var employee in queryTwo)
            {
                Console.WriteLine(employee.EmployeeName);
            }
        }
    }
}
