using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_UsedpinDate : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["pin"] != null || Request.QueryString["date"] != null)
            {
                bind();
            }
        }
    }
    protected void bind()
    {
        dt = objsql.GetTable("select u.fname,u.regno,u.joined from pins p,usersnew u where p.regno='"+Request.QueryString["pin"]+"' and p.dated='"+ Request.QueryString["date"] + "' and subregno is NOT NULL and p.subregno=u.regno");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
    }
}