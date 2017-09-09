using CodeProject.WebFrontEnd;
using CodeProject.WebFrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace CodeProject.Portal.WebApiControllers
{
    [RoutePrefix("api/CPEDetailService")]
    public class CPEDetailServiceController : ApiController
    {
      
         static yodaEntities _DbConnection = new yodaEntities();
        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cpeDetailViewModel"></param>
        /// <returns></returns>
        [Route("CreateCPEDetail")]
        [HttpPost]
        public HttpResponseMessage CreateCPEDetail(HttpRequestMessage request, [FromBody] CPEDetailViewModel cpeDetailViewModel)
        {
            YTransactionalInformation transaction = new YTransactionalInformation();

            CPEDetail cpeDetail = new CPEDetail();
            cpeDetail.SRNumber = cpeDetailViewModel.SRNumber;
            cpeDetail.ReviewMonth = cpeDetailViewModel.ReviewMonth;
            cpeDetail.SurveyDate = cpeDetailViewModel.SurveyDate;
            cpeDetail.EngineerName = cpeDetailViewModel.EngineerName;
            cpeDetail.EngManager = cpeDetailViewModel.EngManager;
            cpeDetail.PODName = cpeDetailViewModel.PODName;
            cpeDetail.SRCreatedDate = cpeDetailViewModel.SRCreatedDate;
            cpeDetail.SRDTS = cpeDetailViewModel.SRDTS;
            cpeDetail.QoS = cpeDetailViewModel.QoS;
            cpeDetail.SRDTC = cpeDetailViewModel.SRDTC;
            cpeDetail.IRMissed = cpeDetailViewModel.IRMissed;
            cpeDetail.SupportOffering = cpeDetailViewModel.SupportOffering;
            cpeDetail.SupportServiceLevel = cpeDetailViewModel.SupportServiceLevel;
            cpeDetail.CurrentOwnerGroup = cpeDetailViewModel.CurrentOwnerGroup;
            cpeDetail.SurveyMonth = cpeDetailViewModel.SurveyMonth;
            cpeDetail.QualityAnalystName = cpeDetailViewModel.QualityAnalystName;
            cpeDetail.SRClosedMonth = cpeDetailViewModel.SRClosedMonth;
            cpeDetail.DeliveryRegion = cpeDetailViewModel.DeliveryRegion;
            cpeDetail.AreaName = cpeDetailViewModel.AreaName;
            cpeDetail.SurveyVerbatim = cpeDetailViewModel.SurveyVerbatim;


            try
            {
                _DbConnection.CPEDetails.Add(cpeDetail);
                _DbConnection.SaveChanges();
            }
            catch (Exception ex)
            {
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(ex.Message.ToString());
            }

            if (transaction.ReturnStatus == false)
            {
                cpeDetailViewModel.ReturnStatus = false;
                cpeDetailViewModel.ReturnMessage = transaction.ReturnMessage;
                cpeDetailViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<CPEDetailViewModel>(HttpStatusCode.BadRequest, cpeDetailViewModel);
                return responseError;

            }

            if (transaction.ReturnStatus == false)
            {
                cpeDetailViewModel.ReturnStatus = false;
                cpeDetailViewModel.ReturnMessage = transaction.ReturnMessage;
                cpeDetailViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<CPEDetailViewModel>(HttpStatusCode.BadRequest, cpeDetailViewModel);
                return responseError;

            }

            cpeDetailViewModel.Id = cpeDetail.Id;
            cpeDetailViewModel.ReturnStatus = true;
            cpeDetailViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<CPEDetailViewModel>(HttpStatusCode.OK, cpeDetailViewModel);
            return response;

        } 

        [Route("UpdateCPEDetail")]
        [HttpPost]
        public HttpResponseMessage UpdateCPEDetail(HttpRequestMessage request, [FromBody] CPEDetailViewModel cpeDetailViewModel)
        {
            YTransactionalInformation transaction = new YTransactionalInformation();

            CPEDetail cpeDetail = new CPEDetail();
            cpeDetail.SRNumber = cpeDetailViewModel.SRNumber;
            cpeDetail.ReviewMonth = cpeDetailViewModel.ReviewMonth;
            cpeDetail.SurveyDate = cpeDetailViewModel.SurveyDate;
            cpeDetail.EngineerName = cpeDetailViewModel.EngineerName;
            cpeDetail.EngManager = cpeDetailViewModel.EngManager;
            cpeDetail.PODName = cpeDetailViewModel.PODName;
            cpeDetail.SRCreatedDate = cpeDetailViewModel.SRCreatedDate;
            cpeDetail.SRDTS = cpeDetailViewModel.SRDTS;
            cpeDetail.QoS = cpeDetailViewModel.QoS;
            cpeDetail.SRDTC = cpeDetailViewModel.SRDTC;
            cpeDetail.IRMissed = cpeDetailViewModel.IRMissed;
            cpeDetail.SupportOffering = cpeDetailViewModel.SupportOffering;
            cpeDetail.SupportServiceLevel = cpeDetailViewModel.SupportServiceLevel;
            cpeDetail.CurrentOwnerGroup = cpeDetailViewModel.CurrentOwnerGroup;
            cpeDetail.SurveyMonth = cpeDetailViewModel.SurveyMonth;
            cpeDetail.QualityAnalystName = cpeDetailViewModel.QualityAnalystName;
            cpeDetail.SRClosedMonth = cpeDetailViewModel.SRClosedMonth;
            cpeDetail.DeliveryRegion = cpeDetailViewModel.DeliveryRegion;
            cpeDetail.AreaName = cpeDetailViewModel.AreaName;
            cpeDetail.SurveyVerbatim = cpeDetailViewModel.SurveyVerbatim;

            try
            {
               _DbConnection.Entry(cpeDetail).State = EntityState.Modified;
               _DbConnection.SaveChanges();
            }
            catch (Exception ex)
            {
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(ex.Message.ToString());
            }
   
            if (transaction.ReturnStatus == false)
            {
                cpeDetailViewModel.ReturnStatus = false;
                cpeDetailViewModel.ReturnMessage = transaction.ReturnMessage;
                cpeDetailViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<CPEDetailViewModel>(HttpStatusCode.BadRequest, cpeDetailViewModel);
                return responseError;

            }

            cpeDetailViewModel.ReturnStatus = true;
            cpeDetailViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<CPEDetailViewModel>(HttpStatusCode.OK, cpeDetailViewModel);
            return response;

        }

       
        /// <summary>
        /// Get Customers
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cpeDetailViewModel"></param>
        /// <returns></returns>
        [Route("GetCPEDetails")]
        [HttpPost]
        public HttpResponseMessage GetCPEDetails(HttpRequestMessage request, [FromBody] CPEDetailViewModel cpeDetailViewModel)
        {

            YTransactionalInformation transaction = new YTransactionalInformation();
            int currentPageNumber = cpeDetailViewModel.CurrentPageNumber;
            int pageSize = cpeDetailViewModel.PageSize;
            string sortExpression = cpeDetailViewModel.SortExpression;
            string sortDirection = cpeDetailViewModel.SortDirection;

            List<CPEDetail> cpeDetails = null;
            // You have to change this 
            cpeDetails = _DbConnection.CPEDetails.ToList();

            int rowsReturn = 0; 
            try
            {
                foreach (WebFrontEnd.CPEDetail cpeDetail in cpeDetails)
                {
                    cpeDetail.CPEReviews = (from store in _DbConnection.CPEReviews
                                            where store.CPEDetailsId == cpeDetail.Id
                                            select store).ToList<CPEReview>();
                }
                 rowsReturn = _DbConnection.CPEDetails.Count();
            }
            catch (Exception ex)
            {
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(ex.Message.ToString());
            }

            if (transaction.ReturnStatus == false)
            {
                cpeDetailViewModel.ReturnStatus = false;
                cpeDetailViewModel.ReturnMessage = transaction.ReturnMessage;
                cpeDetailViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<CPEDetailViewModel>(HttpStatusCode.BadRequest, cpeDetailViewModel);
                return responseError;
            }

            cpeDetailViewModel.TotalPages = transaction.TotalPages;
            cpeDetailViewModel.TotalRows = transaction.TotalRows;
            cpeDetailViewModel.CPEDetails = cpeDetails;
            cpeDetailViewModel.ReturnStatus = true;
            cpeDetailViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<CPEDetailViewModel>(HttpStatusCode.OK, cpeDetailViewModel);
            return response;

        }

       /// <summary>
        /// Get Customer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="customerViewModel"></param>
        /// <returns></returns>
        [Route("GetCPEDetail")]
        [HttpPost]
        public HttpResponseMessage GetCPEDetail(HttpRequestMessage request, [FromBody] CPEDetailViewModel cpeDetailViewModel)
        {

            YTransactionalInformation transaction = new YTransactionalInformation();
            CPEDetail cpeDetail = null;
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                Guid cpeDetailId = cpeDetailViewModel.Id;
                cpeDetail = _DbConnection.CPEDetails.Find(cpeDetailId);
                if (cpeDetail != null)
                {
                    cpeDetailViewModel.SRNumber = cpeDetail.SRNumber;
                    cpeDetailViewModel.ReviewMonth = cpeDetail.ReviewMonth;
                    cpeDetailViewModel.SurveyDate = cpeDetail.SurveyDate;
                    cpeDetailViewModel.EngineerName = cpeDetail.EngineerName;
                    cpeDetailViewModel.EngManager = cpeDetail.EngManager;
                    cpeDetailViewModel.PODName = cpeDetail.PODName;
                    cpeDetailViewModel.SRCreatedDate = cpeDetail.SRCreatedDate;
                    cpeDetailViewModel.SRDTS = cpeDetail.SRDTS;
                    cpeDetailViewModel.QoS = cpeDetail.QoS;
                    cpeDetailViewModel.SRDTC = cpeDetail.SRDTC;
                    cpeDetailViewModel.IRMissed = cpeDetail.IRMissed;
                    cpeDetailViewModel.SupportOffering = cpeDetail.SupportOffering;
                    cpeDetailViewModel.SupportServiceLevel = cpeDetail.SupportServiceLevel;
                    cpeDetailViewModel.CurrentOwnerGroup = cpeDetail.CurrentOwnerGroup;
                    cpeDetailViewModel.SurveyMonth = cpeDetail.SurveyMonth;
                    cpeDetailViewModel.QualityAnalystName = cpeDetail.QualityAnalystName;
                    cpeDetailViewModel.SRClosedMonth = cpeDetail.SRClosedMonth;
                    cpeDetailViewModel.DeliveryRegion = cpeDetail.DeliveryRegion;
                    cpeDetailViewModel.AreaName = cpeDetail.AreaName;
                    cpeDetailViewModel.SurveyVerbatim = cpeDetail.SurveyVerbatim;
                    cpeDetailViewModel.ReturnStatus = true;
                    cpeDetailViewModel.ReturnMessage = transaction.ReturnMessage;
                    response = Request.CreateResponse<CPEDetailViewModel>(HttpStatusCode.OK, cpeDetailViewModel);
                   
                }
            }
            catch (Exception ex)
            {
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add( ex.Message.ToString());

                if (transaction.ReturnStatus == false)
                {
                    cpeDetailViewModel.ReturnStatus = false;
                    cpeDetailViewModel.ReturnMessage = transaction.ReturnMessage;
                    cpeDetailViewModel.ValidationErrors = transaction.ValidationErrors;
                     response = Request.CreateResponse<CPEDetailViewModel>(HttpStatusCode.BadRequest, cpeDetailViewModel);
                    
                }
            }
           return response;
} 
    
        [Route("GetTaxonomyL1s")]
        [HttpPost]
        public HttpResponseMessage GetTaxonomyL1s(HttpRequestMessage request, [FromBody] TaxonomyL1ViewModel taxonomyL1ViewModel)
        {
            YTransactionalInformation transaction = new YTransactionalInformation();
            int currentPageNumber = taxonomyL1ViewModel.CurrentPageNumber;
            int pageSize = taxonomyL1ViewModel.PageSize;
            string sortExpression = taxonomyL1ViewModel.SortExpression;
            string sortDirection = taxonomyL1ViewModel.SortDirection;
            List<TaxonomyL1> taxonomyL1s = null;         
         
            int rowsReturn = 0;
            try
            {
                taxonomyL1s = _DbConnection.TaxonomyL1.ToList();
                rowsReturn = _DbConnection.TaxonomyL1.Count();
            }
            catch (Exception ex)
            {
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(ex.Message.ToString());
            }

            if (transaction.ReturnStatus == false)
            {
                taxonomyL1ViewModel.ReturnStatus = false;
                taxonomyL1ViewModel.ReturnMessage = transaction.ReturnMessage;
                taxonomyL1ViewModel.ValidationErrors = transaction.ValidationErrors;
                var responseError = Request.CreateResponse<TaxonomyL1ViewModel>(HttpStatusCode.BadRequest, taxonomyL1ViewModel);
                return responseError;
            }
            taxonomyL1ViewModel.TotalPages = transaction.TotalPages;
            taxonomyL1ViewModel.TotalRows = transaction.TotalRows;
            taxonomyL1ViewModel.TaxonomyL1s = taxonomyL1s;
            taxonomyL1ViewModel.ReturnStatus = true;
            taxonomyL1ViewModel.ReturnMessage = transaction.ReturnMessage;
            var response = Request.CreateResponse<TaxonomyL1ViewModel>(HttpStatusCode.OK, taxonomyL1ViewModel);
            return response;
        }

        [Route("GetTestAPI")]
        [HttpGet]
        public HttpResponseMessage GetTestAPI(HttpRequestMessage requestl)
        {
            List<TaxonomyL1> taxonomyL1s = null;

            int rowsReturn = 0;
            try
            {
                taxonomyL1s = _DbConnection.TaxonomyL1.ToList();
                rowsReturn = _DbConnection.TaxonomyL1.Count();

                var response = Request.CreateResponse<List<TaxonomyL1>>(HttpStatusCode.OK, taxonomyL1s);
                return response;
            }
            catch (Exception ex)
            {
                var responseError = Request.CreateResponse<List<TaxonomyL1>>(HttpStatusCode.BadRequest, taxonomyL1s);
                return responseError;

            }          
        }
        /*
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

                    CPEDetailService cpeDetailService = new CPEDetailService(_CPEDetailService);
                    cpeDetailService.InitializeData(out transaction);
                    if (transaction.ReturnStatus == false)
                    {
                        var responseError = Request.CreateResponse<YTransactionalInformation>(HttpStatusCode.BadRequest, transaction);
                        return responseError;

                    }

                    var response = Request.CreateResponse<YTransactionalInformation>(HttpStatusCode.OK, transaction);
                    return response;

                } */
    }
}