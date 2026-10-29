using EFClassCollision.FolderX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFClassCollision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new ContosoEntitiesX();
            var p = db.Products.First();
        }
    }
}
