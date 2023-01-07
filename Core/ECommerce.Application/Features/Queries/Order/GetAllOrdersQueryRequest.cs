﻿using MediatR;

namespace ECommerce.Application.Features.Queries.Order
{
    public class GetAllOrdersQueryRequest: IRequest<GetAllOrdersQueryResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }

    }
}
