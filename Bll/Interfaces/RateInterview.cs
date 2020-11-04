using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bll
{
    public abstract class InterviewRater
    {
        public abstract double RateInterview(Interview interview);
    }


}
