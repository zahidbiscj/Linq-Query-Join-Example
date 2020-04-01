// C# program to illustrate the concept 
// of inner join in Query Syntax 
/*using System;
using System.Linq;
using System.Collections.Generic;

// Employee details 
public class Employee1
{

    public int emp_id
    {
        get;
        set;
    }

    public string emp_name
    {
        get;
        set;
    }
    public string emp_lang
    {
        get;
        set;
    }
}

// Employee department details 
public class Employee2
{

    public int emp_id
    {
        get;
        set;
    }

    public string emp_dept
    {
        get;
        set;
    }
    public int emp_salary
    {
        get;
        set;
    }
}

class GFG
{

    // Main method 
    static public void Main()
    {
        List<Employee1> emp1 = new List<Employee1>() {

            new Employee1() {emp_id = 300, emp_name = "Anu",
                                        emp_lang = "C#"},

            new Employee1() {emp_id = 301, emp_name = "Mohit",
                                            emp_lang = "C"},

            new Employee1() {emp_id = 302, emp_name = "Sona",
                                        emp_lang = "Java"},

            new Employee1() {emp_id = 303, emp_name = "Lana",
                                        emp_lang = "Java"},

            new Employee1() {emp_id = 304, emp_name = "Lion",
                                            emp_lang = "C#"},

            new Employee1() {emp_id = 305, emp_name = "Ramona",
                                            emp_lang = "Java"},

        };

        List<Employee2> emp2 = new List<Employee2>() {

            new Employee2() {emp_id = 300, emp_dept = "Designing",
                                            emp_salary = 23000},

            new Employee2() {emp_id = 301, emp_dept = "Developing",
                                            emp_salary = 40000},

            new Employee2() {emp_id = 302, emp_dept = "HR",
                                    emp_salary = 50000},

            new Employee2() {emp_id = 303, emp_dept = "Designing",
                                            emp_salary = 60000},

        };

        // Query to find the name and 
        // the salary of the employees 
        // Using Inner Join 
        *//*var res = from e1 in emp1
				  join e2 in emp2
					  on e1.emp_id equals e2.emp_id
				  select new
				  {
					  Emp_Name = e1.emp_name,
					  Emp_Salary = e2.emp_salary
				  };*//*

        var res = emp1.Join(emp2,
                            e1 => e1.emp_id,
                            e2 => e2.emp_id,
                            (e1, e2) => new
                            {
                                EmployeeName = e1.emp_name,
                                EmployeeDepartment = e2.emp_dept
                            });

        // Display result 
        Console.WriteLine("Employee Name and their Department:");
        foreach (var val in res)
        {
            Console.WriteLine("Employee Name: {0} Department: {1}",
                         val.EmployeeName, val.EmployeeDepartment);
        }


        // Display result 
        Console.WriteLine("Employee and their Salary: ");
        foreach (var val in res)
        {

        }
    }
}*/




using System;
using System.Collections.Generic;
using System.Linq;
namespace FirstCodingExample
{
    class Program
    {
        static void Main(string[] args)
        {

            var students = new List<Student>()
            {
                new Student
                {
                    Id = 1,
                    Name = "John Doe"
                },
                new Student
                {
                    Id = 2,
                    Name = "Jane Doe"
                }
            };

            var results = new List<Result>()
            {
                new Result
                {
                    Id = 1,
                    CourseId = "CSE101",
                    CG = 3.4,
                    StudentId = 1
                },
                new Result
                {
                    Id = 2,
                    CourseId = "CSE101",
                    CG = 3.1,
                    StudentId = 2
                },
                new Result
                {
                    Id = 3,
                    CourseId = "CSE104",
                    CG = 3.2,
                    StudentId = 1
                },
                new Result
                {
                    Id = 4,
                    CourseId = "CSE104",
                    CG = 3.4,
                    StudentId = 2
                },
                new Result
                {
                    Id = 5,
                    CourseId = "CSE107",
                    CG = 3.5,
                    StudentId = 1
                },
                new Result
                {
                    Id = 6,
                    CourseId = "CSE104",
                    CG = 3.9,
                    StudentId = 2
                }
            };

            //var res = (from s in students
            //           join r in results
            //           on s.Id equals r.StudentId
            //           //group s by r into avgCG
            //           select new
            //           {
            //               Id = s.Id
            //               Name = s.Name,
            //               AverageCg = 
            //           });


            var res = students.Join(results,
                student => student.Id, result => result.StudentId,
                (student, result) => new { 
                    Id = student.Id, Name = student.Name, Cg = result.CG
                });

            var studentId = res.Select(x => x.Id).Distinct();

            foreach (var id in studentId)
            {
                var s = res.Where(x => x.Id == id).FirstOrDefault();
                var r = res.Where(x => x.Id == s.Id).Average(x => x.Cg);
                Console.WriteLine(s.Id + " " + s.Name + " " + r);
            }
           
        }
    }
}
