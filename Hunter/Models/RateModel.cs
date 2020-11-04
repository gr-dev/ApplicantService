using Bll;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hunter.Models
{
    public class RateModel
    {
        public RateModel(InterviewRater rate, Interview interview)
        {
            this.Interview = interview;
            this.Rating = rate.RateInterview(Interview);
        }
        public Interview Interview{ get;  }
        public double Rating{ get;  }
    }
}
