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
    [RoutePrefix("api/TaxonomyL1Service")]
    public class TaxonomyL1ServiceController : ApiController
    {
        [Inject]
        public ITaxonomyL1 _TaxonomyL1Service { get; set; }

        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="taxonomyL1ViewModel"></param>
        /// <returns></returns>
        [Route("CreateTaxonomyL1")]
        [HttpPost]
        public HttpResponseMessage CreateTaxonomyL1(HttpRequestMessage request, [FromBody] TaxonomyL1ViewModel taxonomyL1ViewModel)
        {
            YTransactionalInformation transaction;

            TaxonomyL1 taxonomyL1 = new TaxonomyL1();
            taxonomyL1.Value = taxonomyL1ViewModel.Value;

            TaxonomyL1Service taxonomyL1Service = new TaxonomyL1Service(_TaxonomyL1Service);
            taxonomyL1Service.CreateTaxonomyL1(taxonomyL1, out transaction);
            if (transaction.ReturnStatus == false)
            {
                taxonomyL1ViewModel.ReturnStatus = false;
                taxonomyL1ViewModel.ReturnMessage = transaction.ReturnMessage;
                taxonomyL1ViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<TaxonomyL1ViewModel>(HttpStatusCode.BadRequest, taxonomyL1ViewModel);
                return responseError;

            }

            taxonomyL1ViewModel.id = taxonomyL1.id;
            taxonomyL1ViewModel.ReturnStatus = true;
            taxonomyL1ViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<TaxonomyL1ViewModel>(HttpStatusCode.OK, taxonomyL1ViewModel);
            return response;

        }

        [Route("UpdateTaxonomyL1")]
        [HttpPost]
        public HttpResponseMessage UpdateTaxonomyL1(HttpRequestMessage request, [FromBody] TaxonomyL1ViewModel taxonomyL1ViewModel)
        {
            YTransactionalInformation transaction;

            TaxonomyL1 taxonomyL1 = new TaxonomyL1();
            taxonomyL1.Value = taxonomyL1ViewModel.Value;

            TaxonomyL1Service taxonomyL1Service = new TaxonomyL1Service(_TaxonomyL1Service);
            taxonomyL1Service.UpdateTaxonomyL1(taxonomyL1, out transaction);
            if (transaction.ReturnStatus == false)
            {
                taxonomyL1ViewModel.ReturnStatus = false;
                taxonomyL1ViewModel.ReturnMessage = transaction.ReturnMessage;
                taxonomyL1ViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<TaxonomyL1ViewModel>(HttpStatusCode.BadRequest, taxonomyL1ViewModel);
                return responseError;

            }

            taxonomyL1ViewModel.ReturnStatus = true;
            taxonomyL1ViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<TaxonomyL1ViewModel>(HttpStatusCode.OK, taxonomyL1ViewModel);
            return response;

        }

        /// <summary>
        /// Get Customers
        /// </summary>
        /// <param name="request"></param>
        /// <param name="taxonomyL1ViewModel"></param>
        /// <returns></returns>
        [Route("GetTaxonomyL1s")]
        [HttpPost]
        public HttpResponseMessage GetTaxonomyL1s(HttpRequestMessage request, [FromBody] string stringtext)
        {
            TaxonomyL1ViewModel taxonomyL1ViewModel = new TaxonomyL1ViewModel();

            YTransactionalInformation transaction;

            TaxonomyL1Service taxonomyL1Service = new TaxonomyL1Service(_TaxonomyL1Service);
            List<TaxonomyL1> taxonomyL1s = taxonomyL1Service.GetTaxonomyL1s(out transaction);
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

        /// <summary>
        /// Get Customer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="taxonomyL1ViewModel"></param>
        /// <returns></returns>
        [Route("GetTaxonomyL1")]
        [HttpPost]
        public HttpResponseMessage GetTaxonomyL1(HttpRequestMessage request, [FromBody] TaxonomyL1ViewModel taxonomyL1ViewModel)
        {

            YTransactionalInformation transaction;

            decimal taxonomyL1Id = taxonomyL1ViewModel.id;

            TaxonomyL1Service taxonomyL1Service = new TaxonomyL1Service(_TaxonomyL1Service);
            TaxonomyL1 taxonomyL1 = taxonomyL1Service.GetTaxonomyL1(taxonomyL1Id, out transaction);
            if (transaction.ReturnStatus == false)
            {
                taxonomyL1ViewModel.ReturnStatus = false;
                taxonomyL1ViewModel.ReturnMessage = transaction.ReturnMessage;
                taxonomyL1ViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<TaxonomyL1ViewModel>(HttpStatusCode.BadRequest, taxonomyL1ViewModel);
                return responseError;

            }

            taxonomyL1ViewModel.Value = taxonomyL1.Value;

            taxonomyL1ViewModel.ReturnStatus = true;
            taxonomyL1ViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<TaxonomyL1ViewModel>(HttpStatusCode.OK, taxonomyL1ViewModel);
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

            TaxonomyL1Service taxonomyL1Service = new TaxonomyL1Service(_TaxonomyL1Service);
            taxonomyL1Service.InitializeData(out transaction);
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