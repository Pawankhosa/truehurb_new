using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_salehistory : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
                bind();
            if(Request.QueryString["Success"]=="true")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Success');", true);
            }
        }
    }
    protected void bind()
    {
        dt = objsql.GetTable("select s.purchaseid,s.date,s.regno,s.qty,s.sellerregno,p.name,p.Dp,p.Pv,u.fname from singleorder s join tblproducts p on p.id=s.item join usersnew u on u.regno=s.regno and s.sellerregno='" + Session["user"] + "' order by s.purchaseid desc");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
    }
  
}