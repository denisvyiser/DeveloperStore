using DevStore.Core.Authentication.Extensions;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr;
using DevStore.Core.Mediatr.Handlers.Notifications;
using DevStore.Core.Mediatr.Messages;
using DevStore.Db.Postgre.Extensions;
using DevStore.Sales.Infrastructure.Contexts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace DevStore.Sales.Api.Configurations
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApiVersioning(v =>
            {
                v.AssumeDefaultVersionWhenUnspecified = true;
                v.DefaultApiVersion = new ApiVersion(DateTime.Now);
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapperSetup();

            var conn = configuration.GetConnectionString("DEVSTORE");

            services.AddPostgresContext<SalesDbContext>(conn);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.RegisterServices();

            services.AddCors(options =>
            {
                options.AddPolicy("All",
                    builder =>
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });

            services.ConfigureAuthentication(configuration);


        }

        public static void UseApiConfiguration(this WebApplication app, IWebHostEnvironment env)
        {
            MigrationManager.MigrateDatabase<SalesDbContext>(app).Wait();

            //app.Services.MigrateDatabase<UsersDbContext>();


            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.MapControllers();


            app.UseAuthentication();
            app.UseAuthorization();


            app.UseCors("All");



        }

        public static void RegisterServices(this IServiceCollection services)
        {

            services.Scan(s => s
             .FromApplicationDependencies(a =>
             a.FullName.StartsWith("DevStore.Sales.")
             )
             .AddClasses().AsMatchingInterface((service, filter) =>
                 filter.Where(i => i.Name.Equals($"I{service.Name}", StringComparison.OrdinalIgnoreCase)

                 )).WithScopedLifetime()

             .AddClasses(x => x.AssignableTo(typeof(IRequestHandler<,>))).AsImplementedInterfaces().WithScopedLifetime()
             .AddClasses(x => x.AssignableTo(typeof(IRequestHandler<>))).AsImplementedInterfaces().WithScopedLifetime()

             .AddClasses(classes => classes.Where(type => type.Name.EndsWith("EventHandler"))).AsImplementedInterfaces().WithSingletonLifetime()
          );

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //services.AddTransient(s => s.GetService<IHttpContextAccessor>().HttpContext.User);
        }
    }
}