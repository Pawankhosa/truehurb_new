using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_User : System.Web.UI.MasterPage
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            else
            {
                string name = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + Session["user"].ToString() + "'"));
                lblname.Text = "Welcome To " + name;
                lnklogout.Visible = true;
                lnklogin.Visible = false;
                chkstock();
                chksale();
            }

        }
    }

    protected void lnklogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/login.aspx");

    }

    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/login.aspx");
    }
    public void chkstock()
    {
            DataTable dt = new DataTable();
            dt = objsql.GetTable("select * from tblAssignstock where regno='" + Session["user"] + "'");
            if(dt.Rows.Count>0)
            {
                pnlstock.Visible = true;
            }
            
    }
    public void chksale()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from singleorder where sellerregno='" + Session["user"] + "'");
        if (dt.Rows.Count > 0)
        {
            pnlstock.Visible = true;
        }

    }

}
