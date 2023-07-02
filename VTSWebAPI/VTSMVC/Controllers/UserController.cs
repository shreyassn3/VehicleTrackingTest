using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VTSMVC.Models;
using VTSMVC.Service;

namespace VTSMVC.Controllers
{
    public class UserController : Controller
    {
        UserService objUserService = new UserService();
        public ActionResult UserDetails()
        {
            var result = objUserService.GetUserList();
            return View(result);
        }

        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(UserModel model)
        {
            string physicalPath = model.Photopath == null ? "" : Server.MapPath("~/Images/" + model.Photopath.FileName);
            
            if (physicalPath != null)
            {
                model.Photopath.SaveAs(physicalPath);
            }

            objUserService.SaveUserInfo(model, physicalPath);
            return RedirectToAction("UserDetails");
        }
        public ActionResult Update(int UserID)
        {
            var result = objUserService.GetUserbyID(UserID);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(UserModel model)
        {
            string physicalPath = model.Photopath == null ? "" : Server.MapPath("~/Images/" + model.Photopath.FileName);

            if (physicalPath != null)
            {
                model.Photopath.SaveAs(physicalPath);
            }

            objUserService.UpdateUserInfo(model, physicalPath);
            return RedirectToAction("UserDetails");
        }
        [HttpGet]
        public JsonResult GetUserNameddl()
        {
            VehicleService objVehicleService = new VehicleService();
            List<UserModel> Userddl = new List<UserModel>();
            Userddl = objVehicleService.BindUserName();
            return Json(new { data = Userddl }, JsonRequestBehavior.AllowGet);
        }

    }
}