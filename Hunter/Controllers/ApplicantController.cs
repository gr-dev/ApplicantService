using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bll;
using Data.Models;
using Hunter.Helpers;
using Hunter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Hunter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        IConfiguration Configuration;
        ApplicantServiceHelper ApplicantServiceHelper;
        ILogger logger;
        public ApplicantController(IConfiguration configuration, ApplicationContext context, ILogger<ApplicantController> logger, Notifier notifier) 
        {
            this.Configuration = configuration;
            ApplicantServiceHelper = new ApplicantServiceHelper(context, notifier);
            this.logger = logger;
        }

        [HttpGet("GetApplicantInfo")]
        public ActionResult GetApplicantInfo(int applicantId)
        {
            try
            {
                var applicants = ApplicantServiceHelper.GetApplicants();
                var result = applicants.FirstOrDefault(x => x.Id == applicantId);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("соискатель не найден");
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }

        }

        [HttpGet("GetApplicants")]
        public ActionResult GetApplicants()
        {
            try
            {
                var result = ApplicantServiceHelper.GetApplicants();
                return Ok(result);
            }catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }

        }
        [HttpPost("AddApplicant")]
        public ActionResult AddApplicant(Applicant applicant)
        {
            try
            {
                var result = ApplicantServiceHelper.AddApplicant(applicant);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost("AddInterview")]
        public ActionResult AddInterview(Interview interview)
        {
            try
            {
                var result = ApplicantServiceHelper.AddInterview(interview);
                return Ok(result);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);

            }
        }

        [HttpPost("AddApplicantWithInterview")]
        public ActionResult AddApplicantWithInterview(FullApplicantModel fullApplicantModel)
        {
            try
            {
                ApplicantServiceHelper.AddApplicant(fullApplicantModel.Applicant);
                ApplicantServiceHelper.AddInterview(fullApplicantModel.Interview);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost("RateInterview")]
        public ActionResult RateIncident(RateInterviewModel ratingmodel)
        {
            try
            {
                ApplicantServiceHelper.RateInterview(ratingmodel.InterviewId, ratingmodel.Rating);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost("UploadWork")]
        public ActionResult SendWork(DoneWork doneWork)
        {
            try
            {
                var result = ApplicantServiceHelper.UploadWork(doneWork.Exersice, doneWork.InterviewId);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetGlobalResult")]
        public ActionResult GetCurrentResults(DateTime dateStart, DateTime datend)
        {
            throw new NotImplementedException();
        }

        [HttpGet("GetInterviews")]
        public ActionResult GetInterviews(DateTime dateStart, DateTime datend)
        {
            try
            {
                var result = ApplicantServiceHelper.GetInterviews();
                return Ok(result);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
