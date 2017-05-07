using System;
using CarService.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Bson.Serialization;
using CarService.Model;

namespace CarService
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // Add MongoDB and Context:
            services.Configure<MongoSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });
            services.AddScoped<CarContext>();

            services.AddTransient<ICarEventStoreRepository, CarEventStoreRespository>();

            RegisterMongoMaps();

        }

        private void RegisterMongoMaps()
        {
            //TODO: There's got to be a better way to do this... 

            if (!BsonClassMap.IsClassMapRegistered(typeof(CarCreatedEvent)))
                BsonClassMap.RegisterClassMap<CarCreatedEvent>();
            if (!BsonClassMap.IsClassMapRegistered(typeof(CarCreatedPayload)))
                BsonClassMap.RegisterClassMap<CarCreatedPayload>();
            if (!BsonClassMap.IsClassMapRegistered(typeof(CarEventStore)))
                BsonClassMap.RegisterClassMap<CarEventStore>();
            if (!BsonClassMap.IsClassMapRegistered(typeof(CarParkedEvent)))
                BsonClassMap.RegisterClassMap<CarParkedEvent>();
            if (!BsonClassMap.IsClassMapRegistered(typeof(Location)))
                BsonClassMap.RegisterClassMap<Location>();
            if (!BsonClassMap.IsClassMapRegistered(typeof(CarTookEvent)))
                BsonClassMap.RegisterClassMap<CarTookEvent>();
            if (!BsonClassMap.IsClassMapRegistered(typeof(CarTookEventPayload)))
                BsonClassMap.RegisterClassMap<CarTookEventPayload>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
