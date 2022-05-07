﻿using MediatR;
using MediatR.CommandQuery.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Reservas.Application.Services;
using Reservas.Domain.Factories;
using System.Reflection;

namespace Reservas.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IReservaService, ReservaService>();
            services.AddTransient<IReservaFactory, ReservaFactory>();

            return services;
        }

    }
}
