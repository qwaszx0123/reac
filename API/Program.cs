using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //            00:01:18.020 ~00:01:27.190  this host is going to store what's returned from our web host create default build a method and I'll
            // 00:01:27.200 ~00:01:33.990  just close this and will remove the run method for now and will add it in later on.

            //00:01:34.000 ~00:01:41.410  Now we want to get a reference to our data context and we can inject our data context inside here.

            var host = CreateHostBuilder(args).Build();


            //           00:01:55.480 ~00:02:00.660  main method and we want to dispose of it after this method is executed.
            //00:02:00.650 ~00:02:08.650  And by using a using statement anything that's inside this method is going to be cleaned up automatically
            //00:02:08.650 ~00:02:10.310  after it's completed.

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    context.Database.Migrate();
                    Seed.SeedData(context);
 //                   00:03:49.090 ~00:03:52.660  we start our application we're going to check to see if we've got a database.
 //00:03:52.720 ~00:03:59.050  If not then one is going to be created based on our migrations and we're also going to add a catch block
 //00:03:59.050 ~00:03:59.860  here.
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "error occur");
                }


 //               00:05:03.120 ~00:05:07.410  so the next time we run our application this is going to create our database based on the migration
 //00:05:08.040 ~00:05:15.470  and what we should see is a new database file called Reactivity is dot D.B.and this is actually going
 //00:05:15.470 ~00:05:17.930  to be created in our API project.
               host.Run();
            }

            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        //load appsetting.json
            Host.CreateDefaultBuilder(args)
            //load host for api
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // use startup class for additional config
                    webBuilder.UseStartup<Startup>();
                });
    }
}
