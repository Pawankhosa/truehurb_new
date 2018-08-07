using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Change_Password : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        dt = objsql.GetTable("select * from usersnew where regno='" + Session["user"].ToString() + "' and pass='" + txtold.Text + "'");
        if (dt.Rows.Count > 0)
        {
            objsql.ExecuteNonQuery("update usersnew set pass='" + txtnew.Text + "' where regno='" + Session["user"] + "'");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password Changed Sucessfully ')", true);
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry ! Wrong Password')", true);
        }
    }
}