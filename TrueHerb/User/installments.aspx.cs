using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_installments : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    public string user;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] != null)
            {
                user = Session["user"].ToString();
            }
            else
            {
                user = Request.QueryString["id"].ToString();
            }
            bind(user);
            count(user);
        }
    }
    protected void bind(string id)
    {
        dt = objsql.GetTable("select * from installments where regno='" + id + "'");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
    }
    protected void count(string id)
    {
        lblpaid.Text = Common.Get(objsql.GetSingleValue("select count(*) from installments where regno = '" + id + "'"));
        lblpending.Text = (Convert.ToInt32(lbltotal.Text) - Convert.ToInt32(lblpaid.Text)).ToString();
       
    }
}