using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginFormProject.Models;
using System.Net;

namespace LoginFormProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            
            return View();
        }
        //[HttpPost]
        //public string Post(LoginFormProject.Models.IDpassword UserModel)
        //{
        //   string token = "";
        //    using (LoginEntities db = new LoginEntities())
        //    {
        //        var Userinfo = db.IDpasswords.Where(x => x.Account_name == UserModel.Account_name && x.password == UserModel.password).FirstOrDefault();
        //        if (Userinfo == null)
        //        {
        //            UserModel.LoginErrorMessage = "Incorrect Username and password ";
        //           // return View("Index", UserModel);
        //           token = "Incorrect Username and password";
        //           Response.AppendHeader("Status", "Unsuccessfully");
                  
        //        }
                
        //        else
        //        {
        //            Session["UserAccount"] = UserModel.Account_name;
        //            token = "successfully logged in";
        //            Response.AppendHeader("Status", "Successfully");
        //            // Response.Redirect("~/Home/Index");
        //        }
        //        return token;
        //    }

        //}
      

        public ActionResult LogOut ()
        {
            
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}