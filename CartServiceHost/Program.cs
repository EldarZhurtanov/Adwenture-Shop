﻿using System;
using System.ServiceModel;

namespace CartServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(ServiceImplementations.CartService)))
            {
                host.Open();

                Console.WriteLine("The Cart Service is ready.");
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                host.Close();
            }
        }
    }
}
