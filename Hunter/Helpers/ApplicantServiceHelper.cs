using Bll;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hunter.Helpers
{
    public class ApplicantServiceHelper
    {
        ApplicationContext ApplicationContext;
        Notifier Notifier;
        public ApplicantServiceHelper(ApplicationContext applicationContext, Notifier notifier)
        {
            this.ApplicationContext = applicationContext;
            this.Notifier = notifier;
        }

        public List<Applicant> GetApplicants()
        {
            var result = ApplicationContext.GetApplicants();
            return result;
        }

        public Interview UploadWork(string exersize, int interviewId )
        {
            var result = ApplicationContext.GetInterview(interviewId);
            //какие-то действия с зааднием
            result.DoneTime = DateTime.Now;
            ApplicationContext.UpdateInterview(result);
            Notifier.NotifyUserAsync( new ConcreteMessage($"загружено решение {interviewId}",  "новое решение") , result.ExamenotorId);
            return result;
        }

        public List<Interview> GetInterviews()
        {
            var result = ApplicationContext.GetInterviews();
            return result;
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
            var result = ApplicationContext.AddInterview(interview);

            return result;
        }
        public Interview RateInterview(int interviewId, int rating )
        {

            Rating ratingEnum;
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
                    throw new Exception("чет оценочка не реализована");
                    //ratingEnum = Rating.хорошо;
                    //break;
            }
            var interview = ApplicationContext.GetInterview(interviewId);
            interview.Rating = (Rating)rating;
            
            var result = ApplicationContext.UpdateInterview(interview);
            //Тут может быть уведомление тем, кто заинтересован в этом событии. нужна доп сущность подписчиков
            ///Notifier.NotifyUserAsync($"оценено резюме {interviewId}", userId );
            return result;
        }
    }
}
