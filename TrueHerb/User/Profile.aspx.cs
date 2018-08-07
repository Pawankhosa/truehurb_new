using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Profile : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }

    }
    protected void bind()
    {
        dt = objsql.GetTable("select * from usersnew where regno='" + Session["user"] + "'");
        if(dt.Rows.Count>0)
        {

            lblspon.Text = dt.Rows[0]["spillsregno"].ToString();
            lblads.Text = dt.Rows[0]["add1"].ToString();
            lblbank.Text = dt.Rows[0]["bankname"].ToString();
            lblbankac.Text = dt.Rows[0]["account"].ToString();  
            lblcity.Text = dt.Rows[0]["city"].ToString();
            lblcountry.Text = dt.Rows[0]["country"].ToString();
            lblemail.Text = dt.Rows[0]["email"].ToString();
            lblfather.Text = dt.Rows[0]["lname"].ToString();
            lblmon.Text = dt.Rows[0]["mobile"].ToString();
            lblname.Text = dt.Rows[0]["fname"].ToString();
            lblnomads.Text = dt.Rows[0]["nomiadd"].ToString();
            lblnomiee.Text = dt.Rows[0]["nominame"].ToString();
            lblnomieephone.Text = dt.Rows[0]["nomiph"].ToString();
            lblpan.Text = dt.Rows[0]["pannumber"].ToString();
            lblphone.Text = dt.Rows[0]["phone1"].ToString();
            lblphpone2.Text = dt.Rows[0]["phone2"].ToString();
            lblpin.Text = dt.Rows[0]["updatepin"].ToString();
            lblreg.Text = dt.Rows[0]["regno"].ToString();
            lblrelation.Text = dt.Rows[0]["relation"].ToString();
            lblstate.Text = dt.Rows[0]["state"].ToString();
           





        }
    }
}