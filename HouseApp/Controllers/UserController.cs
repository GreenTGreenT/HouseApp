using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseApp.Models;
using HouseApp.Repository;
using MySql.Data.MySqlClient;

namespace userApp.Controllers
{
    public class userController : ApiController
    {
        /// <summary>  
        /// Insert user to database  
        /// </summary> 
        [HttpPost]
        [Route("api/save/user")]
        public HttpResponseMessage Postuser(User user)
        {
            //bool result = false;
            string text = "";
            string errMessage = "";
            try
            {
                var query = string.Format("INSERT INTO user(user_name, id_h) VALUES ('{0}', '{1}')", user.user_name, user.id_h); //SQL query language
                HouseRepository.ReadData(query);

            }
            catch (Exception err)
            {
                errMessage = err.Message;
            }
            if (errMessage != "")
                return Request.CreateResponse(HttpStatusCode.InternalServerError, errMessage);
            else
            {
                text = "Save finish!";
                return Request.CreateResponse(HttpStatusCode.OK, text);
            }
        }

        /// <summary>  
        /// Get all user from database
        /// </summary>
        [HttpGet]  // Define method saveuser to do POST
        [Route("api/get/user")]
        public HttpResponseMessage Getuser()
        {
            //bool result = false;            
            string errMessage = "";
            ListUser list_user = new ListUser();
            string SQL = "SELECT * from user";
            DataSet ds = HouseRepository.ReadData(SQL);
            list_user.number = ds.Tables[0].Rows.Count;
            if (ds.Tables[0].Rows.Count > 0)
            {
                //list_user.number = ds.Tables[0].Rows.Count;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    User item = new User()
                    {
                        user_id = dr["user_id"].ToString(),
                        user_name = dr["user_name"].ToString(),
                        id_h = dr["id_h"].ToString(),
                    };

                    list_user.users.Add(item);
                }
            }
            if (errMessage != "")
                return Request.CreateResponse(HttpStatusCode.InternalServerError, errMessage);
            else
                //Console.WriteLine(HttpStatusCode.OK);
                //return Request.CreateResponse(HttpStatusCode.OK, result); 
                return Request.CreateResponse(HttpStatusCode.OK, list_user);
        }

        /// <summary>  
        /// Delete user from database by user_id 
        /// </summary>
        [HttpPost]
        [Route("api/delete/user")]
        public HttpResponseMessage Deleteuser(User user)
        {
            string text = "";
            string errMessage = "";

            try
            {
                string query = string.Format("DELETE from user WHERE user_id = '{0}'", user.user_id);
                HouseRepository.ReadData(query);
            }
            //list_user.number = ds.Tables[0].Rows.Count;
            catch (Exception err)
            {
                errMessage = err.Message;
            }
            if (errMessage != "")
                return Request.CreateResponse(HttpStatusCode.InternalServerError, errMessage);
            else
            {
                text = "Delete finish";
                return Request.CreateResponse(HttpStatusCode.OK, text);
            }
        }

        /// <summary>  
        /// Edit user in database by choose user_id to change user_name
        /// </summary>
        [HttpPost]
        [Route("api/update/user")]
        public HttpResponseMessage Updateuser(User user)
        {
            string text = "";
            string errMessage = "";


            try
            {
                string query = string.Format("UPDATE user set user_name = '{0}', id_h = '{1}' WHERE user_id = '{2}' ", user.user_name, user.id_h, user.user_id);
                //query = query.Replace("@user_id", user.user_id);
                //query = query.Replace("@user_n", user.user_name);  
                HouseRepository.ReadData(query);
            }
            //list_user.number = ds.Tables[0].Rows.Count;
            catch (Exception err)
            {
                errMessage = err.Message;
            }


            if (errMessage != "")
                return Request.CreateResponse(HttpStatusCode.InternalServerError, errMessage);

            else
            {
                text = "Update finish!";
                return Request.CreateResponse(HttpStatusCode.OK, text);
            }
        }

    }
}
