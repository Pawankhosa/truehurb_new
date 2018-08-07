using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_viewpinstransfer : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["pin"] != null)
            {
                bind(Request.QueryString["pin"].ToString());
            }
        }
    }
    protected void bind(string reg)
    {
        dt = objsql.GetTable("select count(*) as pin,p.dated, p.oldregno,u.fname from pintransfers p , usersnew u where p.newregno='" + reg + "' and p.oldregno=u.regno group by p.oldregno,p.dated,u.fname order by p.dated desc ");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
        dt = objsql.GetTable("select count(*) as pin,p.dated, p.newregno,u.fname from pintransfers p , usersnew u where p.oldregno='" + reg+ "' and p.newregno=u.regno group by p.newregno,p.dated,u.fname order by p.dated desc");
        if (dt.Rows.Count > 0)
        {
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }
    }
}