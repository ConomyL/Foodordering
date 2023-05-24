using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foodordering.Admin;

namespace Foodordering.User
{
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getCategories();
                getProducts();
                getFeedbacks();
            }
        }

        private void getCategories()
        {
            conn = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("Category_Crud", conn);
            cmd.Parameters.AddWithValue("@Action", "ACTIVECAT");
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            rCategory.DataSource = dt;
            rCategory.DataBind();
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
        private void getProducts()
        {
            conn = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("Product_Crud", conn);
            cmd.Parameters.AddWithValue("@Action", "ACTIVEPROD");
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            rProduct.DataSource = dt;
            rProduct.DataBind();
        }
        protected void rProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (Session["userId"] != null)
            {
                bool isCarItemUpdated = false;
                int i = isItemExistInCart(Convert.ToInt32(e.CommandArgument));
                if (i == 0)
                {
                    //Adding new item in cart
                    conn = new SqlConnection(Connection.GetConnectionString());
                    cmd = new SqlCommand("Cart_Crud", conn);
                    cmd.Parameters.AddWithValue("@Action", "INSERT");
                    cmd.Parameters.AddWithValue("@ProductId", e.CommandArgument);
                    cmd.Parameters.AddWithValue("@Quantity", 1);
                    cmd.Parameters.AddWithValue("@UserId", Session["userId"]);
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Error - " + ex.Message + " ');<script>");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    //Adding existing item into cart
                    Utils utils = new Utils();
                    isCarItemUpdated = utils.updateCartQuantity(i + 1, Convert.ToInt32(e.CommandArgument), Convert.ToInt32(Session["userId"]));
                }
                lblMsg.Visible = true;
                lblMsg.Text = "Item added successfully in your cart!";
                lblMsg.CssClass = "alert alert-success";
                Response.AddHeader("REFRESH", "1;URL=Cart.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        int isItemExistInCart(int productId)
        {
            conn = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("Cart_Crud", conn);
            cmd.Parameters.AddWithValue("@Action", "GETBYID");
            cmd.Parameters.AddWithValue("@ProductId", productId);
            cmd.Parameters.AddWithValue("@UserId", Session["userId"]);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            int quantity = 0;
            if (dt.Rows.Count > 0)
            {
                quantity = Convert.ToInt32(dt.Rows[0]["Quantity"]);
            }
            return quantity;

        }

        /*public string LowerCase(object obj)
        {
            return obj.ToString().ToLower();
        }*/


    }
}