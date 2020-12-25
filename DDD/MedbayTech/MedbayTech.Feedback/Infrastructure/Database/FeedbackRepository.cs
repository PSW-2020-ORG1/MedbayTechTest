﻿using MedbayTech.Repository.Repository.SqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Feedback.Infrastructure.Database
{
    public class FeedbackRepository : SqlRepository<Domain.Entities.Feedback, int>, 
        IFeedbackRepository
    {
    }
}
