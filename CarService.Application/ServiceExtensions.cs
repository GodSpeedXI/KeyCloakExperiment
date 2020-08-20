using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CarService.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // Use with need validation on query; Inject FluentValidation
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>, typeof(validationBehavior<,>));
        }
    }
}
