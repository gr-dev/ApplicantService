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
        public ApplicantController(IConfiguration configuration, ApplicationContext context, ILogger<ApplicantController> logger, INotify notifier) 
        {
            this.Configuration = configuration;
            ApplicantServiceHelper = new ApplicantServiceHelper(context, notifier);
            this.logger = logger;
        }

        /// <summary>
        /// информация о соискателе, включая резюме
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns></returns>
        [HttpGet("GetApplicantInfo")]
        public ActionResult GetApplicantInfo(int applicantId)
        {
            try
            {
                var result = ApplicantServiceHelper.GetApplicant(applicantId);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    logger.LogWarning($"соискатель не найден{applicantId}");
                    return NotFound("соискатель не найден");
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Список соискателей
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Добавить соискателя
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
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

        /// <summary>
        /// добавить соискателя
        /// </summary>
        /// <param name="interview"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Полная модель соискателя и интервью
        /// </summary>
        /// <param name="fullApplicantModel"></param>
        /// <returns></returns>
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

        /// <summary>
        /// оценить задание
        /// </summary>
        /// <param name="ratingmodel"></param>
        /// <returns></returns>
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


        /// <summary>
        /// загрузить выполненное задание
        /// </summary>
        /// <param name="doneWork"></param>
        /// <returns></returns>
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

        /// <summary>
        /// получить отчет по соискателям
        /// </summary>
        /// <param name="dateStart"></param>
        /// <param name="datend"></param>
        /// <returns></returns>
        [HttpGet("GetInterviews")]
        public ActionResult GetInterviews(DateTime dateStart, DateTime datend)
        {
            try
            {
                //Можно тоже через DI кидать
                var rater = new ConcreteInterviewRater();
                var interviews = ApplicantServiceHelper.GetInterviews();
                interviews = interviews.Where(x => x.Received >= dateStart & x.Received <= datend).ToList();
                var result = interviews.Select(x => new RateModel(rater, x)).ToList();
                return Ok(result.Select(x => new {
                    InterviewId = x.Interview.Id,
                    Status = x.Interview.Status,
                    Rating = x.Rating

                }).ToList());
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
