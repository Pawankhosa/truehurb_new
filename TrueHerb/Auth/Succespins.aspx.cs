using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Succespins : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["pin"] != null || Request.QueryString["user"] != null)
            {
                lblname.Text = Request.QueryString["pin"] + " Pins Send Your Id:" + Request.QueryString["user"] + " Successfully Now";
            }
       }
    }
}