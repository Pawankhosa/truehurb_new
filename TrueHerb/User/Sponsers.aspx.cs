using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Sponsers : System.Web.UI.Page
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
        dt = objsql.GetTable("select * from usersnew where spillsregno='"+Session["user"]+"' and node='one'");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
        dt = objsql.GetTable("select * from usersnew where spillsregno='" + Session["user"] + "' and node='two'");
        if (dt.Rows.Count > 0)
        {
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }
    }

    protected void lnkleft_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        Response.Redirect("installments.aspx?id=" + id);
    }

    protected void lnkright_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        Response.Redirect("installments.aspx?id=" + id);
    }
}