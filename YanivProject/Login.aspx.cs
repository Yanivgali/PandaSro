using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;

public partial class YanivProject_Pictures_Login1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnlogin(object sender, EventArgs e)
    {
        MySql sqlAdmin = new MySql();
        DataSet dsAdmin = new DataSet();
        string stAdmin = "SELECT tblAdmin.AdminUserName, tblAdmin.AdminPassword FROM tblAdmin WHERE(((tblAdmin.AdminUserName) = '" + txtUserName.Value + "') AND((tblAdmin.AdminPassword) = '" + txtPassword.Value + "'));";
        dsAdmin = sqlAdmin.testdata(stAdmin);
        if (dsAdmin.Tables[0].Rows.Count > 0)
        {
            MySql sqlAdmin1 = new MySql();
            DataSet dsAdmin1 = new DataSet();
            string stAdmin1 = "SELECT tblAdmin.Email,tblAdmin.Phonenumber FROM tblAdmin WHERE(((tblAdmin.AdminUserName) ='" + txtUserName.Value + "'));";
            dsAdmin1 = sqlAdmin1.testdata(stAdmin1);
            string str = dsAdmin1.Tables[0].Rows[0][0].ToString();
            Session["AdminEmail"] = str;
            Session["AdminPhone"] = dsAdmin1.Tables[0].Rows[0][1].ToString();
            Session["AdminPassword"] = txtPassword.Value;
            Session["Admin"] = txtUserName.Value;
            Response.Redirect("HomePage.aspx");
        }
        MySql sqlUser = new MySql();
        DataSet dsUser = new DataSet();
        string stUser = "SELECT TblUser.UserName, TblUser.UserPassword FROM TblUser WHERE(((TblUser.UserName) = '" + txtUserName.Value + "') AND((TblUser.UserPassword) = '" + txtPassword.Value + "'));";
        dsUser = sqlUser.testdata(stUser);
        if (dsUser.Tables[0].Rows.Count > 0)
        {
            MySql sqlUser1 = new MySql();
            DataSet dsUser1 = new DataSet();
            string stUser1 = "SELECT TblUser.UserPassword, TblUser.Email, TblUser.Phonenumber FROM TblUser WHERE(((TblUser.UserName) ='" + txtUserName.Value + "'));";
            dsUser1 = sqlUser1.testdata(stUser1);
            Session["UserEmail"] = dsUser1.Tables[0].Rows[0][1].ToString();
            Session["User"] = txtUserName.Value;
            Session["phone"]= dsUser1.Tables[0].Rows[0][2].ToString();
            Session["UserPassword"] = txtPassword.Value;
            Response.Redirect("HomePage.aspx");
        }
        else
        {
            lblun.InnerHtml= "Wrong UserName/Password";
            lblun.Attributes["style"] = "color:red; font-size:10px;";
        }

    }

    protected void btnforgetpass(object sender, EventArgs e)
    {
        Response.Redirect("ForgotPassword.aspx");
    }
}