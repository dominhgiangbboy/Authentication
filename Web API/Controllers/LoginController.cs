using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Web_API.Models;

namespace Web_API.Controllers

{
    public class LoginController : ApiController
    {
        // GET: api/Logins
        [HttpGet]
        public string Get(User UserModel)
        {
            string Status = null;
            string header = "" /*HttpRequestHeader("Authorization")*/ ;
            using (LoginEntities db = new LoginEntities())
                if (header == "Incorrect Username and password") {
                Status = "Chua dang nhap thanh cong";
            }
            else
            {
                    Status = UserModel.Account_name; 
            }
            return Status;
        }


        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        public object Post([FromBody]User UserModel)
        {

            string token = "";
            User Userinfo = new User();
            using (LoginEntities db = new LoginEntities())
            {
                Userinfo = db.Users.Where(x => x.Account_name == UserModel.Account_name
                                             && x.Password == UserModel.Password).SingleOrDefault<User>();
            };
            if (Userinfo == null)
            {

                UserModel.LoginErrorMessage = "Incorrect Username and password ";
                // return View("Index", UserModel);
                token = "Incorrect Username and password";
                //System.Web.HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            }
            else
            {
                //Session["UserAccount"] = UserModel.Account_name;
                token = "successfully logged in";
                System.Web.HttpContext.Current.Response.AppendHeader("Status", "Successfully");
                //System.Web.HttpContext.Current.Response.Redirect("~/Home/Index");
            }
            return token;
        }
    }
}
