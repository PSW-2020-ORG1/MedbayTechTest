using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.Repository.Repository
{
    interface IGetAll<T>
    {
        List<T> GetAll();
    }
}
