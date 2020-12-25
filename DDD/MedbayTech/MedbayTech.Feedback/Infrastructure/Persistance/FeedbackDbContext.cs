using MedbayTech.Repository.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;

namespace MedbayTech.Feedback.Infrastructure.Persistance
{
    public class FeedbackDbContext : MyDbContext<Domain.Entities.Feedback, int>
    {
        public DbSet<Domain.Entities.Feedback> Feedbacks { get; set; }
        public FeedbackDbContext(DbContextOptions<MyDbContext<Domain.Entities.Feedback, int>> options) : base(options) { }
    }
}
