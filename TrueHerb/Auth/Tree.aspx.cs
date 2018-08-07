using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Tree : System.Web.UI.Page
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
        string check = bind();
        if (check != null)
        {
            Response.Redirect("Checktree.aspx?id=" + txtregid.Text);
        }
        else
        {
            lblname.Text = "No Data Found";
        }
    }

    protected void txtregid_TextChanged(object sender, EventArgs e)
    {
        lblname.Text = bind();

    }
    protected string bind()
    {
        lblname.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtregid.Text + "'"));
        if (lblname.Text == "")
        {
            lblname.Text = "No Data Found";
            btnsubmit.Enabled = false;
        }
        else
        {

            return lblname.Text;
            btnsubmit.Enabled = true;
        }
        return "";
    }
}