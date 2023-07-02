using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VTSMVC.Service;

namespace VTSMVC.Controllers
{
    public class SearchController : ApiController
    {
        VehicleService objVehicleService = new VehicleService();

        [HttpGet()]
        public IHttpActionResult GetDetails(string id)
        {
            IHttpActionResult ret = null;

            var result = objVehicleService.GetVehicleDetailsForSearch(id);
            if (result != null)
            {
                ret = Ok(result);
            }
            else
            {
                ret = NotFound();
            }
            return ret;
        }

    }
}
