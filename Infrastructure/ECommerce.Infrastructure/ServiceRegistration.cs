﻿using ECommerce.Application.Abstractions.Services;
using ECommerce.Application.Abstractions.Services.Configurations;
using ECommerce.Application.Abstractions.Storage;
using ECommerce.Application.Abstractions.Token;
using ECommerce.Infrastructure.Enums;
using ECommerce.Infrastructure.Services;
using ECommerce.Infrastructure.Services.Configurations;
using ECommerce.Infrastructure.Services.Storage;
using ECommerce.Infrastructure.Services.Storage.Azure;
using ECommerce.Infrastructure.Services.Storage.Local;
using ECommerce.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;


namespace ECommerce.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped<IApplicationService, ApplicationService>();
            serviceCollection.AddScoped<IMailService, MailService>();
            serviceCollection.AddScoped<IQRCodeService, QRCodeService>();
        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }

        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageType.AWS:
                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}