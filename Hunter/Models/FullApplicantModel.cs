using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hunter.Models
{
    public class FullApplicantModel
    {
        public Applicant Applicant{ get; set; }
        public Interview Interview { get; set; }
    }
}
