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
        
        /// <summary>
        /// Добавить соискателя
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        public abstract Applicant AddApplicant(Applicant applicant);
        /// <summary>
        /// получить всех соискателей
        /// </summary>
        /// <returns></returns>
        public abstract List<Applicant> GetApplicants();
        /// <summary>
        /// получить соискателя
        /// </summary>
        /// <param name="applicantId"> идентификатор соискателя</param>
        /// <returns></returns>
        public abstract Applicant GetApplicant(int applicantId);

        /// <summary>
        /// обновить инфу о соискателе
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        public abstract Applicant UpdateApplicant(Applicant applicant);
        /// <summary>
        /// добавить собеседование
        /// </summary>
        /// <param name="interview"></param>
        /// <returns></returns>
        public abstract Interview AddInterview(Interview interview);
        public abstract List<Interview> GetInterviews();
        public abstract Interview GetInterview(int id);
        public abstract List<Employe> Getemployees();
        public abstract Employe GetEmploye(int id);
        public abstract Interview UpdateInterview(Interview interview);
        //public abstract Interview RateInterview(int interviewId, Rating rating);  
    }

}
