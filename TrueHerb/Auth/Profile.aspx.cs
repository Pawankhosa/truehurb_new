using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Profile : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                bind(Request.QueryString["id"].ToString());
            } 
        }

    }
    protected void bind(string id)
    {
        dt = objsql.GetTable("select * from usersnew where regno='" + id + "'");
        if (dt.Rows.Count > 0)
        {
            DateTime date=Convert.ToDateTime(dt.Rows[0]["joined"]);
            txtdate.Text = date.ToString("dd/MM/yyyy");
            txtaadhar.Text = dt.Rows[0]["aadharcard"].ToString();
            txtadd.Text=dt.Rows[0]["add1"].ToString();
            txtbankname.Text= dt.Rows[0]["bankname"].ToString();
            txtbankno.Text= dt.Rows[0]["account"].ToString();
            txtcity.Text= dt.Rows[0]["city"].ToString();
            txtcountry.Text= dt.Rows[0]["country"].ToString();
            txtifsc.Text= dt.Rows[0]["ifsccode"].ToString();
            txtname.Text= dt.Rows[0]["fname"].ToString();
            txtnominee.Text= dt.Rows[0]["nominame"].ToString();
            txtpan.Text = dt.Rows[0]["pannumber"].ToString();
            txtphn.Text = dt.Rows[0]["mobile"].ToString();
            txtpincode.Text = dt.Rows[0]["pin"].ToString();
            txtstate.Text = dt.Rows[0]["state"].ToString();
            txtrel.Text = dt.Rows[0]["lname"].ToString();
            txtid.Text = dt.Rows[0]["regno"].ToString();
            txtpassword.Text = dt.Rows[0]["pass"].ToString();
            //string[] arr = new string[3];
            //string dob = dt.Rows[0]["dob"].ToString();
            //arr = dob.Split('/');
            //ddlday.Items.FindByText(arr[1]).Selected = true;
            //ddlmonth.Items.FindByValue(arr[0]).Selected = true;
            //ddlyear.Items.FindByValue(arr[2]).Selected = true;

        }

    }

    protected void btnjoin_Click(object sender, EventArgs e)
    {
        objsql.ExecuteNonQuery("update usersnew set fname='" + txtname.Text + "',lname='" + txtrel.Text + "',add1='" + txtadd.Text + "',city='" + txtcity.Text + "',pin='" + txtpincode.Text + "',state='" + txtstate.Text + "',country='" + txtcountry.Text + "',mobile='" + txtphn.Text + "',account='" + txtbankno.Text + "',bankname='" + txtbankname.Text + "',nominame='" + txtnominee.Text + "',nomirel='" + ddlrelation.SelectedItem.Text + "',aadharcard='" + txtaadhar.Text + "',ifsccode='" + txtifsc.Text + "' where regno='" + Request.QueryString["id"] + "'");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
        bind(Request.QueryString["id"]);

    }
}