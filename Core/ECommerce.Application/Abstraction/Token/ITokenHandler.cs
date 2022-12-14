﻿using ECommerce.Domain.Entities.Identity;

namespace ECommerce.Application.Abstraction.Token
{
    //burada token ve refresh token üretiminden sorumlu servisin interfaceini yapıyoruz.
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int second, AppUser appUser);
        string CreateRefreshToken();
    }
}
