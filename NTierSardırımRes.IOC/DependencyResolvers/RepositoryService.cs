﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NTierSardırımRes.BLL.Abstracts;
using NTierSardırımRes.BLL.Concretes;
using NTierSardırımRes.BLL.Services;
using NTierSardırımRes.Common;
using NTierSardırımRes.Common.EmailSender;
using NTierSardırımRes.Entities.Entities;

namespace NTierSardırımRes.IOC.DependencyResolvers
{
    public static class RepositoryService
    {
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IAppRoleRepository, AppRoleRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppUserRoleRepository, AppUserRoleRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductingredientRepository, ProductingredientRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IReservedTableRepository, ReservedTableRepository>();
            services.AddScoped<ITableRepository, TableRepository>();
            services.AddScoped<EmailSender>();
            services.AddScoped<RoleManager<AppRole>>();


            return services;
        }
    }

    
}
