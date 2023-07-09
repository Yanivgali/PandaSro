using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class YanivProject_ChangeUserInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        lblusernamet.Visible = false;
        lblemailt.Visible = false;
        pnlEmail.Visible = false;
        pnlPassword.Visible = false;
        pnlUsername.Visible = false;
        lblerr.Visible = false;
        lblsucc.Visible = false;
        if (ddlt.SelectedItem.Text == "Choose Info to change")
        {
        }
        if (ddlt.SelectedItem.Text == "ChangeUserName")
        {
            pnlUsername.Visible = true;
        }
        if (ddlt.SelectedItem.Text == "ChangePassword")
        {
            pnlPassword.Visible = true;
        }
        if (ddlt.SelectedItem.Text == "ChangeEmail")
        {
            pnlEmail.Visible = true;
        }
    }
    public bool chk()
    {
        if (txtupEmail.Text == "")
        {
            txtupEmail.Text = "יש למלא מייל";
            return false;
        }
        string stMail = txtupEmail.Text;
        if (stMail.IndexOf('@') == -1)
        {
            txtupEmail.Text = "חסר @ במייל";
            return false;
        }
        if (stMail[0] == '@')
        {
            txtupEmail.Text = "@ לא יכול להופיע בהתחלה";
            return false;
        }
        if (stMail[stMail.Length - 1] == '@')
        {
            txtupEmail.Text = "@ לא יכול להופיע בסוף";
            return false;
        }
        return true;
    }
    public bool email()
    {
        string stmail = txtupEmail.Text;
        if (stmail[stmail.Length - 1] != 'm')
        {
            lblemailt.Visible = true;
            return false;
        }
        if (stmail[stmail.Length - 2] != 'o')
        {
            lblemailt.Visible = true;
            return false;
        }
        if (stmail[stmail.Length - 3] != 'c')
        {
            lblemailt.Visible = true;
            return false;
        }
        if (stmail[stmail.Length - 4] != '.')
        {
            lblemailt.Visible = true;
            return false;
        }
        return true;
    }
    protected void btnacc_Click(object sender, EventArgs e)
    {
        if (pnlUsername.Visible == true)
        {
            MySql sqluser = new MySql();
            DataSet dsuser = new DataSet();
            string stuser = "SELECT TblUser.UserName FROM TblUser WHERE(((TblUser.UserName) ='" + txtupdateUserName.Text + "'));";
            dsuser = sqluser.testdata(stuser);
            MySql sqlAdmin = new MySql();
            DataSet dsAdmin = new DataSet();
            string stAdmin = "SELECT tblAdmin.AdminUserName FROM tblAdmin WHERE(((tblAdmin.AdminUserName) ='" + txtupdateUserName.Text + "'));";
            dsAdmin = sqlAdmin.testdata(stAdmin);
            if (dsAdmin.Tables[0].Rows.Count > 0 || dsuser.Tables[0].Rows.Count > 0 || txtupdateUserName.Text == "")
            {
                lblusernamet.Visible = true;
            }
            else
            {
                MySql sqluser1 = new MySql();
                DataSet dsuser1 = new DataSet();
                string stuser1 = "UPDATE TblUser SET TblUser.UserName = '" + txtupdateUserName.Text + "' WHERE(((TblUser.UserName) ='" + Session["User"].ToString() + "'));";
                dsuser1 = sqluser1.testdata(stuser1);
                Session["User"] = txtupdateUserName.Text;
                lblsucc.Visible = true;
                Response.Redirect("ChangeUserInfo.aspx");
            }
        }
        else if (pnlEmail.Visible == true)
        {
            MySql sqlEmail = new MySql();
            DataSet dsEmail = new DataSet();
            string stEmail = "SELECT TblUser.Email FROM TblUser WHERE(((TblUser.Email) ='" + txtupEmail.Text + "'));";
            dsEmail = sqlEmail.testdata(stEmail);
            MySql sqlAdmin = new MySql();
            DataSet dsAdmin = new DataSet();
            string stAdmin = "SELECT tblAdmin.Email FROM tblAdmin WHERE(((tblAdmin.Email) ='" + txtupEmail.Text + "'));";
            dsAdmin = sqlAdmin.testdata(stAdmin);
            if (dsAdmin.Tables[0].Rows.Count > 0 || dsEmail.Tables[0].Rows.Count > 0)
            {
                lblemailt.Visible = true;
            }
            if (dsAdmin.Tables[0].Rows.Count <= 0 && dsEmail.Tables[0].Rows.Count <= 0 && chk()&& email())
            {
                MySql sqluser1 = new MySql();
                DataSet dsuser1 = new DataSet();
                string stuser1 = "UPDATE TblUser SET TblUser.Email = '" + txtupEmail.Text + "' WHERE(((TblUser.Email) ='" + Session["UserEmail"].ToString() + "'));";
                dsuser1 = sqluser1.testdata(stuser1);
                Session["UserEmail"] = txtupEmail.Text;
                lblsucc.Visible = true;
            }
        }
        else if (pnlPassword.Visible == true)
        {
            MySql sqluser = new MySql();
            DataSet dsuser = new DataSet();
            string stuser = "UPDATE TblUser SET TblUser.UserPassword ='" + txtupdatepassword.Text + "' WHERE(((TblUser.UserName) ='" + Session["User"].ToString() + "'));";
            dsuser = sqluser.testdata(stuser);
            lblsucc.Visible = true;
        }
        else
        {
            lblerr.Visible = true;
        }
    }
}