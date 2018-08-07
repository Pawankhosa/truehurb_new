using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_AvailablePins : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
            lbltotal.Text = Common.Get(objsql.GetSingleValue("select count(*) from pins where regno='" + Session["user"] + "' and status='n'"));
        }
    }
    protected void bind()
    {
        dt = objsql.GetTable("select * from pins where regno='" + Session["user"] + "' and status='n'");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
    }

    protected void lnkjoin_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        Response.Redirect("join_us.aspx?pin=" + id+"&sponser="+Session["user"]);
    }
}