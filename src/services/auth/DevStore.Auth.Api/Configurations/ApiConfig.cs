using DevStore.Api.Core.ExceptionHandlers;
using DevStore.Auth.Application.Grpc.Config;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr;
using DevStore.Core.Mediatr.Handlers.Notifications;
using DevStore.Core.Mediatr.Messages;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace DevStore.Auth.Api.Configurations
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            var gprcConfig = configuration.GetSection(nameof(GrpcConfig)).Get<GrpcConfig>();

            services.AddSingleton<GrpcConfig>(gprcConfig);

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


        }

        public static void UseApiConfiguration(this WebApplication app, IWebHostEnvironment env)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();


            app.MapControllers();

            app.UseAuthorization();


            app.UseCors("All");
        }

        public static void RegisterServices(this IServiceCollection services)
        {

            services.Scan(s => s
             .FromApplicationDependencies(a =>
             a.FullName.StartsWith("DevStore.Auth.")
             )
             .AddClasses().AsMatchingInterface((service, filter) =>
                 filter.Where(i => i.Name.Equals($"I{service.Name}", StringComparison.OrdinalIgnoreCase)

                 )).WithScopedLifetime()

          );

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //services.AddTransient(s => s.GetService<IHttpContextAccessor>().HttpContext.User);
        }
    }
}