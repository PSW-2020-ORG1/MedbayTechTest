using MedbayTech.Repository.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.Repository.Infrastructure.Persistance
{
    public class MyDbContext<T> : DbContext
        where T : class
    {
    }
}
