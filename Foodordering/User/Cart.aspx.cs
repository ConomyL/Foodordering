using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foodordering.User
{
    public partial class Cart : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        decimal grandTotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        void getCartItem()
        {

        }

        protected void rCartItem_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rCartItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}