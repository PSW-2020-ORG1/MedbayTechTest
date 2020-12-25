﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.Repository.Repository
{
    interface IGetBy<T, ID>
    {
        T GetBy(ID id);
    }
}
