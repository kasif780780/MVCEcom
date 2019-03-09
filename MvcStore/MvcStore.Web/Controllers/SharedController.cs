﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStore.Web.Controllers
{
    public class SharedController : Controller
    {
        // GET: Image

        public JsonResult UploadImage()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            try
            {
                var file = Request.Files[0];
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
                file.SaveAs(path);
                result.Data = new { Success = true, ImageURL = string.Format("/Content/images/{0}",fileName)  };

                //var newImage = new Image() { Name = fileName };

                //if(ImageService.Instance.SaveNewImage(newImage))
                //{
                //    result.Data = new { Success = true, Image = fileName, File = newImage.ID, imageURL = string.Format("{0}{1}", Variables.ImageFolderPath, fileName) };
                //}
            }
            catch(Exception ex)
            {
                result.Data = new { success = false, Message = ex.Message };
            }
            return result;
        }


    }
}
