using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile(@"C:\Code\cSharp\pluralsight\ScottAllen\LINQSamples\Cars\fuel.csv");

            //var query = cars.OrderByDescending(c => c.Combined)
            //                .ThenBy(c => c.Name);

            var query = 
                from car in cars
                where car.Manufacturer == "BMW" & car.Year == 2016
                orderby car.Combined descending, car.Name ascending
                select car;

            var top = cars
                          .OrderByDescending(c => c.Combined)
                          .ThenBy(c => c.Name)
                          .Select(c => c)
                          .First(c => c.Manufacturer == "BMW" && c.Year == 2016);

            Console.WriteLine(top.Name);

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Manufacturer} {car.Name} : {car.Combined}");
            }
        }

        private static List<Car> ProcessFile(string path)
        {
            //Method Syntax
            //return
            //    File.ReadAllLines(path)
            //        .Skip(1)
            //        .Where(line => line.Length > 1)
            //        .Select(Car.ParseFromCsv)
            //        .ToList();

            //Query Syntax
            var query = from line in File.ReadAllLines(path).Skip(1)
                        where line.Length > 1
                        select Car.ParseFromCsv(line);
            return query.ToList();
        }
    }
}
