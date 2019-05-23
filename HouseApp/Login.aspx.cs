using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using HouseApp.Models;
using System.Data;

namespace HouseApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorMassage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string connect = "Server=localhost;Database=house;Uid=root;Pwd=;IntegratedSecurity=yes;";
            MySqlConnection conn = new MySqlConnection(connect);
            conn.Open();

            string query = "SELECT COUNT(1) from user WHERE user_name=@username and password=@password";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", user_name.Text.Trim());
            cmd.Parameters.AddWithValue("@password", password.Text.Trim());
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if(count == 1)
            {
                Session["username"] = user_name.Text.Trim();
                Response.Redirect("DashBoard.aspx");
            }
            else
            {
                ErrorMassage.Visible = true;
            }
        }
    }
}