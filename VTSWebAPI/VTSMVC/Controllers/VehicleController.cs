using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using VTSMVC.Models;
using VTSMVC.Service;

namespace VTSMVC.Controllers
{
    public class VehicleController : ApiController
    {
        VehicleService objVehicleService = new VehicleService();

        [HttpGet()]
        public IHttpActionResult Get()
        {
            IHttpActionResult ret = null;
            List<VehicleModel> list = new List<VehicleModel>();

            var result = objVehicleService.GetVehicleList();
            list = result;
            if (list.Count > 0)
            {
                ret = Ok(result);
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }

        [HttpGet()]
        public IHttpActionResult GetDetails(string Id)
        {
            IHttpActionResult ret = null;
            //List<VehicleModel> list = new List<VehicleModel>();

            var result = objVehicleService.GetVehicleListbyId(Id);
            //list = result;
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

        [HttpPost()]
        public IHttpActionResult Post(VehicleModel Model)
        {
            objVehicleService.AddMoreDetails(Model);
            return Ok(Model);
        }
       
        [HttpPut()]
        public IHttpActionResult Put(string id, VehicleModel Model)
        {
            objVehicleService.UpdateVehicleInfo(id, Model);
            return Ok(Model);
        }

    }
}
