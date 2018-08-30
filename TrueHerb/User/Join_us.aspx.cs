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
using System.Net;
using System.IO;

public partial class User_Join_us : System.Web.UI.Page
{
    public static string pin = "", sponser = "", pintype = "", newregno = "", pass = "", lastdata;
    SQLHelper objsql = new SQLHelper();
    string constring = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    public static Boolean proposalstatus = false;
    public static int lefdirect = 0, rightdirect = 0, left = 0, right = 0, cappingleft = 0, cappingright = 0;
    int checkcapping = 0;
    public static string date = "";
    public static TimeZoneInfo INDIAN_ZONE;
    public DateTime indianTime = new DateTime();
    Common cm = new Common();
    protected void Page_Load(object sender, EventArgs e)
    {
        INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
        date = indianTime.ToString("yyyy-MM-dd");
        if (!IsPostBack)
        {
            if (Request.QueryString["pin"] != null || Request.QueryString["sponser"] != null)
            {
               

                txtpin.Text = Request.QueryString["pin"].ToString();
                //sponser = Request.QueryString["sponser"].ToString();
                //txtsponserid.Text = sponser;
                //lblsponsername.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + sponser + "'"));
                lblleafnode.Text = lastnode(sponser);
                //pintype = Common.Get(objsql.GetSingleValue("select pintype from pins where pin='" + pin + "'"));
                lastdata = lastnode(sponser);
            }
        }
    }

