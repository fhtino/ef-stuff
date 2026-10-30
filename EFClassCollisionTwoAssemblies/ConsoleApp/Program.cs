using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Reading from LibA.ContosoEntitiesA: ");
            var db_A = new LibA.ContosoEntitiesA();
            var p_A = db_A.Products.First();
            Console.WriteLine($" --> {p_A.ProductName} [{p_A.ProductKey}]");

            Console.Write("Reading from LibB.ContosoEntitiesB: ");
            var db_B = new LibB.ContosoEntitiesB();
            var p_B = db_B.Products.First();
            Console.WriteLine($" --> {p_B.ProductName} [{p_B.ProductKey}]");
        }
    }
}
