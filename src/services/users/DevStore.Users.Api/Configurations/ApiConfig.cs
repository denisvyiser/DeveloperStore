using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr;
using DevStore.Core.Mediatr.Handlers.Notifications;
using DevStore.Core.Mediatr.Messages;
using DevStore.Db.Postgre.Extensions;
using DevStore.Grpc.Contracts;
using DevStore.Users.Infrastructure.Contexts;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using ProtoBuf.Grpc.Server;
using System.Reflection;
using DevStore.Core.Authentication.Extensions;

namespace DevStore.Users.Api.Configurations
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

            services.AddPostgresContext<UsersDbContext>(conn);

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

            services.AddCodeFirstGrpc();

            services.ConfigureAuthentication(configuration);

            //services.AddAuthorization(auth =>
            //{
            //    auth.AddPolicy("devstore", new AuthorizationPolicyBuilder()
            //        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
            //        .RequireAuthenticatedUser().Build());
            //});

        }

        public static void UseApiConfiguration(this WebApplication app, IWebHostEnvironment env)
        {
            MigrationManager.MigrateDatabase<UsersDbContext>(app).Wait();

            //app.Services.MigrateDatabase<UsersDbContext>();


            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<IUserCredentialsGrpcService>();
                endpoints.MapControllers();
            });


            app.UseCors("All");

            


        }

        public static void RegisterServices(this IServiceCollection services)
        {

            services.Scan(s => s
             .FromApplicationDependencies(a =>
             a.FullName.StartsWith("DevStore.Users.")
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