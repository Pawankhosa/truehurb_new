using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_UsedPins : System.Web.UI.Page
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
        dt = objsql.GetTable("select count(*) as total, u.regno,u.fname from pins p ,usersnew u where p.regno = u.regno and p.status='y' group by u.regno,u.fname");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        Response.Redirect("usedpindetails.aspx?id=" + id);
    }
}