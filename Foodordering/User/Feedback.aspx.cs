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
    public partial class Feedback : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Get the values from the input controls
            int contactId = Convert.ToInt32(hdnId.Value);
            string name = txtUserName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string subject = txtSubject.Text.Trim();
            string message = txtFeedback.Text.Trim();


            //Validate the input
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(message))
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please fill all the fields!";
                lblMsg.CssClass = "alert alert-danger";
                return;
            }

            //Save the feedback
            conn = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("Feedback", conn);
            cmd.Parameters.AddWithValue("@Action", contactId == 0 ? "INSERT" : "");
            cmd.Parameters.AddWithValue("@ContactId", contactId);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Subject", subject);
            cmd.Parameters.AddWithValue("@Message", message);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                lblMsg.Visible = true;
                lblMsg.Text = "Feedback saved successfully!";
                lblMsg.CssClass = "alert alert-success";
                getFeedbacks();
                clear();
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
        private void getFeedbacks()
        {
            conn = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("Feedback", conn);
            cmd.Parameters.AddWithValue("@Action", "SELECT");
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);



        }

        private void clear()
        {
            txtUserName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSubject.Text = string.Empty;
            txtFeedback.Text = string.Empty;
            hdnId.Value = "0";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }



    }


}