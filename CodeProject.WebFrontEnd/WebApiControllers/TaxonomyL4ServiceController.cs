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
    [RoutePrefix("api/TaxonomyL4Service")]
    public class TaxonomyL4ServiceController : ApiController
    {
        [Inject]
        public ITaxonomyL4 _TaxonomyL4Service { get; set; }

        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="taxonomyL4ViewModel"></param>
        /// <returns></returns>
        [Route("CreateTaxonomyL4")]
        [HttpPost]
        public HttpResponseMessage CreateTaxonomyL4(HttpRequestMessage request, [FromBody] TaxonomyL4ViewModel taxonomyL4ViewModel)
        {
            YTransactionalInformation transaction;

            TaxonomyL4 taxonomyL4 = new TaxonomyL4();
            taxonomyL4.L3_Id = taxonomyL4ViewModel.L3_Id;
            taxonomyL4.Value = taxonomyL4ViewModel.Value;

            TaxonomyL4Service taxonomyL4Service = new TaxonomyL4Service(_TaxonomyL4Service);
            taxonomyL4Service.CreateTaxonomyL4(taxonomyL4, out transaction);
            if (transaction.ReturnStatus == false)
            {
                taxonomyL4ViewModel.ReturnStatus = false;
                taxonomyL4ViewModel.ReturnMessage = transaction.ReturnMessage;
                taxonomyL4ViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<TaxonomyL4ViewModel>(HttpStatusCode.BadRequest, taxonomyL4ViewModel);
                return responseError;

            }

            taxonomyL4ViewModel.id = taxonomyL4.id;
            taxonomyL4ViewModel.ReturnStatus = true;
            taxonomyL4ViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<TaxonomyL4ViewModel>(HttpStatusCode.OK, taxonomyL4ViewModel);
            return response;

        }

        [Route("UpdateTaxonomyL4")]
        [HttpPost]
        public HttpResponseMessage UpdateTaxonomyL4(HttpRequestMessage request, [FromBody] TaxonomyL4ViewModel taxonomyL4ViewModel)
        {
            YTransactionalInformation transaction;

            TaxonomyL4 taxonomyL4 = new TaxonomyL4();
            taxonomyL4.L3_Id = taxonomyL4ViewModel.L3_Id;
            taxonomyL4.Value = taxonomyL4ViewModel.Value;

            TaxonomyL4Service taxonomyL4Service = new TaxonomyL4Service(_TaxonomyL4Service);
            taxonomyL4Service.UpdateTaxonomyL4(taxonomyL4, out transaction);
            if (transaction.ReturnStatus == false)
            {
                taxonomyL4ViewModel.ReturnStatus = false;
                taxonomyL4ViewModel.ReturnMessage = transaction.ReturnMessage;
                taxonomyL4ViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<TaxonomyL4ViewModel>(HttpStatusCode.BadRequest, taxonomyL4ViewModel);
                return responseError;

            }

            taxonomyL4ViewModel.ReturnStatus = true;
            taxonomyL4ViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<TaxonomyL4ViewModel>(HttpStatusCode.OK, taxonomyL4ViewModel);
            return response;

        }

        /// <summary>
        /// Get Customers
        /// </summary>
        /// <param name="request"></param>
        /// <param name="taxonomyL4ViewModel"></param>
        /// <returns></returns>
        [Route("GetTaxonomyL4")]
        [HttpPost]
        public HttpResponseMessage GetTaxonomyL4s(HttpRequestMessage request, [FromBody] TaxonomyL4ViewModel taxonomyL4ViewModel)
        {

            YTransactionalInformation transaction;

            int currentPageNumber = taxonomyL4ViewModel.CurrentPageNumber;
            int pageSize = taxonomyL4ViewModel.PageSize;
            string sortExpression = taxonomyL4ViewModel.SortExpression;
            string sortDirection = taxonomyL4ViewModel.SortDirection;

            TaxonomyL4Service taxonomyL4Service = new TaxonomyL4Service(_TaxonomyL4Service);
            List<TaxonomyL4> taxonomyL4s = taxonomyL4Service.GetTaxonomyL4s(currentPageNumber, pageSize, sortExpression, sortDirection, out transaction);
            if (transaction.ReturnStatus == false)
            {
                taxonomyL4ViewModel.ReturnStatus = false;
                taxonomyL4ViewModel.ReturnMessage = transaction.ReturnMessage;
                taxonomyL4ViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<TaxonomyL4ViewModel>(HttpStatusCode.BadRequest, taxonomyL4ViewModel);
                return responseError;

            }

            taxonomyL4ViewModel.TotalPages = transaction.TotalPages;
            taxonomyL4ViewModel.TotalRows = transaction.TotalRows;
            taxonomyL4ViewModel.TaxonomyL4s = taxonomyL4s;
            taxonomyL4ViewModel.ReturnStatus = true;
            taxonomyL4ViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<TaxonomyL4ViewModel>(HttpStatusCode.OK, taxonomyL4ViewModel);
            return response;

        }

        /// <summary>
        /// Get Customer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="taxonomyL4ViewModel"></param>
        /// <returns></returns>
        [Route("GetCPEReview")]
        [HttpPost]
        public HttpResponseMessage GetTaxonomyL4(HttpRequestMessage request, [FromBody] TaxonomyL4ViewModel taxonomyL4ViewModel)
        {

            YTransactionalInformation transaction;

            decimal taxonomyL4Id = taxonomyL4ViewModel.id;

            TaxonomyL4Service taxonomyL4Service = new TaxonomyL4Service(_TaxonomyL4Service);
            TaxonomyL4 taxonomyL4 = taxonomyL4Service.GetTaxonomyL4(taxonomyL4Id, out transaction);
            if (transaction.ReturnStatus == false)
            {
                taxonomyL4ViewModel.ReturnStatus = false;
                taxonomyL4ViewModel.ReturnMessage = transaction.ReturnMessage;
                taxonomyL4ViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<TaxonomyL4ViewModel>(HttpStatusCode.BadRequest, taxonomyL4ViewModel);
                return responseError;

            }

            taxonomyL4ViewModel.L3_Id = taxonomyL4.L3_Id;
            taxonomyL4ViewModel.Value = taxonomyL4.Value;

            taxonomyL4ViewModel.ReturnStatus = true;
            taxonomyL4ViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<TaxonomyL4ViewModel>(HttpStatusCode.OK, taxonomyL4ViewModel);
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

            TaxonomyL4Service taxonomyL4Service = new TaxonomyL4Service(_TaxonomyL4Service);
            taxonomyL4Service.InitializeData(out transaction);
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