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
        public ApplicantServiceHelper(ApplicationContext applicationContext)
        {
            this.ApplicationContext = applicationContext;
        }

        public List<Applicant> GetApplicants()
        {
            var result = ApplicationContext.GetApplicants();
            return result;
        }

        public Interview UploadWork(string exersize, int interviewId )
        {
            throw new NotImplementedException();
        }

        public List<Interview> GetInterviews()
        {
            var result = ApplicationContext.GetInterviews();
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
            var interview = new Interview() { Rating = ratingEnum, Id = interviewId };
            var result = ApplicationContext.UpdateInterview(interview);
            return result;
        }
    }
}
