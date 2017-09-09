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
    [RoutePrefix("api/TaxonomyL3Service")]
    public class TaxonomyL3ServiceController : ApiController
    {
        [Inject]
        public ITaxonomyL3 _TaxonomyL3Service { get; set; }
     
        /// <summary>
        /// Get Customers
        /// </summary>
        /// <param name="request"></param>
        /// <param name="taxonomyL3ViewModel"></param>
        /// <returns></returns>
        [Route("GetTaxonomyL3s")]
        [HttpPost]
        public HttpResponseMessage GetTaxonomyL3s(HttpRequestMessage request, [FromBody] decimal taxonomyL2Id)
        {
            TaxonomyL3ViewModel taxonomyL3ViewModel = new TaxonomyL3ViewModel();
            YTransactionalInformation transaction;

            TaxonomyL3Service taxonomyL3Service = new TaxonomyL3Service(_TaxonomyL3Service);
            List<TaxonomyL3> taxonomyL3s = taxonomyL3Service.GetTaxonomyL3s(taxonomyL2Id, out transaction);
            if (transaction.ReturnStatus == false)
            {
                taxonomyL3ViewModel.ReturnStatus = false;
                taxonomyL3ViewModel.ReturnMessage = transaction.ReturnMessage;
                taxonomyL3ViewModel.ValidationErrors = transaction.ValidationErrors;

                var responseError = Request.CreateResponse<TaxonomyL3ViewModel>(HttpStatusCode.BadRequest, taxonomyL3ViewModel);
                return responseError;

            }

            taxonomyL3ViewModel.TotalPages = transaction.TotalPages;
            taxonomyL3ViewModel.TotalRows = transaction.TotalRows;
            taxonomyL3ViewModel.TaxonomyL3s = taxonomyL3s;
            taxonomyL3ViewModel.ReturnStatus = true;
            taxonomyL3ViewModel.ReturnMessage = transaction.ReturnMessage;

            var response = Request.CreateResponse<TaxonomyL3ViewModel>(HttpStatusCode.OK, taxonomyL3ViewModel);
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

            TaxonomyL3Service taxonomyL3Service = new TaxonomyL3Service(_TaxonomyL3Service);
            taxonomyL3Service.InitializeData(out transaction);
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