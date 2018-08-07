using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Expiredpins : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

            bind();
        }
    }
    protected void bind()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select p.pin,p.subregno,u.lname,u.joined from pins p , usersnew u where p.regno='"+Session["user"]+"' and p.status='y' and p.subregno=u.regno order by p.dated desc");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
    }
}