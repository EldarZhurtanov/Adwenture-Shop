using ServiceImplementations;
using System;
using System.ServiceModel;

namespace PurchaseOrderServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(PurchaseOrderService)))
            {
                host.Open();

                Console.WriteLine("The User Service is ready.");
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                host.Close();
            }
        }
    }
}
