using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
public partial class Auth_Order : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable MyDT = new DataTable();
    DataRow MyRow;
    private static TimeZoneInfo INDIAN_ZONE;
    public static string date = "";
    string constring = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    int id = 0,total=0;
   public static string invoice = "";
    public DateTime indianTime = new DateTime();
    Common cm = new Common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            date = indianTime.ToString("yyyy-MM-dd");
            Session["DataTable"] = "";
            drop();
             invoice = cm.Generatepass();

        }
    }
    protected void drop()
    {
        objsql.BindDropDownList("select * from tblrewarddetails", "pair", "id", ddllevel);
    }


    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        //if (Session["DataTable"] != null)
        //{
          

        //}
        if (Session["DataTable"] == "")
        {

            MyDT.Columns.Add("id", System.Type.GetType("System.Int32"));

            MyDT.Columns.Add("Name");

            MyDT.Columns.Add("Quantity");
            MyDT.Columns.Add("Price");
            MyDT.Columns.Add("Total");
            MyDT.Columns.Add("pid");
            MyDT.Columns.Add();
         
            MyRow = MyDT.NewRow();

            MyRow[0] = MyDT.Rows.Count + 1;

            MyRow[1] = txtname.Text;

            MyRow[2] = txtqty.Text;
            MyRow[3] = Common.Get(objsql.GetSingleValue("select dp from tblproducts where name='" + txtname.Text + "'"));
            MyRow[4] =(Convert.ToInt32(MyRow[3]) * Convert.ToInt32(MyRow[2]));
            MyRow[5] = Common.Get(objsql.GetSingleValue("select id from tblproducts where name='" + txtname.Text + "'"));
            MyDT.Rows.Add(MyRow);


            Session["DataTable"] = MyDT;


        }
        else
        {
            MyDT = (DataTable)Session["DataTable"];
            MyRow = MyDT.NewRow();

            MyRow[0] = MyDT.Rows.Count + 1;

            MyRow[1] = txtname.Text;

            MyRow[2] = txtqty.Text;
            MyRow[3] = Common.Get(objsql.GetSingleValue("select dp from tblproducts where name='" + txtname.Text + "'"));
            MyRow[4] = (Convert.ToInt32(MyRow[3]) * Convert.ToInt32(MyRow[2]));
            MyRow[5] = Common.Get(objsql.GetSingleValue("select id from tblproducts where name='" + txtname.Text + "'"));
            MyDT.Rows.Add(MyRow);


            Session["DataTable"] = MyDT;
        }
        

        GridView1.DataSource = MyDT ;
        GridView1.DataBind();
        btnsubmit.Visible = true;
        bindtotal();
        Button1.Visible = true;
        txtname.Text = "";
        txtqty.Text = "";

    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchCustomers(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["con"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select name from tblproducts where " +
                "name like @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", prefixText);
                cmd.Connection = conn;
                conn.Open();
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["name"].ToString());
                    }
                }
                conn.Close();
                return customers;
            }
        }
    }
    protected void bindtotal()
    {
        foreach (GridViewRow gr in GridView1.Rows)
        {
            Label tot = (Label)gr.FindControl("total");
            total += Convert.ToInt32(tot.Text);
            lbltotal.Text = total.ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            //string checklevel = Common.Get(objsql.GetSingleValue("select id from tblmasterorder where regno='" + txtregno.Text + "' and pinlevel='" + ddllevel.SelectedItem.Value + "'"));
            //if (checklevel == "")
            //{
                objsql.ExecuteNonQuery("insert into tblmasterorder(purchaseid,regno,amount,status,date,pinlevel) values('" + invoice + "','" + txtregno.Text + "','" + lbltotal.Text + "','1','" + date + "','" + ddllevel.SelectedItem.Value + "')");
                foreach (GridViewRow gr in GridView1.Rows)
                {
                    HiddenField item = (HiddenField)gr.FindControl("hfid");
                    HiddenField qty = (HiddenField)gr.FindControl("qty");
                    objsql.ExecuteNonQuery("insert into singleorder(purchaseid,date,regno,item,qty) values('" + invoice + "','" + date + "','" + txtregno.Text + "','" + item.Value + "','" + qty.Value + "')");
                }
                int total = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select sum(amount) from tblmasterorder where regno='" + txtregno.Text + "' and pinlevel='" + ddllevel.SelectedItem.Value + "'")));
                //if(total>=750)
                //{
                    //string status = Common.Get(objsql.GetSingleValue("select active from usersnew where regno='" + txtregno.Text + "'"));
                    //if (status == "False")
                    //{
                        //objsql.ExecuteNonQuery("update usersnew set active='1' where regno='" + txtregno.Text + "'");
                      //  objsql.ExecuteNonQuery("insert into tblrewardincome (regno,rewardname,rewardincome) values ('" + Request.QueryString["regno"] + "','" + ddllevel.SelectedItem.Value + "','0')");

                        //using (SqlConnection con = new SqlConnection(constring))
                        //{

                        //    using (SqlCommand cmd = new SqlCommand("EveryNode", con))
                        //    {
                        //        string node = Common.Get(objsql.GetSingleValue("select node from usersnew where regno='" + txtregno.Text + "'"));
                        //        string lastnode = Common.Get(objsql.GetSingleValue("select sregno from usersnew where regno='" + txtregno.Text + "'"));
                        //        cmd.CommandType = CommandType.StoredProcedure;
                        //        cmd.Parameters.AddWithValue("@id", lastnode);           // sponser id
                        //        cmd.Parameters.AddWithValue("@node", node);                            // node
                        //        cmd.Parameters.AddWithValue("@checkid", lastnode);
                        //        cmd.Parameters.Add("@printvalue", SqlDbType.VarChar, 30);
                        //        cmd.Parameters["@printvalue"].Direction = ParameterDirection.Output;
                        //        con.Open();
                        //        cmd.ExecuteNonQuery();
                        //        con.Close();
                        //        string a = cmd.Parameters["@printvalue"].Value.ToString();

                        //    }

                        //}
                    //}
                //}
                
                   
               
                
                ts.Complete();
                ts.Dispose();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Thank For Shopping')", true);
                Response.Redirect("managesale.aspx");
            //}
            //else
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry User Achieved This Level')", true);
            //}
        }

    }
}