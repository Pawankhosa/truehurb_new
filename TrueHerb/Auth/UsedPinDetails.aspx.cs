using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_UsedPinDetails : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                bind(Request.QueryString["id"]);
            }
            
        }
    }
    protected void bind(string reg)
    {
        dt = objsql.GetTable("select count(*) as total,dated,pintype from pins where regno='"+reg+"' and subregno is NOT NULL group by dated,pintype order by dated desc");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
    }



    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        Response.Redirect("usedpindate.aspx?date=" + id + "&pin=" + Request.QueryString["id"]);
    }
}