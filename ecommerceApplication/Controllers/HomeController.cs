using Microsoft.AspNetCore.Mvc;
using ecommerceApplication.DAL.Context;
using ecommerceApplication.DAL.TableModels;
using ecommerceApplication.Model;
using ecommerceApplication.Model.admin;
using ecommerceApplication.Model.seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace ecommerceApplication.Controllers
{

    [Route("applicationdetails")]
    [ApiController]
    public class HomeController : Controller
    {

        private readonly homecontext _dbcontext;    
        public HomeController(homecontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        /// <summary>
        /// This API is for get super ADMIN details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("superAdmindetailsget")]

        public ReturnModel GetSuperAdminmodels()
        {
            ReturnModel retModel = new ReturnModel();
            var data = _dbcontext.superAdmin.Where(x => x.IsActive == true).ToList();
            if (data.Count > 0)
            {
                retModel.message = "Successfully data sent";
                retModel.statusCode = HttpStatusCode.OK;
                retModel.responce = data;
            }
            else
            {
                retModel.message = "No data found";
                retModel.statusCode = HttpStatusCode.NotFound;
            }
            return retModel;
        }



        [HttpPost]
        [Route("superAdmindetailspost")]

        public ReturnModel superAdminmodels(addAdminmodel details)
        {
            ReturnModel retModel = new ReturnModel();
            try
            {
                var isExist = _dbcontext.superAdmin.FirstOrDefault(x => x.superAdminemail.ToLower().Equals(details.superAdminemail.ToLower()));
                if (isExist != null)
                {
                    retModel.message = "Super Admin Already Exists";
                    retModel.statusCode = HttpStatusCode.BadRequest;
                }
                else
                {
                    superAdmin superadmin = new superAdmin
                    {
                        superAdminId=details.superAdminId,
                        superAdminemail = details.superAdminemail,
                        superAdminname = details.superAdminname,
                        superAdminusername = details.superAdminusername,
                        superAdminPassword = details.superAdminPassword,
                        IsActive = true,
                        IsDeleted = false,
                        IsUpdated = false,
                        CreateDateTime = DateTime.UtcNow,
                        DeletedDateTime = null,
                        UpdatedDateTime = null
                    };
                    _dbcontext.superAdmin.Add(superadmin);
                    var isSaved = _dbcontext.SaveChanges();
                    if (isSaved > 0)
                    {
                        retModel.message = "Successfully Added New Super Admin";
                        retModel.statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        retModel.message = "Can't add due to technical error";
                        retModel.statusCode = HttpStatusCode.InternalServerError;
                    }
                }

            }
            catch (Exception ex)
            {
                retModel.message = ex.Message.ToString();
                retModel.statusCode = HttpStatusCode.InternalServerError;
            }
            return retModel;
        }

        [Route("superAdmindetailsput")]
        [HttpPut]
        public ReturnModel UpdateadminDetails(addAdminmodel updateAdmin)
        {
            ReturnModel retModel = new ReturnModel();
            var Data = _dbcontext.superAdmin.FirstOrDefault(x => x.superAdminemail.ToLower().Equals(updateAdmin.superAdminemail.ToLower()));
            if (Data != null)
            {
                
                Data.superAdminemail = updateAdmin.superAdminemail;
                Data.superAdminname = updateAdmin.superAdminname;
                Data.superAdminusername = updateAdmin.superAdminusername;
                Data.superAdminPassword = updateAdmin.superAdminPassword;
                Data.IsUpdated = true;
                Data.UpdatedDateTime = DateTime.UtcNow;
                _dbcontext.superAdmin.Update(Data);
                var Isupdated = _dbcontext.SaveChanges();
                if (Isupdated == 1)
                {
                    superAdmin superadmin = new superAdmin
                    {
                        superAdminemail = updateAdmin.superAdminemail,
                        superAdminname = updateAdmin.superAdminname,
                        superAdminusername = updateAdmin.superAdminusername,
                        superAdminPassword = updateAdmin.superAdminPassword,

                    };
                    retModel.message = "Successfully update Super Admin";
                    retModel.statusCode = HttpStatusCode.OK;
                }
                else
                {
                    retModel.message = "can't update Super Admin";
                    retModel.statusCode = HttpStatusCode.OK;
                }
            }
            return retModel;
        }
        [Route("superAdminDetailsdeleted")]
        [HttpDelete]
        public ReturnModel DeleteAdminDetails(int superadmin_ID)
        {
            ReturnModel retModel = new ReturnModel();
            var Data = _dbcontext.superAdmin.FirstOrDefault(E => E.superAdminId == superadmin_ID);
            if (Data != null)
            {
                Data.IsActive = false;
                Data.IsDeleted = true;
                Data.DeletedDateTime = DateTime.UtcNow;
                _dbcontext.superAdmin.Update(Data);
                var IsDeleted = _dbcontext.SaveChanges();
                if (IsDeleted == 1)
                {
                    retModel.message = "Delete Super Admin";
                    retModel.statusCode = HttpStatusCode.OK;
                }
                else
                {
                    retModel.message = "can't Delete Super Admin";
                    retModel.statusCode = HttpStatusCode.OK;
                }
            }
            else
            {
                retModel.statusCode = HttpStatusCode.NotFound;
                retModel.message = "Data not found";
            }
            return retModel;
        }

        [HttpGet]
        [Route("companyRegisterdetailsget")]

        public ReturnModel getregisterdetails()
        {
            ReturnModel retmodel = new ReturnModel();
            var data = _dbcontext.companyRegister.Where(x => x.IsActive == true).ToList();
            if (data.Count > 0)
            {
                retmodel.message = "Successfully data sent";
                retmodel.statusCode = HttpStatusCode.OK;
                retmodel.responce = data;
            }
            else
            {
                retmodel.message = "No data found";
                retmodel.statusCode = HttpStatusCode.NotFound;
            }
            return retmodel;

        }

        [HttpPost]
        [Route("companyRegisterdetailspost")]

        public ReturnModel companyRegisterpost(addSellermodel details)
        {
            ReturnModel retmodel = new ReturnModel();
            try
            {
                var Data = _dbcontext.companyRegister.FirstOrDefault(x => x.registercompanyEmail.ToLower().Equals(details.registercompanyEmail.ToLower()));
                if (Data != null)
                {
                    retmodel.message = "Super Admin Already Exists";
                    retmodel.statusCode = HttpStatusCode.BadRequest;
                }
                else
                {

                    companyRegister registercompany = new companyRegister
                    {

                        registercompnyName = details.registercompnyName,
                        registercompanyEmail = details.registercompanyEmail,
                        registercompanyMNo = details.registercompanyMNo,
                        registerOwnername = details.registerOwnername,
                        registercompanyTitle = details.registercompanyTitle,
                        registercompanyAddress = details.registercompanyAddress,
                        IsActive = true,
                        IsDeleted = false,
                        IsUpdated = false,
                        CreateDateTime = DateTime.UtcNow,
                        DeletedDateTime = null,
                        UpdatedDateTime = null
                    };
                    _dbcontext.companyRegister.Add(registercompany);
                    var isSaved = _dbcontext.SaveChanges();
                    if (isSaved > 0)
                    {
                        retmodel.message = "Successfully Added New commpany Admin";
                        retmodel.statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        retmodel.message = "Can't add due to technical error";
                        retmodel.statusCode = HttpStatusCode.InternalServerError;
                    }
                }
            }
            catch (Exception ex)
            {
                retmodel.message = ex.Message.ToString();
                retmodel.statusCode = HttpStatusCode.InternalServerError;
            }
            return retmodel;
        }
        [Route("companyRegisterdetailsput")]
        [HttpPut]
        public ReturnModel updatecompanyRegisterdetails(updateSellermodel updatecompany)
        {
            ReturnModel retModel = new ReturnModel();
            var Data = _dbcontext.companyRegister.FirstOrDefault(x => x.registercompanyEmail.ToLower().Equals(updatecompany.registercompanyEmail.ToLower()));
            if (Data != null)
            {
                Data.registercompnyName = updatecompany.registercompnyName;
                Data.registercompanyEmail = updatecompany.registercompanyEmail;
                Data.registercompanyMNo = updatecompany.registercompanyMNo;
                Data.registerOwnername = updatecompany.registerOwnername;
                Data.registercompanyTitle = updatecompany.registercompanyTitle;
                Data.registercompanyAddress = updatecompany.registercompanyAddress;

                Data.IsUpdated = true;
                Data.UpdatedDateTime = DateTime.UtcNow;
                _dbcontext.companyRegister.Update(Data);
                var Isupdated = _dbcontext.SaveChanges();
                if (Isupdated == 1)
                {
                    companyRegister registercompany = new companyRegister
                    {
                        registercompnyName = updatecompany.registercompnyName,
                        registercompanyEmail = updatecompany.registercompanyEmail,
                        registercompanyMNo = updatecompany.registercompanyMNo,
                        registerOwnername = updatecompany.registerOwnername,
                        registercompanyTitle = updatecompany.registercompanyTitle,
                        registercompanyAddress = updatecompany.registercompanyAddress


                    };
                    retModel.message = "Successfully update Super Admin";
                    retModel.statusCode = HttpStatusCode.OK;
                }
                else
                {
                    retModel.message = "can't update Super Admin";
                    retModel.statusCode = HttpStatusCode.OK;
                }
            }
            return retModel;
        }
        [Route("companyRegisterdetailsdelete")]
        [HttpDelete]
        public ReturnModel DeletecompanyDetails(int companyregister_ID)
        {
            ReturnModel retModel = new ReturnModel();
            var Data = _dbcontext.companyRegister.FirstOrDefault(E => E.registercompanyId == companyregister_ID);
            if (Data != null)
            {
                Data.IsActive = false;
                Data.IsDeleted = true;
                Data.DeletedDateTime = DateTime.UtcNow;
                _dbcontext.companyRegister.Update(Data);
                var IsDeleted = _dbcontext.SaveChanges();
                if (IsDeleted == 1)
                {
                    retModel.message = "Delete register company";
                    retModel.statusCode = HttpStatusCode.OK;
                }
                else
                {
                    retModel.message = "can't Delete register company";
                    retModel.statusCode = HttpStatusCode.OK;
                }
            }
            else
            {
                retModel.statusCode = HttpStatusCode.NotFound;
                retModel.message = "Data not found";
            }
            return retModel;
        }
    }
}
