using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Auth_ViewAssignedstock : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    public void BindGrid()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select assign.regno,assign.code,assign.stock,assign.date,users.fname,pp.Name from tblAssignstock assign Join usersnew users ON users.regno=assign.regno Inner Join tblproducts pp ON pp.code=assign.code");
        if(dt.Rows.Count>0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
    }
}