using CodeProject.WebFrontEnd.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Yoda.Business;
using Yoda.Business.Entities;
using Yoda.Data.EntityFramework;

namespace CodeProject.Portal.WebApiControllers
{
    [RoutePrefix("api/CPEReviewService")]
    public class CPEReviewServiceController : ApiController
    {
        [Inject]
        public ICPEReview _CPEReviewService { get; set; }

        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cpeReviewViewModel"></param>
        /// <returns></returns>
        [Route("CreateCPEDetail")]
        [HttpPost]
        public HttpResponseMessage CreateCPEDetail(HttpRequestMessage request, [FromBody] CPEReviewViewModel cpeReviewViewModel)
        {
            YTransactionalInformation transaction;

            CPEReview cpeReview = new CPEReview();
            cpeReview.CPEDetailsId = cpeReviewViewModel.CPEDetailsId;
            cpeReview.SRNumber = cpeReviewViewModel.SRNumber;
            cpeReview.L1 = cpeReviewViewModel.L1;
            cpeReview.L2 = cpeReviewViewModel.L2;
            cpeReview.L3 = cpeReviewViewModel.L3;
            cpeReview.L4 = cpeReviewViewModel.L4;
            cpeReview.QAAssesment = cpeReviewViewModel.QAAssesment;
            cpeReview.PODManagerComment = cpeReviewViewModel.PODManagerComment;
            cpeReview.PODLeadAction = cpeReviewViewModel.PODLeadAction;
            cpeReview.ActionStatus = cpeReviewViewModel.ActionStatus;

            CPEReviewService cpeReviewService = new CPEReviewService(_CPEReviewService);
            cpeReviewService.CreateCPEReview(cpeReview, out transaction);
            if (transaction.ReturnStatus == false)
            {
                cpeReviewViewModel.ReturnStatus = false;
                cpeReviewViewModel.ReturnMessage = transaction.ReturnMessage;
                cpeReviewViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<CPEReviewViewModel>(HttpStatusCode.BadRequest, cpeReviewViewModel);
                return responseError;

            }

            cpeReviewViewModel.Id = cpeReview.Id;
            cpeReviewViewModel.ReturnStatus = true;
            cpeReviewViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<CPEReviewViewModel>(HttpStatusCode.OK, cpeReviewViewModel);
            return response;

        }

        [Route("UpdateCPEDetail")]
        [HttpPost]
        public HttpResponseMessage UpdateCPEReview(HttpRequestMessage request, [FromBody] CPEReviewViewModel cpeReviewViewModel)
        {
            YTransactionalInformation transaction;

            CPEReview cpeReview = new CPEReview();
            cpeReview.CPEDetailsId = cpeReviewViewModel.CPEDetailsId;
            cpeReview.SRNumber = cpeReviewViewModel.SRNumber;
            cpeReview.L1 = cpeReviewViewModel.L1;
            cpeReview.L2 = cpeReviewViewModel.L2;
            cpeReview.L3 = cpeReviewViewModel.L3;
            cpeReview.L4 = cpeReviewViewModel.L4;
            cpeReview.QAAssesment = cpeReviewViewModel.QAAssesment;
            cpeReview.PODManagerComment = cpeReviewViewModel.PODManagerComment;
            cpeReview.PODLeadAction = cpeReviewViewModel.PODLeadAction;
            cpeReview.ActionStatus = cpeReviewViewModel.ActionStatus;

            CPEReviewService cpeReviewService = new CPEReviewService(_CPEReviewService);
            cpeReviewService.UpdateCPEReview(cpeReview, out transaction);
            if (transaction.ReturnStatus == false)
            {
                cpeReviewViewModel.ReturnStatus = false;
                cpeReviewViewModel.ReturnMessage = transaction.ReturnMessage;
                cpeReviewViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<CPEReviewViewModel>(HttpStatusCode.BadRequest, cpeReviewViewModel);
                return responseError;

            }

            cpeReviewViewModel.ReturnStatus = true;
            cpeReviewViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<CPEReviewViewModel>(HttpStatusCode.OK, cpeReviewViewModel);
            return response;

        }

