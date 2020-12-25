using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.Repository.Repository
{
    interface IDelete<T>
    {
        bool Delete(T entity);
    }
}
