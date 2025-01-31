﻿using DevStore.Core.Mediatr.Messages;
using DevStore.Core.Models.Erros;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net;

namespace DevStore.Api.Core.ExceptionHandlers
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var serviceProvider = context.Features.Get<IServiceProvidersFeature>();

                    var host = context.Request.Host;
                    var scheme = context.Request.Scheme;
                    var path = context.Request.Path;
                    var query = context.Request.QueryString;

                    //var logger = serviceProvider.RequestServices.GetService<ILogger<ErrorDetails>>();

                    var logger = serviceProvider.RequestServices.GetService<ILogger<DomainNotification>>();

                    if (contextFeature != null)
                    {
                        var errorResult = new DomainNotification(ErrorType.ServerError, "System unavailable", "Internal Server Error");


                        //var errorResult = new ErrorResult
                        //{
                        //    Url = $"{scheme}://{host}{path}{query}",
                        //    Errors = new[] {
                        //        "Erro ao processar requisição. Verifique os valores passados e tente novamente.",
                        //        $"Error: {contextFeature.Error.Message}"
                        //    }
                        //};

                        logger.LogError($"Something went wrong: {errorResult.ToString()}");

                        await context.Response.WriteAsync(errorResult.ToString());
                    }
                });
            });
        }
    }
}