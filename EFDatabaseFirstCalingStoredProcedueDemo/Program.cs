using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDatabaseFirstCalingStoredProcedueDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GN22ADMDNF001Entities context = new GN22ADMDNF001Entities();

          //  var data = context.Database.ExecuteSqlCommand("SPSelectEmployee");  //Error not solved 
            //Console.WriteLine(data); 

            //************* Fetch ***********

            var data1 = context.SPSelectEmployee();

            foreach (var item in data1)
            {
                Console.WriteLine(item.EmpID + " " + item.EmpName + " " + item.DeptID + " " + item.CourseDuration);
            }

            //*********************** Insert ***************

              Employee employee = new Employee()
            {
                EmpName = "Sameer",
                DeptID = 1,
                CourseDuration = 40

            };

            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@EmpName",employee.EmpName),
                new SqlParameter("@DeptID",employee.DeptID),
                new SqlParameter("@CourseDuration",employee.CourseDuration)
           };
            //ADD EMPLOYEE
            //var data2 = context.SPAddEmployees("Vishal", 1, 45); //error
           var data2 = context.Database.ExecuteSqlCommand("SPAddEmployees @EmpName , @DeptID , @CourseDuration", parameters);
            Console.WriteLine("Data inserted , rows changed =" + data2); //==> data2=1
            context.SaveChanges();

            Console.Read();
        }
    }
}
