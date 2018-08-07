using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_unusedpins : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                bind(Request.QueryString["id"]);
            }
        }
    }
    protected void bind(string reg)
    {
        dt = objsql.GetTable("select *from pins where regno='"+reg+"' and status='n' order by datecreate desc");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewpinstransfer.aspx?pin=" + Request.QueryString["id"]);
    }
}