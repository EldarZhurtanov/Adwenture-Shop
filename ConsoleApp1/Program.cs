using Model;
using Model.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContext context = new AdwentureWorksContext();

            using (UnitOfWork unitOfWork = new UnitOfWork(context))
            {
                var t = unitOfWork.PurchaseOrderHeader.GetList(a=> a.VendorID == 1636);

                foreach (var item in t)
                {
                    Console.WriteLine(item.VendorID);
                }
                Console.ReadKey();
            }
            
        }
    }
}
