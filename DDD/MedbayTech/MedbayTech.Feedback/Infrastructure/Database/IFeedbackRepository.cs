using MedbayTech.Repository.Repository.SqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Repository.Repository;

namespace MedbayTech.Feedback.Infrastructure.Database
{
    interface IFeedbackRepository : IRepository<Domain.Entities.Feedback, int>
    {
    }
}
