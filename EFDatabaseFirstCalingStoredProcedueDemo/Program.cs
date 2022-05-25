using System;
using System.Collections.Generic;
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



            Console.Read();
        }
    }
}
