using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using VTSMVC.DataAccess;
using VTSMVC.Models;

namespace VTSMVC.Service
{
    public class UserService
    {
        public UserModel SaveUserInfo(UserModel model, string Path)
        {
            try
            {
                using (VTSMVC.DataAccess.VTSEntities entities = new DataAccess.VTSEntities())
                {
                    var objUserMaster = new user_master();
                    var objVehicleDetails = new vehicle_details();

                    objUserMaster.name = model.Name;
                    objUserMaster.address = model.Address;
                    objUserMaster.email_id = model.EmailID;
                    objUserMaster.location = model.Location;
                    objUserMaster.mobile_number = model.MobileNumber;
                    objUserMaster.organization = model.Organization;
                    objUserMaster.photopath = Path;
                    
                    entities.user_master.Add(objUserMaster);
                    entities.SaveChanges();

                    return model;

                }
            }
            catch
            {
                return null;
            }
        }
        public UserModel UpdateUserInfo(UserModel model, string Path)
        {
            try
            {
                using (VTSMVC.DataAccess.VTSEntities entities = new DataAccess.VTSEntities())
                {
                    
                    var _obj = (from row in entities.user_master
                                where row.user_id == model.UserID
                                select row).FirstOrDefault();
                    if (_obj != null)
                    {
                        _obj.name = model.Name;
                        _obj.address = model.Address;
                        _obj.email_id = model.EmailID;
                        _obj.location = model.Location;
                        _obj.mobile_number = model.MobileNumber;
                        _obj.organization = model.Organization;
                        _obj.photopath = Path;

                        entities.Entry(_obj).State = System.Data.Entity.EntityState.Modified;
                        entities.SaveChanges();
                    }
                    else
                    {

                    }
                    return model;

                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public List<UserModel> GetUserList()
        {
            try
            {
                using (VTSMVC.DataAccess.VTSEntities entities = new DataAccess.VTSEntities())
                {
                    var result = (from row in entities.user_master
                                  select new UserModel
                                  {
                                      UserID = row.user_id,
                                      Name = row.name,
                                      MobileNumber = row.mobile_number,
                                      Organization = row.organization,
                                      Address = row.address,
                                      EmailID = row.email_id,
                                      Location = row.location,
                                  }).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public UserModel GetUserbyID(int UserID)
        {
            try
            {
                using (VTSMVC.DataAccess.VTSEntities entities = new DataAccess.VTSEntities())
                {
                    var result = (from row in entities.user_master
                                  where row.user_id == UserID
                                  select new UserModel
                                  {
                                      UserID = row.user_id,
                                      Name = row.name,
                                      MobileNumber = row.mobile_number,
                                      Organization = row.organization,
                                      Address = row.address,
                                      EmailID = row.email_id,
                                      Location = row.location
                                      
                                  }).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}