using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using HouseApp.Models;
using HouseApp.Repository;
using MySql.Data.MySqlClient;


namespace HouseApp.Controllers
{
    public class HouseController : ApiController
    {
        /// <summary>  
        /// Insert house, device and user to database  
        /// </summary> 
        [HttpPost]
        [Route("api/saveall")]
        public HttpResponseMessage PostAll(AllData allData)
        {
            string text = "";
            string errMessage = "";
            try
            {             
                var maxHId = string.Format("SELECT MAX(house_id) as hId FROM house");
                int hid = HouseRepository.GetId(maxHId) + 1;

                var maxDId = string.Format("SELECT MAX(device_id) as dId FROM device_info");
                int did = HouseRepository.GetId(maxDId) + 1;

                var maxUId = string.Format("SELECT MAX(user_id) as uId FROM user");
                int uid = HouseRepository.GetId(maxUId) + 1;

                var query1 = string.Format("INSERT INTO house(house_id,house_name) VALUES ('{0}', '{1}')", hid, allData.house_name); //SQL query language
                HouseRepository.ReadData(query1);

                var query2 = string.Format("INSERT INTO device_info(device_id, device_name, device_status, h_id) " +
                             "VALUES ('{0}', '{1}', '{2}', '{3}')",did, allData.device_name, allData.device_status, hid); //SQL query language
                HouseRepository.ReadData(query2);

                var query3 = string.Format("INSERT INTO user(user_id, user_name, id_h) VALUES ('{0}', '{1}', '{2}')", uid, allData.user_name, hid); //SQL query language
                HouseRepository.ReadData(query3);

                var query4 = string.Format("INSERT INTO control(d_id, u_id) VALUES ('{0}', '{1}')", did, uid); //SQL query language
                HouseRepository.ReadData(query4);

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
        /// Insert house to database  
        /// </summary> 
        [HttpPost]
        [Route("api/save/house")]
        public HttpResponseMessage PostHouse(House house)
        {
            //bool result = false;
            string text = "";
            string errMessage = "";
            try
            {
                var query = string.Format("INSERT INTO house(house_name) VALUES ('{0}')", house.house_name); //SQL query language
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
        /// Get all house from database
        /// </summary>
        [Authorize]
        [HttpGet]  // Define method savehouse to do POST
        [Route("api/get/house")]
        public HttpResponseMessage Gethouse()
        {
            //bool result = false;            
            string errMessage = "";
            ListHouse list_house = new ListHouse();
            string SQL = "SELECT * from house";
            DataSet ds = HouseRepository.ReadData(SQL);
            list_house.number = ds.Tables[0].Rows.Count;
            if (ds.Tables[0].Rows.Count > 0)
            {
                //list_house.number = ds.Tables[0].Rows.Count;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    House item = new House()
                    {
                        house_id = dr["house_id"].ToString(),
                        house_name = dr["house_name"].ToString(),
                    };

                    list_house.houses.Add(item);
                }
            }
            if (errMessage != "")
                return Request.CreateResponse(HttpStatusCode.InternalServerError, errMessage);
            else
                //Console.WriteLine(HttpStatusCode.OK);
                //return Request.CreateResponse(HttpStatusCode.OK, result); 
                return Request.CreateResponse(HttpStatusCode.OK, list_house);
        }


        /// <summary>  
        /// Delete house from database by house_id 
        /// </summary>
        [HttpPost]
        [Route("api/delete/house")]
        public HttpResponseMessage Deletehouse(House house)
        {
            string text = "";
            string errMessage = "";

            try
            {
                string query = string.Format("DELETE from house WHERE house_id = '{0}'", house.house_id);
                HouseRepository.ReadData(query);
            }
            //list_house.number = ds.Tables[0].Rows.Count;
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
        /// Edit house in database by choose house_id to change house_name
        /// </summary>
        [HttpPost]
        [Route("api/update/house")]
        public HttpResponseMessage Updatehouse(House house)
        {
            string text = "";
            string errMessage = "";


            try
            {
                string query = string.Format("UPDATE house set house_name = '{0}' WHERE house_id = '{1}' ", house.house_name, house.house_id);
                //query = query.Replace("@house_id", house.house_id);
                //query = query.Replace("@house_n", house.house_name);  
                HouseRepository.ReadData(query);
            }
            //list_house.number = ds.Tables[0].Rows.Count;
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
