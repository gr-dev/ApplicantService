using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bll
{
    public class ConcreteInterviewRater : InterviewRater
    {
        public override double RateInterview(Interview interview)
        {
            var days = (interview.Received.Date - interview.DoneTime.Value.Date).Days;
            if (days == 0) days = 1;
            double result = (int)interview.Rating / days;
            return result;
        }
    }
}