    #region Check Valid Upline
    protected void txtproposerid_TextChanged(object sender, EventArgs e)
    {

        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("VAL_DOWNLINE", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PID", txtproposerid.Text.Trim());         // proposer id
                cmd.Parameters.AddWithValue("@ID", txtsponserid.Text.Trim());                             // sponser id
                cmd.Parameters.Add("@Down", SqlDbType.VarChar, 30);
                cmd.Parameters["@Down"].Direction = ParameterDirection.Output;  // outpur parameter
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                string check = cmd.Parameters["@Down"].Value.ToString();
                if (check == "")
                {
                    lblproposername.Text = "Proposer is Not Vaid in up line";
                }
                else
                {
                    lblproposername.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtproposerid.Text + "'"));
                    proposalstatus = true;
                    lblleafnode.Text = lastnode(sponser);
                }
                //  lblFruitName.Text = "Last Node: " + cmd.Parameters["@printvalue"].Value.ToString();
            }
        }
    }
    #endregion

    protected string lastnode(string sponser)
    {
        using (SqlConnection con = new SqlConnection(constring))
        {

            using (SqlCommand cmd = new SqlCommand("LastNode", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", txtsponserid.Text.Trim());           //sponser id
                cmd.Parameters.AddWithValue("@node", rdonode.SelectedItem.Value);                            //node
                cmd.Parameters.Add("@printvalue", SqlDbType.VarChar, 30);
                cmd.Parameters["@printvalue"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return cmd.Parameters["@printvalue"].Value.ToString();

            }

        }
    }

    protected void rdonode_TextChanged(object sender, EventArgs e)
    {
        lblleafnode.Text = lastnode(sponser);
        // lastdata = lastnode(sponser);
    }

    protected void btnjoin_Click(object sender, EventArgs e)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            try
            {
                if (lblsponsername.Text != "")
                {
                    string aadharcount = Common.Get(objsql.GetSingleValue("select count(aadharcard) from usersnew where aadharcard='" + txtaadhar.Text + "'"));
                    if (Convert.ToInt32(aadharcount) <= 3)
                    {
                        // insert in usersnew table
                        // sregno= lastnode
                        //spillsregno = sponser
                        newregno = cm.GenerateRegno();
                        pass = cm.Generatepass();
                        #region Check capping
                        if (sponser != "")
                        {
                            string countcapping = "";
                          
                            string strMinFormat = indianTime.ToString("HH");//12 hours format
                            if (Convert.ToInt32(strMinFormat) >= 06 && Convert.ToInt32(strMinFormat) <= 18)
                            {
                                string today = date ;
                                string time = "06:00:00";
                                today = today + " " + time;
                                string today1 = date;
                                string from = today1 + " " + "18:00:00";
                                countcapping = Common.Get(objsql.GetSingleValue("select count(*) from usersnew where spillsregno='" + sponser + "' and joined Between '" + today + "' and '" + from + "'"));
                                if (Convert.ToInt32(countcapping) >= 5)
                                {
                                    objsql.ExecuteNonQuery("insert into usersnew(regno,pass,fname,lname,dob,add1,city,pin,state,country,mobile,nomirel,sregno,node,status,joined,grace,spillsregno,updated,updatepin,pintypeid,aadharcard,proposerregno,relation,active,capping) values('" + newregno + "','" + pass + "','" + txtname.Text + "','" + txtrelation.Text + "','" + dob() + "','" + txtadd.Text + "','" + txtcity.Text + "','" + txtpincode.Text + "','" + txtstate.Text + "','" + txtcountry.Text + "','" + txtphn.Text + "','" + txtnominee.Text + "','" + lastnode(sponser) + "','" + rdonode.SelectedItem.Value + "','y','" + indianTime.ToString("yyyy-MM-dd HH:mm:ss") + "','10','" + sponser + "','n','" + txtpin.Text + "','" + pintype + "','" + txtaadhar.Text + "','" + txtproposerid.Text + "','" + ddlrelation.SelectedItem.Text + "','0','1')");
                                    objsql.ExecuteNonQuery("insert into tblrewardincome(regno,rewardname,rewardincome)values('" + newregno + "','6','0')");
                                    #region insert in leg table
                                    DataTable capp = new DataTable();
                                    capp = objsql.GetTable("select * from legs where regno='" + sponser + "'");
                                    if (capp != null)
                                    {
                                        if (rdonode.SelectedItem.Value == "one")
                                        {

                                            cappingleft = (Convert.ToInt32(capp.Rows[0]["cappingleft"]) + 1);
                                            objsql.ExecuteNonQuery("update legs set cappingleft='" + cappingleft + "' where regno='" + sponser + "'");
                                        }
                                        else
                                        {
                                            cappingright = (Convert.ToInt32(capp.Rows[0]["cappingright"]) + 1);
                                            objsql.ExecuteNonQuery("update legs set cappingright='" + cappingright + "' where regno='" + sponser + "'");
                                        }
                                    }
                                    else
                                    {
                                        if (rdonode.SelectedItem.Value == "one")
                                        {

                                            cappingleft = 1;
                                            objsql.ExecuteNonQuery("update legs set cappingleft='" + cappingleft + "' where regno='" + sponser + "'");

                                        }
                                        else
                                        {
                                            cappingright = 1;
                                            objsql.ExecuteNonQuery("update legs set cappingright='" + cappingright + "' where regno='" + sponser + "'");

                                        }
                                    }

                                               objsql.ExecuteNonQuery("insert into legs(regno,leftleg,rightleg,leftdirect,rightdirect,status,cappingleft,cappingright)values('" + newregno + "','0','0','0','0','0','0','0')");






                                    #endregion
                                }
                                else
                                {
                                    objsql.ExecuteNonQuery("insert into usersnew(regno,pass,fname,lname,dob,add1,city,pin,state,country,mobile,nomirel,sregno,node,status,joined,grace,spillsregno,updated,updatepin,pintypeid,aadharcard,proposerregno,relation,active,capping) values('" + newregno + "','" + pass + "','" + txtname.Text + "','" + txtrelation.Text + "','" + dob() + "','" + txtadd.Text + "','" + txtcity.Text + "','" + txtpincode.Text + "','" + txtstate.Text + "','" + txtcountry.Text + "','" + txtphn.Text + "','" + txtnominee.Text + "','" + lastnode(sponser) + "','" + rdonode.SelectedItem.Value + "','y','" + indianTime.ToString("yyyy-MM-dd HH:mm:ss") + "','10','" + sponser + "','n','" + txtpin.Text + "','" + pintype + "','" + txtaadhar.Text + "','" + txtproposerid.Text + "','" + ddlrelation.SelectedItem.Text + "','0','0')");
                                    objsql.ExecuteNonQuery("insert into tblrewardincome(regno,rewardname,rewardincome)values('" + newregno + "','6','0')");
                                    #region insert in leg table


                                    objsql.ExecuteNonQuery("insert into legs(regno,leftleg,rightleg,leftdirect,rightdirect,status,cappingleft,cappingright)values('" + newregno + "','0','0','0','0','0','0','0')");






                                    #endregion
                                }

                            }
                            else
                            {
                                DateTime date2 = System.DateTime.Now;
                                string strMinFormat2 = indianTime.ToString("HH");//12 hours format
                                if (Convert.ToInt32(strMinFormat2) >= 18)
                                {
                                    string today = date;
                                    string next = Convert.ToDateTime(date).AddDays(1).ToString("yyyy-MM-dd");
                                    string time = "18:00:00";
                                    today = today + " " + time;
                                    string from = next + " " + "06:00:00";
                                    countcapping = Common.Get(objsql.GetSingleValue("select count(*) from usersnew where spillsregno='" + sponser + "' and joined Between '" + today + "' and '" + from + "'"));
                                    if (Convert.ToInt32(countcapping) >= 5)
                                    {
                                        objsql.ExecuteNonQuery("insert into usersnew(regno,pass,fname,lname,dob,add1,city,pin,state,country,mobile,nomirel,sregno,node,status,joined,grace,spillsregno,updated,updatepin,pintypeid,aadharcard,proposerregno,relation,active,capping) values('" + newregno + "','" + pass + "','" + txtname.Text + "','" + txtrelation.Text + "','" + dob() + "','" + txtadd.Text + "','" + txtcity.Text + "','" + txtpincode.Text + "','" + txtstate.Text + "','" + txtcountry.Text + "','" + txtphn.Text + "','" + txtnominee.Text + "','" + lastnode(sponser) + "','" + rdonode.SelectedItem.Value + "','y','" + indianTime.ToString("yyyy-MM-dd HH:mm:ss") + "','10','" + sponser + "','n','" + txtpin.Text + "','" + pintype + "','" + txtaadhar.Text + "','" + txtproposerid.Text + "','" + ddlrelation.SelectedItem.Text + "','0','1')");
                                        objsql.ExecuteNonQuery("insert into tblrewardincome(regno,rewardname,rewardincome)values('" + newregno + "','6','0')");
                                        #region insert in leg table
                                        DataTable capp = new DataTable();
                                        capp = objsql.GetTable("select * from legs where regno='" + sponser + "'");
                                        if (capp != null)
                                        {
                                            if (rdonode.SelectedItem.Value == "one")
                                            {

                                                cappingleft = (Convert.ToInt32(capp.Rows[0]["cappingleft"]) + 1);
                                                objsql.ExecuteNonQuery("update legs set cappingleft='" + cappingleft + "' where regno='" + sponser + "'");
                                            }
                                            else
                                            {
                                                cappingright = (Convert.ToInt32(capp.Rows[0]["cappingright"]) + 1);
                                                objsql.ExecuteNonQuery("update legs set cappingright='" + cappingright + "' where regno='" + sponser + "'");
                                            }
                                        }
                                        else
                                        {
                                            if (rdonode.SelectedItem.Value == "one")
                                            {

                                                cappingleft = 1;
                                                objsql.ExecuteNonQuery("update legs set cappingleft='" + cappingleft + "' where regno='" + sponser + "'");

                                            }
                                            else
                                            {
                                                cappingright = 1;
                                                objsql.ExecuteNonQuery("update legs set cappingright='" + cappingright + "' where regno='" + sponser + "'");

                                            }
                                        }

                                               objsql.ExecuteNonQuery("insert into legs(regno,leftleg,rightleg,leftdirect,rightdirect,status,cappingleft,cappingright)values('" + newregno + "','0','0','0','0','0','0','0')");






                                        #endregion
                                    }
                                    else
                                    {
                                        objsql.ExecuteNonQuery("insert into usersnew(regno,pass,fname,lname,dob,add1,city,pin,state,country,mobile,nomirel,sregno,node,status,joined,grace,spillsregno,updated,updatepin,pintypeid,aadharcard,proposerregno,relation,active,capping) values('" + newregno + "','" + pass + "','" + txtname.Text + "','" + txtrelation.Text + "','" + dob() + "','" + txtadd.Text + "','" + txtcity.Text + "','" + txtpincode.Text + "','" + txtstate.Text + "','" + txtcountry.Text + "','" + txtphn.Text + "','" + txtnominee.Text + "','" + lastnode(sponser) + "','" + rdonode.SelectedItem.Value + "','y','" + indianTime.ToString("yyyy-MM-dd HH:mm:ss") + "','10','" + sponser + "','n','" + txtpin.Text + "','" + pintype + "','" + txtaadhar.Text + "','" + txtproposerid.Text + "','" + ddlrelation.SelectedItem.Text + "','0','0')");
                                        objsql.ExecuteNonQuery("insert into tblrewardincome(regno,rewardname,rewardincome)values('" + newregno + "','6','0')");
                                        #region insert in leg table


                                        objsql.ExecuteNonQuery("insert into legs(regno,leftleg,rightleg,leftdirect,rightdirect,status,cappingleft,cappingright)values('" + newregno + "','0','0','0','0','0','0','0')");






                                        #endregion
                                    }
                                }
                            }



                        }
                        #endregion

                        #region roughf
                        //objsql.ExecuteNonQuery("insert into usersnew(regno,pass,fname,lname,dob,add1,city,pin,state,country,mobile,nomirel,sregno,node,status,joined,grace,spillsregno,updated,updatepin,pintypeid,aadharcard,proposerregno,relation,active,capping) values('" + newregno + "','" + pass + "','" + txtname.Text + "','" + txtrelation.Text + "','" + dob() + "','" + txtadd.Text + "','" + txtcity.Text + "','" + txtpincode.Text + "','" + txtstate.Text + "','" + txtcountry.Text + "','" + txtphn.Text + "','" + txtnominee.Text + "','" + lastnode(sponser) + "','" + rdonode.SelectedItem.Value + "','y','" + DateTime.Now + "','10','" + sponser + "','n','" + txtpin.Text + "','" + pintype + "','" + txtaadhar.Text + "','" + txtproposerid.Text + "','" + ddlrelation.SelectedItem.Text + "','1','0')");
                        //#region insert in leg table


                        //objsql.ExecuteNonQuery("insert into legs(regno,leftleg,rightleg,leftdirect,rightdirect,status,cappingleft,cappingright)values('" + newregno + "','0','0','0','0','0','0','0')");






                        //#endregion
                        //using (SqlConnection con = new SqlConnection(constring))
                        //{

                        //    using (SqlCommand cmd = new SqlCommand("EveryNode", con))
                        //    {
                        //        string check = lastdata;
                        //        cmd.CommandType = CommandType.StoredProcedure;
                        //        cmd.Parameters.AddWithValue("@id", lblleafnode.Text);           // sponser id
                        //        cmd.Parameters.AddWithValue("@node", rdonode.SelectedItem.Value);                            // node
                        //        cmd.Parameters.AddWithValue("@checkid", lblleafnode.Text);
                        //        cmd.Parameters.Add("@printvalue", SqlDbType.VarChar, 30);
                        //        cmd.Parameters["@printvalue"].Direction = ParameterDirection.Output;
                        //        con.Open();
                        //        cmd.ExecuteNonQuery();
                        //        con.Close();
                        //        string a = cmd.Parameters["@printvalue"].Value.ToString();

                        //    }

                        //}
                        // joining installment
                        // objsql.ExecuteNonQuery("insert into installments(regno,installment,amount,dated,paidby) values('" + newregno + "','1','1000','" + DateTime.Now + "','')"); 
                        #endregion
                        int pair = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select pintype from pins where pin='" + txtpin.Text + "'")));
                        if (pair == 750)
                        {
                            objsql.ExecuteNonQuery("update usersnew set active='1' where regno='" + newregno + "'");
                            using (SqlConnection con = new SqlConnection(constring))
                            {

                                using (SqlCommand cmd = new SqlCommand("EveryNode", con))
                                {
                                    string node = Common.Get(objsql.GetSingleValue("select node from usersnew where regno='" + newregno + "'"));
                                    string lastnode = Common.Get(objsql.GetSingleValue("select sregno from usersnew where regno='" +newregno + "'"));
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@id", lastnode);           // sponser id
                                    cmd.Parameters.AddWithValue("@node", node);                            // node
                                    cmd.Parameters.AddWithValue("@checkid", lastnode);
                                    cmd.Parameters.Add("@printvalue", SqlDbType.VarChar, 30);
                                    cmd.Parameters["@printvalue"].Direction = ParameterDirection.Output;
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    string a = cmd.Parameters["@printvalue"].Value.ToString();

                                }

                            }
                        }
                        objsql.ExecuteNonQuery("update pins set status='y', subregno='" + newregno + "' where pin='" + txtpin.Text + "'");


                        ts.Complete();
                        ts.Dispose();
                        if (txtphn.Text != "")
                        {
                            string message = "Dear "+txtname.Text+". Welcome to True Herb India. Your ID is ("+newregno+") and Password is ("+pass+"). Thanks for Joining Us. For More Detail visit www.TrueHerb1313.com";
                         //   string result = apicall("http://bulksms.antisoftindia.com/api/sendhttp.php?authkey=5040A9l5MkNR5a485965&mobiles=" + txtphn.Text + "&message=" + message + "&sender=THerbs" + "&route=4 ");
                            string result = apicall("http://sms.officialsms.in/sendSMS?username=TrueHerb&message=" + message + "&sendername=TUHERB&smstype=TRANS&numbers=" + txtphn.Text + "&apikey=ee04a007-060f-4504-b132-752d08fdfcf2");
                            
                        }
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Thank You For Registration ')", true);
                        Response.Redirect("welcome.aspx?id=" + newregno + "&pass=" + pass + "&name=" + txtname.Text);
                    }
                    else
                    {

                        ts.Dispose();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry Your Adhaar Card Number is used More Than Three Times')", true);

                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sponser Invalid')", true);

                }
            }
            catch (Exception a)
            {

                string msz = a.Message;
                throw;
            }
        }
    }
    protected string dob()
    {
        return ddlmonth.SelectedItem.Text + "/" + ddlday.SelectedItem.Text + "/" + ddlyear.Text;
    }

    protected void txtsponserid_TextChanged(object sender, EventArgs e)
    {
        lblsponsername.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtsponserid.Text + "'"));
        if (lblsponsername.Text != "")
        {
            sponser = txtsponserid.Text;
            lastdata = lastnode(sponser);
            lblleafnode.Text = lastnode(sponser);
            capping(txtsponserid.Text);
        }
        else
        {
            btnjoin.Enabled = false;
        }
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    protected void txtpin_TextChanged(object sender, EventArgs e)
    {
        string pin = Common.Get(objsql.GetSingleValue("select pin from pins where pin='" + txtpin.Text + "' and status='n'"));
        if (pin != "")
        {
            lblstatus.Text = "Pin Available";
        }
        else
        {
            lblstatus.Text = "Pin Not Available";
            btnjoin.Enabled = false;
        }
    }
    public void capping(string sponser)
    {

    }
    public string apicall(string url)
    {
        HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
        StreamReader sr = new StreamReader(httpres.GetResponseStream());
        string results = sr.ReadToEnd();
        sr.Close();
        return results;
    }

}