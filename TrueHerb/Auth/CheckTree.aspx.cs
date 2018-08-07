using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_CheckTree : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public int Cr = 0, Cl = 0, l1, l2, l0;
    public DataTable dt21 = new DataTable();
    public DataTable dt213 = new DataTable();
    public DataTable dt211 = new DataTable();
    public DataTable dt212 = new DataTable();
    public DataTable dt23 = new DataTable();
    public DataTable dt2 = new DataTable();
    string active="";
    protected void Page_Load(object sender, EventArgs e)
    {
        Label17.Visible = false;
        Label18.Visible = false;
        Label19.Visible = false;
        Label20.Visible = false;
        Label21.Visible = false;
        Label22.Visible = false;
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                Tree(Request.QueryString["id"].ToString());
            }

        }

        //  int a = pNodeL("1051", "one");
        //pNodeR(RightNode, "");


    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton1.Text));
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton3.Text));
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton2.Text));
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton4.Text));
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton5.Text));
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton6.Text));
    }
    protected void lnkparent_Click(object sender, EventArgs e)
    {
        if (lnkparent.Text != "ADMIN")
        {
            string sregno = Common.Get(objsql.GetSingleValue("select sregno from usersnew where regno='" + Label8.Text + "'"));
            Tree(Convert.ToString(sregno));
        }
    }
    protected void Tree(string Sr)
    {
        Image3.ImageUrl = "../User/img/user_black.png";
        Image6.ImageUrl = "../User/img/user_black.png";
        Image9.ImageUrl = "../User/img/user_black.png";
        Image12.ImageUrl = "../User/img/user_black.png";
        Image15.ImageUrl = "../User/img/user_black.png";
        Image18.ImageUrl = "../User/img/user_black.png";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        con.Open();
        #region Check Left Active Pair
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select regno from usersnew where sregno=@ID and node='one'";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            if (Convert.ToString(cmd.ExecuteScalar()) != "")
            {
                //{
                //    SqlCommand cmd1 = new SqlCommand();
                //    cmd1.CommandText = "select cnt from cnt_down(@ID)";
                //    string a = Convert.ToString(cmd.ExecuteScalar());
                //    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = a;
                //    cmd1.Connection = con;
                //    Label23.Text = "Left IDs : " + Convert.ToInt64(cmd1.ExecuteScalar());
                //}
                //{
                //    SqlCommand cmd1 = new SqlCommand();
                //    cmd1.CommandText = "select active from cnt_down(@ID)";
                //    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                //    cmd1.Connection = con;
                //    // Label23.Text =Label23.Text + "<br>Active IDs : " + Convert.ToInt64(cmd1.ExecuteScalar());
                //}
                //{
                //    SqlCommand cmd1 = new SqlCommand();
                //    cmd1.CommandText = "select cnt_new from cnt_down1(@ID,'Left','01/01/1900','01/01/2020')";
                //    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Sr);
                //    cmd1.Connection = con;
                //    Label23.Text = Label23.Text + "<br>New IDs : " + Convert.ToInt64(cmd1.ExecuteScalar());
                //}
            }
            else
            {
                Label23.Text = "Left IDs : 0<br>Active IDs : 0<br>New IDs : 0";
            }
        }
        #endregion
        #region parent
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select regno from usersnew where regno=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            Label8.Text = Convert.ToString(cmd.ExecuteScalar());

        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select fname from usersnew where regno=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            Label8.Text = Label8.Text;
            lnkparent.Text = Convert.ToString(cmd.ExecuteScalar());
            DataTable dt2 = new DataTable();
            dt2 = objsql.GetTable("select * from legs where regno='" + Sr + "'");
            if (dt2.Rows.Count > 0)
            {
                lvmain.DataSource = dt2;
                lvmain.DataBind();
                parentnode.ImageUrl = "img/green.gif";
            }
        }
        #endregion
        {
            #region LeftNode
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select regno from usersnew where sregno=@ID and node='one'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                LinkButton1.Text = Convert.ToString(cmd.ExecuteScalar());
                if (LinkButton1.Text != "")
                {
                    active = Common.Get(objsql.GetSingleValue("select active from usersnew where regno='" + LinkButton1.Text + "'"));
                    dt21 = objsql.GetTable("select * from legs where regno='" + LinkButton1.Text + "'");
                    if (dt21.Rows.Count > 0)
                    {
                        leftone.DataSource = dt21;
                        leftone.DataBind();
                    }
                    else
                    {
                        leftone.DataSource = dt21;
                        leftone.DataBind();

                    }
                    leftnode.ImageUrl = "img/green.gif";

                }

                else
                {
                    leftone.DataSource = dt21;
                    leftone.DataBind();
                    leftnode.ImageUrl = "img/red.gif";
                }
                if (active == "False")
                {
                    leftnode.ImageUrl = "img/red.gif";
                }

            }
            #endregion
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select fname from usersnew where sregno=@ID and node='one'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                Label10.Text = Convert.ToString(cmd.ExecuteScalar());
            }
            {
                //SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select spon from usersnew where sregno=@ID and node='one'";
                //cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                //cmd.Connection = con;
                //if (Convert.ToString(cmd.ExecuteScalar()) != "")
                //{
                //    Label17.Visible = true;
                //    Label17.Text = "Proposer ID : " + Convert.ToString(cmd.ExecuteScalar());
                //    SqlCommand cmd1 = new SqlCommand();
                //    cmd1.CommandText = "select name from usersnew where id=@ID";
                //    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                //    cmd1.Connection = con;
                //    Label17.Text = Label17.Text + "(" + Convert.ToString(cmd1.ExecuteScalar()) + ")";
                //}
                //else
                //{
                //    Image3.ImageUrl = "../User/img/tree1.png";
                //}
            }
        }
        {
            #region RightNode
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select regno from usersnew where sregno=@ID and node='two'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                LinkButton4.Text = Convert.ToString(cmd.ExecuteScalar());
                if (LinkButton4.Text != "")
                {
                    active = Common.Get(objsql.GetSingleValue("select active from usersnew where regno='" + LinkButton4.Text + "'"));

                    dt213 = objsql.GetTable("select * from legs where regno='" + LinkButton4.Text + "'");
                    if (dt213.Rows.Count > 0)
                    {
                        lvrightnode.DataSource = dt213;
                        lvrightnode.DataBind();
                    }
                    else
                    {
                        lvrightnode.DataSource = dt213;
                        lvrightnode.DataBind();

                    }
                    rightnode.ImageUrl = "img/green.gif";

                }

                else
                {
                    lvrightnode.DataSource = dt213;
                    lvrightnode.DataBind();
                    rightnode.ImageUrl = "img/red.gif";
                }
                if (active == "False")
                {
                    rightnode.ImageUrl = "img/red.gif";
                }
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select fname from usersnew where sregno=@ID and node='two'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                Label11.Text = Convert.ToString(cmd.ExecuteScalar());
            }
            {
                //SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select spon from usersnew where sregno=@ID and node='two'";
                //cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                //cmd.Connection = con;
                //if (Convert.ToString(cmd.ExecuteScalar()) != "")
                //{
                //    Label18.Visible = true;
                //    Label18.Text = "Proposer ID : " + Convert.ToString(cmd.ExecuteScalar());
                //    SqlCommand cmd1 = new SqlCommand();
                //    cmd1.CommandText = "select name from usersnew where id=@ID";
                //    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                //    cmd1.Connection = con;
                //    Label18.Text = Label18.Text + "(" + Convert.ToString(cmd1.ExecuteScalar()) + ")";
                //}
                //else
                //{
                //    Image6.ImageUrl = "../User/img/tree1.png";
                //}
            }
            #endregion
        }
        {
            #region LeftNode-Left
            {
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select regno from usersnew where sregno in (select regno from usersnew where sregno=@ID and node='one') and node='one'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;

                    LinkButton2.Text = Convert.ToString(cmd.ExecuteScalar());
                    if (LinkButton2.Text != "")
                    {
                        active = Common.Get(objsql.GetSingleValue("select active from usersnew where regno='" + LinkButton2.Text + "'"));
                        dt23 = objsql.GetTable("select * from legs where regno='" + LinkButton2.Text + "'");
                        if (dt23.Rows.Count > 0)
                        {
                            lefttwo.DataSource = dt23;
                            lefttwo.DataBind();
                        }

                        leftnodeleft.ImageUrl = "img/green.gif";

                    }

                    else
                    {
                        lefttwo.DataSource = dt23;
                        lefttwo.DataBind();
                        leftnodeleft.ImageUrl = "img/red.gif";
                    }
                    if (active == "False")
                    {
                        leftnodeleft.ImageUrl = "img/red.gif";
                    }
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select fname from usersnew where sregno in (select regno from usersnew where sregno=@ID and node='one') and node='one'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    Label12.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    //SqlCommand cmd = new SqlCommand();
                    //cmd.CommandText = "select spon from usersnew where sregno in (select id from usersnew where sregno=@ID and node='one') and node='one'";
                    //cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    //cmd.Connection = con;
                    //if (Convert.ToString(cmd.ExecuteScalar()) != "")
                    //{
                    //    Label19.Visible = true;
                    //    Label19.Text = "Proposer ID : " + Convert.ToString(cmd.ExecuteScalar());
                    //    SqlCommand cmd1 = new SqlCommand();
                    //    cmd1.CommandText = "select name from usersnew where id=@ID";
                    //    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                    //    cmd1.Connection = con;
                    //    Label19.Text = Label19.Text + "(" + Convert.ToString(cmd1.ExecuteScalar()) + ")";
                    //}
                    //else
                    //{
                    //    Image9.ImageUrl = "../User/img/tree1.png";
                    //}
                }
            }
            #endregion
            #region LeftNode-Right
            {
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select regno from usersnew where sregno in (select regno from usersnew where sregno=@ID and node='one') and node='two'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    LinkButton3.Text = Convert.ToString(cmd.ExecuteScalar());
                    if (LinkButton3.Text != "")
                    {
                        Label13.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + LinkButton3.Text + "'"));
                    }
                    else
                    {
                        Label13.Text = "";
                    }
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select fname from usersnew where regno in (select sregno from usersnew where sregno=@ID and node='one') and node='two'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;


                    if (LinkButton3.Text != "")
                    {
                        Label13.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + LinkButton3.Text + "'"));
                        active = Common.Get(objsql.GetSingleValue("select active from usersnew where regno='" + LinkButton3.Text + "'"));

                        leftnoderight.ImageUrl = "img/green.gif";
                        dt2 = objsql.GetTable("select * from legs where regno='" + LinkButton3.Text + "'");
                        if (dt2.Rows.Count > 0)
                        {
                            leftthree.DataSource = dt2;
                            leftthree.DataBind();

                        }
                        else
                        {
                            dt2.Clear();
                        }
                        if (active == "False")
                        {
                            leftnodeleft.ImageUrl = "img/red.gif";
                        }
                    }
                    else
                    {
                        Label13.Text = "";
                        leftnoderight.ImageUrl = "img/red.gif";
                        leftthree.DataSource = dt2;
                        leftthree.DataBind();
                    }
                }
                {
                    //SqlCommand cmd = new SqlCommand();
                    //cmd.CommandText = "select spon from usersnew where sregno in (select id from usersnew where sregno=@ID and node='one') and node='two'";
                    //cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    //cmd.Connection = con;
                    //if (Convert.ToString(cmd.ExecuteScalar()) != "")
                    //{
                    //    Label20.Visible = true;
                    //    Label20.Text = "Proposer ID : " + Convert.ToString(cmd.ExecuteScalar());
                    //    SqlCommand cmd1 = new SqlCommand();
                    //    cmd1.CommandText = "select name from usersnew where id=@ID";
                    //    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                    //    cmd1.Connection = con;
                    //    Label20.Text = Label20.Text + "(" + Convert.ToString(cmd1.ExecuteScalar()) + ")";
                    //}
                    //else
                    //{
                    //    Image12.ImageUrl = "../User/img/tree1.png";
                    //}
                }
            }
            #endregion
        }
        {
            #region RightNode-Left
            {
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select regno from usersnew where sregno in (select regno from usersnew where sregno=@ID and node='two') and node='one'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    LinkButton5.Text = Convert.ToString(cmd.ExecuteScalar());


                    if (LinkButton5.Text != "")
                    {
                        active = Common.Get(objsql.GetSingleValue("select active from usersnew where regno='" + LinkButton5.Text + "'"));

                        dt212 = objsql.GetTable("select * from legs where regno='" + LinkButton5.Text + "'");
                        if (dt212.Rows.Count > 0)
                        {
                            lvrightleft.DataSource = dt212;
                            lvrightleft.DataBind();
                        }
                        else
                        {
                            lvrightleft.DataSource = dt212;
                            lvrightleft.DataBind();

                        }
                        rightleft.ImageUrl = "img/green.gif";

                    }

                    else
                    {
                        lvrightleft.DataSource = dt212;
                        lvrightleft.DataBind();
                        rightleft.ImageUrl = "img/red.gif";
                    }
                    if (active == "False")
                    {
                        leftnodeleft.ImageUrl = "img/red.gif";
                    }
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select fname from usersnew where sregno in (select regno from usersnew where sregno=@ID and node='two') and node='one'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    Label14.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    //SqlCommand cmd = new SqlCommand();
                    //cmd.CommandText = "select spon from usersnew where sregno in (select id from usersnew where sregno=@ID and node='two') and node='one'";
                    //cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    //cmd.Connection = con;
                    //if (Convert.ToString(cmd.ExecuteScalar()) != "")
                    //{
                    //    Label21.Visible = true;
                    //    Label21.Text = "Proposer ID : " + Convert.ToString(cmd.ExecuteScalar());
                    //    SqlCommand cmd1 = new SqlCommand();
                    //    cmd1.CommandText = "select name from usersnew where id=@ID";
                    //    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                    //    cmd1.Connection = con;
                    //    Label21.Text = Label21.Text + "(" + Convert.ToString(cmd1.ExecuteScalar()) + ")";
                    //}
                    //else
                    //{
                    //    Image15.ImageUrl = "../User/img/tree1.png";
                    //}
                }
            }
            #endregion
            #region RightNode-Right
            {
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select regno from usersnew where sregno in (select regno from usersnew where sregno=@ID and node='two') and node='two'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;

                    LinkButton6.Text = Convert.ToString(cmd.ExecuteScalar());
                    if (LinkButton6.Text != "")
                    {
                        active = Common.Get(objsql.GetSingleValue("select active from usersnew where regno='" + LinkButton6.Text + "'"));


                        dt211 = objsql.GetTable("select * from legs where regno='" + LinkButton6.Text + "'");
                        if (dt211.Rows.Count > 0)
                        {
                            lvrightright.DataSource = dt211;
                            lvrightright.DataBind();
                        }
                        else
                        {
                            lvrightright.DataSource = dt211;
                            lvrightright.DataBind();

                        }
                        rightright.ImageUrl = "img/green.gif";

                    }

                    else
                    {
                        lvrightright.DataSource = dt211;
                        lvrightright.DataBind();
                        rightright.ImageUrl = "img/red.gif";
                    }
                    if (active == "False")
                    {
                        leftnodeleft.ImageUrl = "img/red.gif";
                    }
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select fname from usersnew where sregno in (select regno from usersnew where sregno=@ID and node='two') and node='two'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    Label15.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    //SqlCommand cmd = new SqlCommand();
                    //cmd.CommandText = "select spon from usersnew where sregno in (select id from usersnew where sregno=@ID and node='two') and node='two'";
                    //cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    //cmd.Connection = con;
                    //if (Convert.ToString(cmd.ExecuteScalar()) != "")
                    //{
                    //    Label22.Visible = true;
                    //    Label22.Text = "Proposer ID : " + Convert.ToString(cmd.ExecuteScalar());
                    //    SqlCommand cmd1 = new SqlCommand();
                    //    cmd1.CommandText = "select name from usersnew where id=@ID";
                    //    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                    //    cmd1.Connection = con;
                    //    Label22.Text = Label22.Text + "(" + Convert.ToString(cmd1.ExecuteScalar()) + ")";
                    //}
                    //else
                    //{
                    //    Image18.ImageUrl = "../User/img/tree1.png";
                    //}
                }
            }
            #endregion
        }
        Image3.ImageUrl = "../User/img/user_black.png";
        Image6.ImageUrl = "../User/img/user_black.png";
        Image9.ImageUrl = "../User/img/user_black.png";
        Image12.ImageUrl = "../User/img/user_black.png";
        Image15.ImageUrl = "../User/img/user_black.png";
        Image18.ImageUrl = "../User/img/user_black.png";
        con.Dispose();
    }


    /// <summary>
    /// To Count right node
    /// </summary>
    /// <param name="node"></param>
    /// <param name="place"></param>
    private void pNodeR(string node, string place)
    {
        string sql = "select * from usersnew where regno='" + node + "'";

        DataTable dt = new DataTable();
        dt = objsql.GetTable(sql);

        if (dt.Rows.Count == 1)
        {
            Cr = Cr + 1;
        }
        else if (dt.Rows.Count > 0)
        {
            Cr = Cr + 2;
            pNodeR(dt.Select("node='one'")[0].ItemArray[0].ToString(), "one");
            pNodeR(dt.Select("node='two'")[0].ItemArray[0].ToString(), "two");
        }
    }

    /// <summary>
    /// To Count left node
    /// </summary>
    /// <param name="node"></param>
    /// <param name="place"></param>
    //private void pNodeL(string node, string place)
    //{
    //    string sql = "select * from usersnew where regno='" + node + "'";

    //    DataTable dt = new DataTable();
    //    dt = objsql.GetTable(sql);

    //    if (dt.Rows.Count == 1)
    //    {
    //        Cl = Cl + 1;
    //    }
    //    else if (dt.Rows.Count > 1)
    //    {
    //        Cl = Cl + 2;
    //        pNodeL(dt.Select("node='one'")[0].ItemArray[0].ToString(), "one");
    //        pNodeL(dt.Select("node='two'")[0].ItemArray[0].ToString(), "two");
    //    }
    //}


    /* SelectData Method & Connection string */


    //public System.Data.DataTable SelectData(string sql)
    //{
    //    try
    //    {
    //        SqlDataAdapter da = new SqlDataAdapter(sql, con);
    //        DataTable dt = new DataTable();
    //        da.Fill(dt);
    //        return dt;
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //}
    private int pNodeL(string node, string place)
    {
        string sql = "select * from usersnew where sregno='" + node + "' and node='" + place + "'";


        DataTable dt = new DataTable();
        dt = objsql.GetTable(sql);

        if (dt.Rows.Count == 1)
        {

            Cl = Cl + 1;
            pNodeLL(dt.Rows[0]["regno"].ToString(), "");

        }
        else if (dt.Rows.Count > 1)
        {

            Cl = Cl + 2;

            pNodeLL(dt.Select("node='one'")[0].ItemArray[0].ToString(), "one");
            pNodeLL(dt.Select("node='two'")[0].ItemArray[0].ToString(), "two");

        }
        if (dt.Rows.Count == 0)
        {

        }
        return Cl;
    }
    // Calculate after 1 count left
    private int pNodeLL(string node, string place)
    {
        string sql = "select * from usersnew where sregno='" + node + "' ";
        DataTable dt = new DataTable();
        dt = objsql.GetTable(sql);

        if (dt.Rows.Count == 1)
        {

            Cl = Cl + 1;

            pNodeLL(dt.Rows[0]["regno"].ToString(), "");
        }
        else if (dt.Rows.Count > 1 || dt.Rows.Count < 0)
        {

            Cl = Cl + 2;
            pNodeLL(dt.Select("node='one'")[0].ItemArray[0].ToString(), "one");

            pNodeLL(dt.Select("node='two'")[0].ItemArray[0].ToString(), "two");
            //  ActiveL(node);


        }
        if (dt.Rows.Count == 0)
        {

        }
        return Cl;

    }

    protected void btnseacrh_Click(object sender, EventArgs e)
    {
        Response.Redirect("Checktree.aspx?id=" + txtreg.Text);
    }
}