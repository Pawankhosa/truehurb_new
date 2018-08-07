using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_duepinshistory : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            bind();
        }

    }
    protected void bind()
    {
        lbltotal.Text = Common.Get(objsql.GetSingleValue("select count(*) from duepins where regno='" + Session["user"] + "'"));
        lblpending.Text = Common.Get(objsql.GetSingleValue("select count(*) from duepins where regno='" + Session["user"] + "' and status='y'"));
        lblbal.Text = (Convert.ToInt32(lbltotal.Text) - Convert.ToInt32(lblpending.Text)).ToString();
        dt = objsql.GetTable("select * from duepins where regno='" + Session["user"] + "' and status='y'");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
    }

}