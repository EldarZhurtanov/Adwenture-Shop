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
                var t = unitOfWork.PurchaseOrderHeaderRepository.GetList();

                foreach (var item in t)
                {
                    Console.WriteLine(item.Freight);
                }
                Console.ReadKey();
            }
            
        }
    }
}
