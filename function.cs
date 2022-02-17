using System;
using System.Collections.Generic;
using System.Linq;
namespace Linq;

public class Employee
{
    public int Id{get;set;}
    public string? Name{get;set;}
    public string? Department{get;set;}
    public int Age{get;set;}

    
}
public class Standard
{
    public int StandardID{get;set;}
    public string ? StandardName{get;set;}
}

public class EmployeeData
{
    public IList<Employee> GetEmployees(){
        return new List<Employee>() { 
        new Employee() { Id = 1, Name = "John", Department = "Dotnet", Age = 23} ,
        new Employee() { Id = 2, Name = "Moin", Department = "HR", Age = 21 } ,
        new Employee() { Id = 3, Name = "Bill", Department = "Dotnet", Age = 28 } ,
        new Employee() { Id = 4, Name = "Ram" , Department = "HR", Age = 20} ,
        new Employee() { Id = 5, Name = "Ron" , Department = "Dotnet", Age = 25 },
        new Employee() { Id = 6, Name = "Karan", Department = "Dotnet", Age = 23} ,
        new Employee() { Id = 7, Name = "Vikas", Department = "HR", Age = 21 } ,
        new Employee() { Id = 8, Name = "Kiran", Department = "Dotnet", Age = 18 } ,
        new Employee() { Id = 9, Name = "Rohan" , Department = "HR", Age = 22} ,
        new Employee() { Id = 10, Name = "Ron" , Department = "Dotnet", Age = 35 } 
        };
    }
       public IList<Standard> GetStandard(){
        return new List<Standard>() { 
        new Standard() { StandardID = 1, StandardName = "Ankita"} ,
        new Standard() { StandardID = 2, StandardName = "Riya"} ,
        new Standard() { StandardID = 3, StandardName = "Nagul"} ,
        };      
    }
   
    public void DisplayLinqQueries(){

        var min = GetEmployees().Min(s => s.Age);
        Console.WriteLine("Min Employee Age: {0}", min);

        var max = GetEmployees().Max(s => s.Age);
        Console.WriteLine("Max Empoyee Age: {0}", max);

       var orderByResult = from s in GetEmployees()
                   orderby s.Name, s.Age 
                   select new { s.Name, s.Age };

        var avgAge = GetEmployees().Average(s => s.Age);

         Console.WriteLine("Average Age of Employee: {0}", avgAge);

         var total = GetEmployees().Count();
         Console.WriteLine("Total Count of Employee is:{0}",total); 
                  
       var innerjoin = from s in GetEmployees() 
                       join st in GetStandard()
                       on s.Id equals st.StandardID
                       select new{
                           Name = s.Name,
                           StandardName = st.StandardName
                       };
                       foreach(var employee in innerjoin)
                       {
                           Console.WriteLine(employee.Name);
                       }

        var groupJoin = from std in GetStandard()
                    join s in GetEmployees()
                    on std.StandardID equals s.Id
                    into studentgroup 
                    select new{
                        students = studentgroup,
                        standardName = std.StandardName
                    };
                    foreach(var item in groupJoin)
                    {
                        Console.WriteLine(item.standardName);
                    } 
                     
                var adultStudents = GetEmployees().Count(s => s.Age >= 18);

                 Console.WriteLine("Number of Adult Students: {0}", adultStudents );  
                              
      
       var studentsInAscOrder = GetEmployees().OrderBy(s => s.Name);

      // Employee std = new Employee(){ Id =3, Name = "Bill"};
       //bool result = GetEmployees().Contains(std);
       

        var iquerableData = (from emp in GetEmployees()
                            select emp).Skip(2).Take(5);
                            // Console.WriteLine(iquerableData.Name);
        foreach(var employee in iquerableData)
         {
           Console.WriteLine(employee.Name); 
         }
    }
    
}