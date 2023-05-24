using Foodordering.Admin;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foodordering.User
{
    public class LoginPart
    {
        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataAdapter sda;
        protected DataTable dt;

        public LoginPart()
        {
            conn = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
        }

        protected void AddParameter(string parameterName, object value)
        {
            cmd.Parameters.AddWithValue(parameterName, value);
        }

        protected void ExecuteQuery(string storedProcedureName)
        {
            cmd.CommandText = storedProcedureName;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
        }

        public virtual DataTable Select(string storedProcedureName, string userName, string password)
        {
            AddParameter("@Action", "SELECT4LOGIN");
            AddParameter("@UserName", userName);
            AddParameter("@Password", password);
            ExecuteQuery(storedProcedureName);
            return dt;
        }
    }

    public class UserLogin : LoginPart
    {
        public override DataTable Select(string storedProcedureName, string userName, string password)
        {
            AddParameter("@Action", "SELECT4LOGIN");
            AddParameter("@UserName", userName);
            AddParameter("@Password", password);
            ExecuteQuery(storedProcedureName);
            return dt;
        }

        public void Update(string storedProcedureName, int userId, string userName, string password)
        {
            AddParameter("@Action", "UPDATE");
            AddParameter("@UserId", userId);
            AddParameter("@UserName", userName);
            AddParameter("@Password", password);
            cmd.CommandText = storedProcedureName;

            cmd.ExecuteNonQuery();
        }

        
    }

    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "Admin" && txtPassword.Text.Trim() == "123")
            {
                Session["admin"] = txtUserName.Text.Trim();
                Response.Redirect("../Admin/Dashboard.aspx");
            }
            else
            {
                UserLogin userLogin = new UserLogin();
                DataTable dt = userLogin.Select("User_Crud", txtUserName.Text.Trim(), txtPassword.Text.Trim());
                if (dt.Rows.Count == 1)
                {
                    Session["Username"] = txtUserName.Text.Trim();
                    Session["userId"] = dt.Rows[0]["UserId"];
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Invalid Credentials..!";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
        }
    }

}