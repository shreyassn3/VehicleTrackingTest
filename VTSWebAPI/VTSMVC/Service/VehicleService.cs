using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VTSMVC.DataAccess;
using VTSMVC.Models;

namespace VTSMVC.Service
{
    public class VehicleService
    {
        public List<VehicleModel> GetVehicleList()
        {
            try
            {
                using (VTSMVC.DataAccess.VTSEntities entities = new DataAccess.VTSEntities())
                {
                    var result = (from row in entities.vehicle_details
                                  select new VehicleModel
                                  {
                                    ChasisNumber = row.chasis_number,
                                    EngineNumber = row.engine_number,
                                    VehicleNumber = row.vehicle_number,
                                    VehicleType = row.vehicle_type,
                                    Organization = row.organization,
                                    LoadCarryingCapacity = row.load_carrying_capacity,
                                    ManufacturingYear = row.manufacturing_year,
                                    MakeofVehicle = row.make_of_vehicle,
                                    ModelNumber = row.model_number,
                                    BodyType = row.body_type
                                  }).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public VehicleModel GetVehicleListbyId(string VehicleNumber)
        {
            try
            {
                using (VTSMVC.DataAccess.VTSEntities entities = new DataAccess.VTSEntities())
                {
                    var result = (from row in entities.vehicle_details
                                  where row.vehicle_number == VehicleNumber
                                  select new VehicleModel
                                  {
                                      UserID = row.id,
                                      ChasisNumber = row.chasis_number,
                                      EngineNumber = row.engine_number,
                                      VehicleNumber = row.vehicle_number,
                                      VehicleType = row.vehicle_type,
                                      Organization = row.organization,
                                      LoadCarryingCapacity = row.load_carrying_capacity,
                                      ManufacturingYear = row.manufacturing_year,
                                      MakeofVehicle = row.make_of_vehicle,
                                      ModelNumber = row.model_number,
                                      BodyType = row.body_type,
                                  }).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<VehicleModel> GetVehicleDetailsForSearch(string Search)
        {
            try
            {
                using (VTSMVC.DataAccess.VTSEntities entities = new DataAccess.VTSEntities())
                {
                    var result = (from row in entities.GetVehicleDetails(Search)
                                  
                                  select new VehicleModel
                                  {
                                      ChasisNumber = row.chasis_number,
                                      EngineNumber = row.engine_number,
                                      VehicleNumber = row.vehicle_number,
                                      VehicleType = row.vehicle_type,
                                      Organization = row.organization,
                                      LoadCarryingCapacity = row.load_carrying_capacity,
                                      ManufacturingYear = row.manufacturing_year,
                                      MakeofVehicle = row.make_of_vehicle,
                                      ModelNumber = row.model_number,
                                      BodyType = row.body_type
                                  }).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void AddMoreDetails(VehicleModel model)
        {
            try
            {
                using (VTSMVC.DataAccess.VTSEntities entities = new DataAccess.VTSEntities())
                {

                    var objVehicleDetails = new vehicle_details();

                    objVehicleDetails.vehicle_number = model.VehicleNumber;
                    objVehicleDetails.id = Convert.ToInt32(model.Name);
                    objVehicleDetails.body_type = model.BodyType;
                    objVehicleDetails.chasis_number = model.ChasisNumber;
                    objVehicleDetails.engine_number = model.EngineNumber;
                    objVehicleDetails.load_carrying_capacity = model.LoadCarryingCapacity;
                    objVehicleDetails.make_of_vehicle = model.MakeofVehicle;
                    objVehicleDetails.manufacturing_year = model.ManufacturingYear;
                    objVehicleDetails.model_number = model.ModelNumber;
                    objVehicleDetails.organization = model.Organization;
                    objVehicleDetails.vehicle_type = model.VehicleType;

                    entities.vehicle_details.Add(objVehicleDetails);
                    entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public VehicleModel UpdateVehicleInfo(string vehiclenumber , VehicleModel model)
        {
            try
            {
                using (VTSMVC.DataAccess.VTSEntities entities = new DataAccess.VTSEntities())
                {
                    var _obj = (from row in entities.vehicle_details
                                where row.vehicle_number == vehiclenumber
                                select row).FirstOrDefault();
                    if (_obj != null) //---insert
                    {

                        _obj.body_type = model.BodyType;
                        _obj.chasis_number = model.ChasisNumber;
                        _obj.engine_number = model.EngineNumber;
                        _obj.load_carrying_capacity = model.LoadCarryingCapacity;
                        _obj.make_of_vehicle = model.MakeofVehicle;
                        _obj.manufacturing_year = model.ManufacturingYear;
                        _obj.model_number = model.ModelNumber;
                        _obj.organization = model.Organization;
                        _obj.vehicle_type = model.VehicleType;

                        entities.Entry(_obj).State = System.Data.Entity.EntityState.Modified;
                        entities.SaveChanges();
                    }
                    else
                    {

                    }
                    return model;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<UserModel> BindUserName()
        {
            try
            {
                using (VTSMVC.DataAccess.VTSEntities entities = new DataAccess.VTSEntities())
                {
                    var result = (from row in entities.user_master
                                  orderby row.user_id ascending
                                  select new UserModel
                                  {
                                      UserID = row.user_id,
                                      Name = row.name
                                  }).ToList();
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