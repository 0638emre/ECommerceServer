﻿using ECommerce.Domain.Entities.Common;

namespace ECommerce.Domain.Entities;

public class Menu : BaseEntity
{
    public string Name { get; set; }

    public ICollection<Endpoint> Endpoints { get; set; }
}