using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqQuery
{
    internal class Program
    {
        public static List<Employee> employees = new List<Employee>();
        public static List<Project> projects = new List<Project>();
        static void Main(string[] args)
        {
            List<int> number = new() { 2, 4, 6, 7, 8, 9 };


            //query syntax
            IEnumerable<int> filteringQuery = from num in number
                                              where num < 3 || num > 8
                                              orderby num descending
                                              select num;
            foreach (int item in filteringQuery)
            {
                //Console.WriteLine(item);
            }

            //method syntax
            List<int> number2 = new() { 10, 25, 18, 20, 22, 17, 11 };
            var avarage = number2.Average();
            //Console.WriteLine(avarage);

            var contact = number.Concat(number2);
            foreach (var item in contact)
            {
                //Console.Write($"{item},");
            }

            IEnumerable<int> largeNumber = number2.Where(c => c > 17);
            foreach (var item in largeNumber)
            {
                //Console.WriteLine(item);                                            
            }

            //mixed query
            // Using a query expression with method syntax
            var largeNum = (from num in number2
                            where num > 20
                            select num).Count();
            //Console.WriteLine(largeNum);

            // Better: Create a new variable to store
            // the method call result

            IEnumerable<int> smallNumber = number2.Where(c => c < 11);
            IEnumerable<int> samllNumber1 = from num in number2
                                            where num < 11
                                            select num;

            foreach (var item in samllNumber1)
            {
                //Console.WriteLine(item);
            }

            var samllNumberCount = samllNumber1.Count();
            //Console.WriteLine(samllNumberCount);

            InitializeEmployee();
            InitializeProject();

            //query syntax
            //var query = (from name in employees
            //                    select name).Count();

            //method syntax
            //var query = employees.OrderBy(x => x.EmployeeName).Count();
            //Console.WriteLine(query);


            //order by
            //var query = from emp in employees
            //            orderby emp.EmployeeName descending
            //            select emp;

            //var query = employees.OrderByDescending(x => x.EmployeeName);
            //var query = employees.OrderBy(x => x.EmployeeName);

            //var query = from emp in employees
            //            orderby emp.EmployeeName descending, emp.EmployeeId ascending
            //            select emp;

            //var query = employees.OrderBy(x => x.EmployeeName).ThenByDescending(x => x.EmployeeId);

            //var query = from emp in employees
            //            where emp.EmployeeName.StartsWith("M") && emp.EmployeeName.EndsWith("n")
            //            select emp;

            //var query = employees.Where(x => x.EmployeeName.StartsWith("M") || x.EmployeeName.EndsWith("n"));

            //-----Take
            //var query = (from emp in employees
            //             select emp).Take(2);

            //var query = employees.Take(4);

            //-------skip
            //var query = (from emp in employees
            //             select emp).Skip(2);

            //var query = employees.Skip(3);

            //-----group
            //var query = from emp in employees
            //            group emp by emp.ProjectId;

            //var query = employees.GroupBy(x => x.ProjectId);
            //foreach (var item in query)
            //{
            //    Console.WriteLine($"{item.Key}, {item.Count()}");
            //    //Console.WriteLine($"{item.EmployeeName}, {item.EmployeeId}");
            //}

            //join
            //var query = from emp in employees
            //            join project in projects on emp.ProjectId equals project.ProjectId
            //            select new { emp.EmployeeName, project.ProjectName };

            var query = employees.Join(projects, e => e.ProjectId, p => p.ProjectId,
                (e, p) => new {e.EmployeeName, p.ProjectName});

            foreach (var item in query)
            {
                Console.WriteLine($"{item.EmployeeName}, {item.ProjectName}");
            }


            //foreach (var item in query)
            //{
            //    Console.WriteLine($"{item.EmployeeName}, {item.EmployeeId}");
            //}

        }

        public static void InitializeEmployee()
        {
            employees.Add(new Employee()
            {
                EmployeeId = 1,
                EmployeeName = "Mizan",
                ProjectId = 1,
            });

            employees.Add(new Employee()
            {
                EmployeeId = 2,
                EmployeeName = "Ripon",
                ProjectId = 1,
            });

            employees.Add(new Employee()
            {
                EmployeeId = 3,
                EmployeeName = "Mithun",
                ProjectId = 2,
            });

            employees.Add(new Employee()
            {
                EmployeeId = 4,
                EmployeeName = "Rasel",
                ProjectId = 2,
            });

            employees.Add(new Employee()
            {
                EmployeeId = 5,
                EmployeeName = "Rasel",
                ProjectId = 2,
            });
        }

        public static void InitializeProject()
        {
            projects.Add(new Project() { ProjectId = 1, ProjectName = "DevSkill" });
            projects.Add(new Project() { ProjectId = 2, ProjectName = "DevTeam" });
        }
    }
}
