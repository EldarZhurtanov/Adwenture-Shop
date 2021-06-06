using System;
using System.ServiceModel;

namespace ProductServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(ServiceImplementations.ProductService)))
            {
                host.Open();

                Console.WriteLine("The Product Service is ready.");
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                host.Close();
            }
        }
    }
}
