﻿using ECommerce.Application.DTOs.User;
using MediatR;

namespace ECommerce.Application.Features.Queries.AppUser.GetAllUsers
{
    public class GetAllUsersQueryResponse 
    {
        public object Users { get; set; }
        public int TotalUsersCount { get; set; }
    }
}
