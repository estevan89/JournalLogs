﻿using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.JournalLogs.AddRange(
                new JournalLog
                {
                    Content = "First message",
                    DateTime = DateTime.UtcNow,
                },
                new JournalLog
                {
                    Content = "Second message day after",
                    DateTime = DateTime.UtcNow.AddDays(1),
                }
                );

                context.SaveChanges();
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("https://localhost:7001")
                .UseStartup<Startup>();
    }
}
