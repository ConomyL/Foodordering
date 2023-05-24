using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Foodordering.User
{
    public abstract class InvoiceBase : System.Web.UI.Page
    {
        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataAdapter sda;
        protected DataTable dt;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            conn = new SqlConnection(Connection.GetConnectionString());
        }

        protected virtual void AuthenticateUser()
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected abstract DataTable GetDetails();
    }

    public partial class Invoice : InvoiceBase
    {
        protected override void AuthenticateUser()
        {
            base.AuthenticateUser();
        }

        protected override DataTable GetDetails()
        {
            double grandTotal = 0;
            conn = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("Invoice_Re", conn);
            cmd.Parameters.AddWithValue("@Action", "GETINVOICE");
            cmd.Parameters.AddWithValue("@PaymentId", Convert.ToInt32(Request.QueryString["id"]));
            cmd.Parameters.AddWithValue("@UserId", Session["userId"]);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (dt.Columns.Contains("TotalPrice"))
                {
                    foreach (DataRow drow in dt.Rows)
                    {
                        grandTotal += Convert.ToDouble(drow["TotalPrice"]);
                    }
                }
            }
            DataRow dr = dt.NewRow();
            dr["TotalPrice"] = grandTotal;
            dt.Rows.Add(dr);
            return dt;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AuthenticateUser();
                if (Request.QueryString["id"] != null)
                {
                    rOrderItem.DataSource = GetDetails();
                    rOrderItem.DataBind();
                }
            }
        }
    }
}
