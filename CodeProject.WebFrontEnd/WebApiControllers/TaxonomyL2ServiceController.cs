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
    [RoutePrefix("api/TaxonomyL2Service")]
    public class TaxonomyL2ServiceController : ApiController
    {
        [Inject]
        public ITaxonomyL2 _TaxonomyL2Service { get; set; }

        /// <summary>
        /// Get Customers
        /// </summary>
        /// <param name="request"></param>
        /// <param name="taxonomyL2ViewModel"></param>
        /// <returns></returns>
        [Route("GetTaxonomyL2s")]
        [HttpPost]
        public HttpResponseMessage GetTaxonomyL2s(HttpRequestMessage request, [FromBody] decimal taxonomyL1Id)
        {  
            YTransactionalInformation transaction;
            TaxonomyL2ViewModel taxonomyL2ViewModel = new TaxonomyL2ViewModel();

            TaxonomyL2Service taxonomyL2Service = new TaxonomyL2Service(_TaxonomyL2Service);
            List<TaxonomyL2> taxonomyL2s = taxonomyL2Service.GetTaxonomyL2s(taxonomyL1Id, out transaction);
            if (transaction.ReturnStatus == false)
            {
                taxonomyL2ViewModel.ReturnStatus = false;
                taxonomyL2ViewModel.ReturnMessage = transaction.ReturnMessage;
                taxonomyL2ViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<TaxonomyL2ViewModel>(HttpStatusCode.BadRequest, taxonomyL2ViewModel);
                return responseError;

            }

            taxonomyL2ViewModel.TotalPages = transaction.TotalPages;
            taxonomyL2ViewModel.TotalRows = transaction.TotalRows;
            taxonomyL2ViewModel.TaxonomyL2s = taxonomyL2s;
            taxonomyL2ViewModel.ReturnStatus = true;
            taxonomyL2ViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<TaxonomyL2ViewModel>(HttpStatusCode.OK, taxonomyL2ViewModel);
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

            TaxonomyL2Service taxonomyL2Service = new TaxonomyL2Service(_TaxonomyL2Service);
            taxonomyL2Service.InitializeData(out transaction);
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