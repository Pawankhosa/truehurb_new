using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Default : System.Web.UI.Page
{ SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null)
        {
            Response.Redirect("login.aspx");
        }
        lblincome.Text = rewardincome();
    }
    protected string rewardincome()
    {
        string income= Common.Get(objsql.GetSingleValue("select sum(amount) from tblmasterorder where date='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'"));
        return income;
    }
}