using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
 using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bll
{
    public abstract class ApplicationContext
    {
        
        public abstract Applicant AddApplicant(Applicant applicant);
        public abstract List<Applicant> GetApplicants();
        public abstract Applicant GetApplicant(int applicantId);

        public abstract Applicant UpdateApplicant(Applicant applicant);
        public abstract Interview AddInterview(Interview interview);
        public abstract List<Interview> GetInterviews();
        public abstract List<Employe> Getemployees();
        public abstract Interview UpdateInterview(Interview interview);
        //public abstract Interview RateInterview(int interviewId, Rating rating);  
    }

}
