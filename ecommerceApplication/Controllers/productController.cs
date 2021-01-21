using Microsoft.AspNetCore.Mvc;
using ecommerceApplication.DAL.Context;
using ecommerceApplication.DAL.TableModels;
using ecommerceApplication.Model;
using ecommerceApplication.Model.CategoryModel;
using ecommerceApplication.Model.SubCategoryModel;
using ecommerceApplication.Model.subsubCategoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;


namespace ecommerceApplication.Controllers
{
    [Route("productDetails")]
    [ApiController]
    public class productController : Controller
    {

        private readonly homecontext _dbcontext;
        public productController(homecontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("getproductcategory")]

        public ReturnModel Getproductmodels()
        {
            ReturnModel retModel = new ReturnModel();
            var data = _dbcontext.category.Where(x => x.IsActive == true).ToList();
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
        [Route("postproductcategory")]

        public ReturnModel productcategorymodels(addCategorymodel details)
        {
            ReturnModel retModel = new ReturnModel();
            try
            {
                var isExist = _dbcontext.category.FirstOrDefault(x => x.categoryName.ToLower().Equals(details.categoryName.ToLower()));
                if (isExist != null)
                {
                    retModel.message = "category Already Exists";
                    retModel.statusCode = HttpStatusCode.BadRequest;
                }
                else
                {
                    category categoryproduct = new category
                    {

                        categoryName = details.categoryName,
                        registercompanyId = details.registercompanyId,
                        IsActive = true,
                        IsDeleted = false,
                        IsUpdated = false,
                        CreateDateTime = DateTime.UtcNow,
                        DeletedDateTime = null,
                        UpdatedDateTime = null
                    };
                    _dbcontext.category.Add(categoryproduct);
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

        [Route("putcategorydetails")]
            [HttpPut]
            public ReturnModel updatecategory(updateCategorymodel updatecategory)
            {
                ReturnModel retModel = new ReturnModel();
                var Data = _dbcontext.category.FirstOrDefault(x => x.categoryName.ToLower().Equals(updatecategory.categoryName.ToLower()));
                if (Data != null)
                {
                    Data.categoryName = updatecategory.categoryName;
                    Data.registercompanyId = updatecategory.registercompanyId;
                    Data.IsUpdated = true;
                    Data.UpdatedDateTime = DateTime.UtcNow;
                    _dbcontext.category.Update(Data);
                    var Isupdated = _dbcontext.SaveChanges();
                    if (Isupdated == 1)
                    {
                        category productcategory = new category
                        {
                            categoryName = updatecategory.categoryName,
                            registercompanyId = updatecategory.registercompanyId


                        };
                        retModel.message = "Successfully update product";
                        retModel.statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        retModel.message = "can't update product";
                        retModel.statusCode = HttpStatusCode.OK;
                    }
                }
                return retModel;
            }

        [Route("deletedproductcategory")]
        [HttpDelete]
        public ReturnModel Deleteproduct(int category_Id)
        {
            ReturnModel retModel = new ReturnModel();
            var Data = _dbcontext.category.FirstOrDefault(E => E.categoryId == category_Id);
            if (Data != null)
            {
                Data.IsActive = false;
                Data.IsDeleted = true;
                Data.DeletedDateTime = DateTime.UtcNow;
                _dbcontext.category.Update(Data);
                var IsDeleted = _dbcontext.SaveChanges();
                if (IsDeleted == 1)
                {
                    retModel.message = "Delete product succesfull";
                    retModel.statusCode = HttpStatusCode.OK;
                }
                else
                {
                    retModel.message = "can't Delete product";
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
        [Route("getsubcategory")]

        public ReturnModel Getsubproductmodels()
        {
            ReturnModel retModel = new ReturnModel();
            var data = _dbcontext.subCategory.Where(x => x.IsActive == true).ToList();
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
        [Route("postsubcategory")]

        public ReturnModel subcategorymodels(addSubcategorymodelcs details)
        {
            ReturnModel retModel = new ReturnModel();
            try
            {
                var isExist = _dbcontext.subCategory.FirstOrDefault(x => x.subcategoryName.ToLower().Equals(details.subcategoryName.ToLower()));
                if (isExist != null)
                {
                    retModel.message = "subCategory Already Exists";
                    retModel.statusCode = HttpStatusCode.BadRequest;
                }
                else
                {
                    subCategory subcategoryproduct = new subCategory
                    {

                        subcategoryName = details.subcategoryName,
                        categoryId = details.categoryId,
                        IsActive = true,
                        IsDeleted = false,
                        IsUpdated = false,
                        CreateDateTime = DateTime.UtcNow,
                        DeletedDateTime = null,
                        UpdatedDateTime = null
                    };
                    _dbcontext.subCategory.Add(subcategoryproduct);
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


        [Route("putsubcategory")]
        [HttpPut]
        public ReturnModel updatesubcategory(updateSubcategorymodel updatesubcategory)
        {
            ReturnModel retModel = new ReturnModel();
            var Data = _dbcontext.subCategory.FirstOrDefault(x => x.subcategoryName.ToLower().Equals(updatesubcategory.subcategoryName.ToLower()));
            if (Data != null)
            {
                Data.subcategoryName = updatesubcategory.subcategoryName;
                Data.categoryId = updatesubcategory.categoryId;
                Data.IsUpdated = true;
                Data.UpdatedDateTime = DateTime.UtcNow;
                _dbcontext.subCategory.Update(Data);
                var Isupdated = _dbcontext.SaveChanges();
                if (Isupdated == 1)
                {
                    subCategory subproductcategory = new subCategory
                    {
                        subcategoryName = updatesubcategory.subcategoryName,
                        categoryId = updatesubcategory.categoryId
                    };
                    retModel.message = "Successfully update product";
                    retModel.statusCode = HttpStatusCode.OK;
                }
                else
                {
                    retModel.message = "can't update product";
                    retModel.statusCode = HttpStatusCode.OK;
                }
            }
            return retModel;
        }

        



        [Route("deletedsubcategory")]
        [HttpDelete]
        public ReturnModel subproductdelete(int subcategory_Id)
        {
            ReturnModel retModel = new ReturnModel();
            var Data = _dbcontext.subCategory.FirstOrDefault(E => E.subcategoryId == subcategory_Id);
            if (Data != null)
            {
                Data.IsActive = false;
                Data.IsDeleted = true;
                Data.DeletedDateTime = DateTime.UtcNow;
                _dbcontext.subCategory.Update(Data);
                var IsDeleted = _dbcontext.SaveChanges();
                if (IsDeleted == 1)
                {
                    retModel.message = "Delete subproduct succesfull";
                    retModel.statusCode = HttpStatusCode.OK;
                }
                else
                {
                    retModel.message = "can't subDelete product";
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
        [Route("getsubsubcategory")]

        public ReturnModel Getsubsubproductmodels()
        {
            ReturnModel retModel = new ReturnModel();
            var data = _dbcontext.subsubCategory.Where(x => x.IsActive == true).ToList();
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
        [Route("postsubsubcategory")]

        public ReturnModel subsubcategorymodels(postsubsubCategorymodel details)
        {
            ReturnModel retModel = new ReturnModel();
            try
            {
                var isExist = _dbcontext.subsubCategory.FirstOrDefault(x => x.subsubcategoryName.ToLower().Equals(details.subsubcategoryName.ToLower()));
                if (isExist != null)
                {
                    retModel.message = "subCategory Already Exists";
                    retModel.statusCode = HttpStatusCode.BadRequest;
                }
                else
                {
                    subsubCategory subsubcategoryproduct = new subsubCategory
                    {

                        subsubcategoryName = details.subsubcategoryName,
                        subcategoryId = details.subcategoryId,
                        showsubcategory = true,
                        IsActive = true,
                        IsDeleted = false,
                        IsUpdated = false,
                        CreateDateTime = DateTime.UtcNow,
                        DeletedDateTime = null,
                        UpdatedDateTime = null
                    };
                    _dbcontext.subsubCategory.Add(subsubcategoryproduct);
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
        [Route("putsubsubcategory")]
        [HttpPut]
        public ReturnModel updatesubsubcategory(updatesubsubCategorymodel updatesubsubcategory)
        {
            ReturnModel retModel = new ReturnModel();
            var Data = _dbcontext.subsubCategory.FirstOrDefault(x => x.subsubcategoryName.ToLower().Equals(updatesubsubcategory.subsubcategoryName.ToLower()));
            if (Data != null)
            {
                Data.subsubcategoryName = updatesubsubcategory.subsubcategoryName;
                Data.subcategoryId = updatesubsubcategory.subcategoryId;
                Data.showsubcategory = true;
                Data.IsUpdated = true;
                Data.UpdatedDateTime = DateTime.UtcNow;
                _dbcontext.subsubCategory.Update(Data);
                var Isupdated = _dbcontext.SaveChanges();
                if (Isupdated == 1)
                {
                    subsubCategory subsubproductcategory = new subsubCategory
                    {
                        subsubcategoryName = updatesubsubcategory.subsubcategoryName,
                        subcategoryId = updatesubsubcategory.subcategoryId
                    };
                    retModel.message = "Successfully update product";
                    retModel.statusCode = HttpStatusCode.OK;
                }
                else
                {
                    retModel.message = "can't update product";
                    retModel.statusCode = HttpStatusCode.OK;
                }
            }
            return retModel;
        }

        [Route("deletedsubsubcategory")]
        [HttpDelete]
        public ReturnModel subsubproductdelete(int subsubcategory_Id)
        {
            ReturnModel retModel = new ReturnModel();
            var Data = _dbcontext.subsubCategory.FirstOrDefault(E => E.subsubcategoryId == subsubcategory_Id);
            if (Data != null)
            {

                Data.IsActive = false;
                Data.IsDeleted = true;
                Data.DeletedDateTime = DateTime.UtcNow;
                _dbcontext.subsubCategory.Update(Data);
                var IsDeleted = _dbcontext.SaveChanges();
                if (IsDeleted == 1)
                {
                    retModel.message = "Delete subsubproduct succesfull";
                    retModel.statusCode = HttpStatusCode.OK;
                }
                else
                {
                    retModel.message = "can't subsubDelete product";
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

