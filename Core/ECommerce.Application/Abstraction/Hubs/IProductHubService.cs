﻿namespace ECommerce.Application.Abstraction.Hubs;

public interface IProductHubService
{
    Task ProductAddedMessageAsync(string message);
}