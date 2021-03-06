﻿namespace SignalROwinApplication
{
    using System;
    using Microsoft.Owin.Hosting;

    public class Program
    {
        public static void Main(string[] args)
        {
            const string Uri = "http://localhost:8088/";

            using (WebApp.Start<Startup>(Uri))
            {
                Console.WriteLine("Server started at " + Uri);
                Console.ReadKey();
                Console.WriteLine("Server stoped.");
            }
        }
    }
}
