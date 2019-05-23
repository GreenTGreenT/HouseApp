using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseApp.Models
{
    public class House
    {
        [Required]
        public string house_id { get; set; }
        [Required]
        public string house_name { get; set; }
    }
    public class ListHouse
    {
        public int number { get; set; }
        public List<House> houses = new List<House>();

    }
    public class User
    {
        [Required]
        public string user_id { get; set; }
        [Required]
        public string user_name { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string id_h { get; set; }
    }
    public class ListUser
    {
        public int number { get; set; }
        public List<User> users = new List<User>();

    }
    public class Device
    {
        [Required]
        public string device_id { get; set; }
        [Required]
        public string device_name { get; set; }
        [Required]
        public string device_status { get; set; }
        [Required]
        public string h_id { get; set; }
    }
    public class ListDevice
    {
        public int number { get; set; }
        public List<Device> devices = new List<Device>();

    }
    public class Control
    {
        [Required]
        public string d_id { get; set; }
        [Required]
        public string u_id { get; set; }
    }

    public class AllData
    {
        //public string house_id { get; set; }
        //public string device_id { get; set; }
        //public string user_id { get; set; }
        //public string id_h { get; set; }
        [Required]
        public string house_name { get; set; }
        [Required]
        public string device_name { get; set; }
        [Required]
        public string device_status { get; set; }
        [Required]
        public string user_name { get; set; }

    }

}
       