        /// <summary>
        /// Get Customers
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cpeReviewViewModel"></param>
        /// <returns></returns>
        [Route("GetCPEReviews")]
        [HttpPost]
        public HttpResponseMessage GetCPEReviews(HttpRequestMessage request, [FromBody] CPEReviewViewModel cpeReviewViewModel)
        {

            YTransactionalInformation transaction;

            int currentPageNumber = cpeReviewViewModel.CurrentPageNumber;
            int pageSize = cpeReviewViewModel.PageSize;
            string sortExpression = cpeReviewViewModel.SortExpression;
            string sortDirection = cpeReviewViewModel.SortDirection;

            CPEReviewService cpeReviewService = new CPEReviewService(_CPEReviewService);
            List<CPEReview> cpeReviews = cpeReviewService.GetCPEReviews(currentPageNumber, pageSize, sortExpression, sortDirection, out transaction);
            if (transaction.ReturnStatus == false)
            {
                cpeReviewViewModel.ReturnStatus = false;
                cpeReviewViewModel.ReturnMessage = transaction.ReturnMessage;
                cpeReviewViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<CPEReviewViewModel>(HttpStatusCode.BadRequest, cpeReviewViewModel);
                return responseError;

            }

            cpeReviewViewModel.TotalPages = transaction.TotalPages;
            cpeReviewViewModel.TotalRows = transaction.TotalRows;
            cpeReviewViewModel.CPEReviews = cpeReviews;
            cpeReviewViewModel.ReturnStatus = true;
            cpeReviewViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<CPEReviewViewModel>(HttpStatusCode.OK, cpeReviewViewModel);
            return response;

        }

        /// <summary>
        /// Get Customer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="customerViewModel"></param>
        /// <returns></returns>
        [Route("GetCPEReview")]
        [HttpPost]
        public HttpResponseMessage GetCPEReview(HttpRequestMessage request, [FromBody] CPEReviewViewModel cpeReviewViewModel)
        {

            YTransactionalInformation transaction;

            Guid cpeReviewId = cpeReviewViewModel.Id;

            CPEReviewService cpeReviewService = new CPEReviewService(_CPEReviewService);
            CPEReview cpeReview = cpeReviewService.GetCPEReview(cpeReviewId, out transaction);
            if (transaction.ReturnStatus == false)
            {
                cpeReviewViewModel.ReturnStatus = false;
                cpeReviewViewModel.ReturnMessage = transaction.ReturnMessage;
                cpeReviewViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<CPEReviewViewModel>(HttpStatusCode.BadRequest, cpeReviewViewModel);
                return responseError;

            }

            cpeReviewViewModel.CPEDetailsId = cpeReview.CPEDetailsId;
            cpeReviewViewModel.SRNumber = cpeReview.SRNumber;
            cpeReviewViewModel.L1 = cpeReview.L1;
            cpeReviewViewModel.L2 = cpeReview.L2;
            cpeReviewViewModel.L3 = cpeReview.L3;
            cpeReviewViewModel.L4 = cpeReview.L4;
            cpeReviewViewModel.QAAssesment = cpeReview.QAAssesment;
            cpeReviewViewModel.PODManagerComment = cpeReview.PODManagerComment;
            cpeReviewViewModel.PODLeadAction = cpeReview.PODLeadAction;
            cpeReviewViewModel.ActionStatus = cpeReview.ActionStatus;

            cpeReviewViewModel.ReturnStatus = true;
            cpeReviewViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<CPEReviewViewModel>(HttpStatusCode.OK, cpeReviewViewModel);
            return response;

        }

        /// <summary>
        /// Initialize Data
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("InitializeData")]
        [HttpPost]
        public HttpResponseMessage InitializeData(HttpRequestMessage request)
        {

            YTransactionalInformation transaction;

            CPEReviewService cpeReviewService = new CPEReviewService(_CPEReviewService);
            cpeReviewService.InitializeData(out transaction);
            if (transaction.ReturnStatus == false)
            {
                var responseError = Request.CreateResponse<YTransactionalInformation>(HttpStatusCode.BadRequest, transaction);
                return responseError;

            }

            var response = Request.CreateResponse<YTransactionalInformation>(HttpStatusCode.OK, transaction);
            return response;

        }
    }
}