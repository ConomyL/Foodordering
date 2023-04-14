using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Foodordering.Admin;
using System.IO;
using System.Security.Cryptography;

namespace Foodordering.User
{
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && Session["userId"] != null)
                {
                    getUserDetails();
                }
                else if (Session["userId"] != null)
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string actionName = string.Empty, imagePath = string.Empty, fileExension = string.Empty;
            bool isValidToExecute = false;
            int UserId = Convert.ToInt32(Request.QueryString["id"]);
            conn = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("User_Crud", conn);
            cmd.Parameters.AddWithValue("@Action", UserId == 0 ? "Insert" : "UPDATE");
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
            if (fuUserImage.HasFile)
            {
                if (Utils.IsValidExtension(fuUserImage.FileName))
                {
                    Guid obj = Guid.NewGuid();
                    fileExension = Path.GetExtension(fuUserImage.FileName);
                    imagePath = "Image/Product/" + obj.ToString() + fileExension;
                    fuUserImage.PostedFile.SaveAs(Server.MapPath("~/Image/User/") + obj.ToString() + fileExension);
                    cmd.Parameters.AddWithValue("@ImageUrl", imagePath);
                    isValidToExecute = true;
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Please select .jpg, .jpeg or .png image";
                    lblMsg.CssClass = "alert alert-danger";
                    isValidToExecute = false;
                }
            }
            else
            {
                isValidToExecute = true;
            }
            if (isValidToExecute)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    actionName = UserId == 0 ?
                        "registration is successful! <b><a href='Login.aspx'>Click here</a></b> to do login" :
                        "details updated successful! <b><a href='Profile.aspx'>Can check here</a></b>";
                    lblMsg.Visible = true;
                    lblMsg.Text = "<b>" + txtUserName.Text.Trim() + "</b>" + actionName;
                    lblMsg.CssClass = "alert alert-sucess";
                    if(UserId != 0)
                    {
                        Response.AddHeader("REFRESH", "1;URL=Profile.aspx");
                    }
                    Clear();
                }

                catch (Exception ex)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Error-" + ex.Message;
                    lblMsg.CssClass = "alert alert-danger";
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        void getUserDetails()
        {
            conn = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("User_crud", conn);
            cmd.Parameters.AddWithValue("@Action", "SELECT4PROFILE");
            cmd.Parameters.AddWithValue("@UserId", Request.QueryString["id"]);
            cmd.CommandType = CommandType.StoredProcedure;
            sda.Fill(dt);
            if(dt.Rows.Count == 1)
            {
                txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                txtMobile.Text = dt.Rows[0]["mobile"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                imgUser.ImageUrl = string.IsNullOrEmpty(dt.Rows[0]["ImageUrl"].ToString()) ? "../Images/No_image.png" : "../" + dt.Rows[0]["ImageUrl"].ToString();
                imgUser.Height = 200;
                imgUser.Width = 200;
                txtPassword.TextMode = TextBoxMode.SingleLine;
                txtPassword.ReadOnly = true;
                txtPassword.Text = dt.Rows[0]["Password"].ToString();
            }
            
            btnRegister.Text = "Update";
            lblAlreadyUser.Text = " ";
        }

        private void Clear()
        {
           

        }
    }
}