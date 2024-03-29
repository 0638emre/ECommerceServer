﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.RequestParameters
{
    public record Pagination
    {
        //burada nesne değil data daha ön planda bu sebeple record yaptık.
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
