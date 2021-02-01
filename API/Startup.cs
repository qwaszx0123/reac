using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Activities;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Persistence;

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


            //              00:07:05.970 ~ 00:07:12.570  services container or our configure services method which is our dependency injection container because
            //  00:07:12.570 ~ 00:07:17.790  we want to make our data context available to other parts of our application and the ordering isn't
            services.AddDbContext<DataContext>(opt =>
            {
                //here connect string   go to  configratuion to read
                opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });


//  00:01:52.400 ~ 00:02:03.210  And in this case it's H TTP local hosts three thousand and this means that any request coming from our
//  00:02:03.210 ~ 00:02:10.050  client application is going to be allowed to use any methods get post put whatever it is.
//  00:02:10.050 ~ 00:02:18.800  And also any header as long as it's coming from local hace 3000 and what we also need to do now that
//  00:02:18.800 ~ 00:02:27.160  we've added this as a service is we need to and this is middleware to our configure method because we
//  00:02:27.160 ~ 00:02:35.140  need to modify the haze TTP response in some way here and our hasty DP response is going to have the


           services.AddCors(opt => 
            {
                opt.AddPolicy("CorsPolicy", policy => 
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });

            services.AddMediatR(typeof(List.Handler).Assembly);
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

//  00:14:18.020 ~ 00:14:25.490  And then what we have is a call to use end points and this is going to map our controller points into
//  00:14:25.490 ~ 00:14:26.200  our API.
//  00:14:26.210 ~ 00:14:33.560  So there are API server knows what to do when a request comes into our API and how to route it to the
//  00:14:33.560 ~ 00:14:34.880  appropriate controller.

//add middle ware here to enable cors
            app.UseCors("CorsPolicy");
            // app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
