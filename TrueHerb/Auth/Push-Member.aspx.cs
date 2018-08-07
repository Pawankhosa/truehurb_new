using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Push_Member : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    protected void bind()
    {
        dt = objsql.GetTable("select * from usersnew where active='1531'");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
    }

    protected void lnkedit_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        Response.Redirect("order.aspx?regno=" + id);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
       
    }
}