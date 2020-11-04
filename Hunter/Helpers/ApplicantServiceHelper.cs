using Bll;
using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hunter.Helpers
{
    public class ApplicantServiceHelper
    {
        ApplicationContext ApplicationContext;
        INotify Notifier;
        public ApplicantServiceHelper(ApplicationContext applicationContext, INotify notifier)
        {
            this.ApplicationContext = applicationContext;
            this.Notifier = notifier;
        }

        public List<Applicant> GetApplicants()
        {
            var result = ApplicationContext.GetApplicants();
            return result;
        }

        public Interview UploadWork(string result, int interviewId )
        {
            var interview = ApplicationContext.GetInterview(interviewId);
            interview.DoneTime = DateTime.Now;
            //{результат куда-то записывается}
            ApplicationContext.UpdateInterview(interview);
            var examenator = ApplicationContext.GetEmploye(interview.ExecutorId);
            var cadrovic = ApplicationContext.GetEmploye(interview.InterviewerId);
            Notifier.NotifyAsync(examenator, $"для интервью {interviewId} загружено выполненное задание");
            Notifier.NotifyAsync(cadrovic, $"для интервью {interviewId} загружено выполненное задание");
            return interview;
        }

        public List<Interview> GetInterviews()
        {
            var result = ApplicationContext.GetInterviews();
            return result;
        }

        public Applicant GetApplicant(int applicantId)
        {
            var applicant = ApplicationContext.GetApplicant(applicantId);
            applicant.Interviews = ApplicationContext.GetInterviews().Where(x => x.ExecutorId == applicant.Id).ToList();
            return applicant;
        }

        public List<Interview> GetInterviews(DateTime startDate, DateTime endDate)
        {
            var result = ApplicationContext.GetInterviews();
            result = result.Where(x => x.Received.Date >= startDate & x.Received <= endDate).ToList();
            return result;
        }

        public Applicant AddApplicant(Applicant applicant)
        {
            var result = ApplicationContext.AddApplicant(applicant);
            return result;
        }
        public Interview AddInterview(Interview interview)
        {
            interview = ApplicationContext.AddInterview(interview);
            var employe = ApplicationContext.GetEmploye(interview.ExamenotorId);
            Notifier.NotifyAsync(employe, $"у вас новый кандидат  {interview.Id}");
            return interview;
        }
        public Interview RateInterview(int interviewId, int rating )
        {

            Rating ratingEnum = (Rating)rating;
            switch (rating)
            {
                case (0):
                    ratingEnum = Rating.ужасно;
                    break;
                        case (1):
                    ratingEnum = Rating.удовлетворительно;
                    break;
                        case (2):
                    ratingEnum = Rating.хорошо;
                    break;
                        case (3):
                    ratingEnum = Rating.отлично;
                    break;
                default:
                    throw new Exception("чет оценочка неккоректная");
            }
            var interview = ApplicationContext.GetInterview(interviewId);
            interview.Rating = (Rating)rating;
            
            var result = ApplicationContext.UpdateInterview(interview);
            Notifier.NotifyAsync(ApplicationContext.GetApplicant(interview.ExecutorId), $"Ваше задание по интервью {interviewId} оценили на {rating}");
            return result;
        }
    }
}
