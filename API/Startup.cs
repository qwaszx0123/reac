using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //00:09:05.090 ~ 00:09:12.770  First of all we inject our configuration into our starter class and this means we can access various
            // 00:09:12.830 ~ 00:09:15.170  application settings inside here.
            Configuration = configuration;
            // 00:09:50.090 ~ 00:09:55.440  than this particular logging setting is going to override the equivalent settings in the app settings
            //devlop.json will overide``    
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        // 00:10:23.810 ~ 00:10:31.340  Now this is our dependency injection container any services that we want to be able to consume from
        // other part of application  00:10:33.260 ~ 00:10:39.080  We're going to need to add to our configure services method once they've added in here their land available
        public void ConfigureServices(IServiceCollection services)
        {
            // 00:10:55.310 ~ 00:11:02.780  controllers because we're creating a API then we're going to have controllers and our controllers are
            // 00:11:02.780 ~ 00:11:08.840  going to have the end points and the methods that we call which is going to execute our business logic
//  00:11:08.930 ~ 00:11:13.730  and return the results of whatever we're doing inside that logic.
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
//              00:11:53.300 ~ 00:12:00.080  hasty DP request pipeline and what this means is that we can add middleware to our request pipeline
//  00:12:00.080 ~ 00:12:06.350  that's going to do something with our request as it comes in through our pipeline and out of our pipeline
           
           //middleware
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }
//http will became https
            //app.UseHttpsRedirection();


//  00:13:34.010 ~ 00:13:40.700  What we've also got is some middleware to tell our application to use routing now when a request comes
//  00:13:40.700 ~ 00:13:47.510  into our API our API needs to be able to route it to the appropriate controller.
//  00:13:47.540 ~ 00:13:51.670  So what we've got here is the middleware to enable that functionality.
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
