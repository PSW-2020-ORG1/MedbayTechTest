using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Feedback.Infrastructure.Database;


namespace MedbayTech.Feedback.Infrastructure.Services
{
    public class FeedbackService : IFeedbackService
    {
        private IFeedbackRepository feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
        }

        public List<Domain.Entities.Feedback> GetAll()
        {
            return feedbackRepository.GetAll();
        }

        public List<Domain.Entities.Feedback> GetAllApprovedFeedback()
        {
            return feedbackRepository.GetAllApprovedFeedback();
        }

        public bool UpdateStatus(int feedbackId, bool status)
        {
            return feedbackRepository.UpdateStatus(feedbackId, status);
        }
        public Domain.Entities.Feedback CreateFeedback(string userId, string additionalNotes, Boolean anonymous, Boolean allowed)
        {
            Domain.Entities.Feedback feedback = new Domain.Entities.Feedback();
            feedback.AdditionalNotes = additionalNotes;
            feedback.Anonymous = anonymous;
            feedback.AllowedForPublishing = allowed;
            feedback.Date = DateTime.Now;

            if (!anonymous)
            {
                feedback.UserId = userId;
            }

            return feedbackRepository.Create(feedback);

        }

        public Domain.Entities.Feedback CheckIfExists(Domain.Entities.Feedback feedback)
        {
            List<Domain.Entities.Feedback> feedbacks = feedbackRepository.GetAll().ToList();
            bool exists = feedbacks.Any(s => s.Id == feedback.Id);
            if (exists)
            {
                return feedbacks.FirstOrDefault(s => s.Id == feedback.Id);
            }
            return null;



        }

    }
}

