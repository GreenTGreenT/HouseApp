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

namespace DeviceApp.Controllers
{
    public class DeviceController : ApiController
    {
        /// <summary>  
        /// Insert device to database  
        /// </summary> 
        [HttpPost]
        [Route("api/save/device")]
        public HttpResponseMessage PostDevice(Device device)
        {
            //bool result = false;
            string text = "";
            string errMessage = "";
            try
            {
                var query = string.Format("INSERT INTO device_info(device_name, device_status, h_id) VALUES ('{0}', '{1}', '{2}')",
                    device.device_name, device.device_status, device.h_id); //SQL query language
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
        /// Get all device from database
        /// </summary>
        [HttpGet]  // Define method savedevice to do POST
        [Route("api/get/device")]
        public HttpResponseMessage Getdevice()
        {
            //bool result = false;            
            string errMessage = "";
            ListDevice list_device = new ListDevice();
            string SQL = "SELECT * from device_info";
            DataSet ds = HouseRepository.ReadData(SQL);
            list_device.number = ds.Tables[0].Rows.Count;
            if (ds.Tables[0].Rows.Count > 0)
            {
                //list_device.number = ds.Tables[0].Rows.Count;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Device item = new Device()
                    {
                        device_id = dr["device_id"].ToString(),
                        device_name = dr["device_name"].ToString(),
                        device_status = dr["device_status"].ToString(),
                        h_id = dr["h_id"].ToString(),
                    };

                    list_device.devices.Add(item);
                }
            }
            if (errMessage != "")
                return Request.CreateResponse(HttpStatusCode.InternalServerError, errMessage);
            else
                //Console.WriteLine(HttpStatusCode.OK);
                //return Request.CreateResponse(HttpStatusCode.OK, result); 
                return Request.CreateResponse(HttpStatusCode.OK, list_device);
        }

        /// <summary>  
        /// Delete device from database by device_id 
        /// </summary>
        [HttpPost]
        [Route("api/delete/device")]
        public HttpResponseMessage DeleteDevice(Device device)
        {
            string text = "";
            string errMessage = "";

            try
            {
                string query = string.Format("DELETE from device_info WHERE device_id = '{0}'", device.device_id);
                HouseRepository.ReadData(query);
            }
            //list_device.number = ds.Tables[0].Rows.Count;
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
        /// Edit device in database by choose device_id to change device_name
        /// </summary>
        [HttpPost]
        [Route("api/update/device")]
        public HttpResponseMessage UpdateDevice(Device device)
        {
            string text = "";
            string errMessage = "";


            try
            {
                string query = string.Format("UPDATE device_info set device_name = '{0}', device_status = '{1}', h_id = '{2}' " +
                    "WHERE device_id = '{3}' ", device.device_name, device.device_status, device.h_id, device.device_id);
                //query = query.Replace("@device_id", device.device_id);
                //query = query.Replace("@device_n", device.device_name);  
                HouseRepository.ReadData(query);
            }
            //list_device.number = ds.Tables[0].Rows.Count;
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



        /// <summary>  
        /// Control device
        /// </summary>
        [HttpPost]
        [Route("home/api/control/device/{status}")]
        public HttpResponseMessage ControlDevice(int status, Device device)
        {
            string text = "";
            string errMessage = "";
            //Device device = new Device();

            try
            {
                string query = string.Format("UPDATE device_info set device_status = '{0}' WHERE device_id = '{1}' ", status, device.device_id);
                //query = query.Replace("@device_id", device.device_id);
                //query = query.Replace("@device_n", device.device_name);  
                HouseRepository.ReadData(query);
            }
            //list_device.number = ds.Tables[0].Rows.Count;
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
