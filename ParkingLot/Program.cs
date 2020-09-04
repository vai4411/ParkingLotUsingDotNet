// <copyright file="Program.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>

namespace ParkingLot
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    /// <summary>
    /// This class used as main class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// This method used as main method.
        /// </summary>
        /// <param name="args">Argumants.</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// This is web host method.
        /// </summary>
        /// <param name="args">Argumants.</param>
        /// <returns>Host builder.</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
