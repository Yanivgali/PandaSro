using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class YanivProject_ChangeAdminInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        lblerr.Visible = false;
        lblusernamet.Visible = false;
        lblemailt.Visible = false;
        pnlEmail.Visible = false;
        pnlPassword.Visible = false;
        pnlUsername.Visible = false;
        lblsucc.Visible = false;
        if (ddlt.SelectedItem.Text == "Choose Info to change")
        {
        }
        if (ddlt.SelectedItem.Text == "ChangeAdminName")
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
            string stuser = "SELECT TblUser.UserName FROM TblUser WHERE(((TblUser.UserName) ='" + txtupdateAdminName.Text + "'));";
            dsuser = sqluser.testdata(stuser);
            MySql sqlAdmin = new MySql();
            DataSet dsAdmin = new DataSet();
            string stAdmin = "SELECT tblAdmin.AdminUserName FROM tblAdmin WHERE(((tblAdmin.AdminUserName) ='" + txtupdateAdminName.Text + "'));";
            dsAdmin = sqlAdmin.testdata(stAdmin);
            if (dsAdmin.Tables[0].Rows.Count > 0 || dsuser.Tables[0].Rows.Count>0)
            {
                lblusernamet.Visible = true;
            }
            else
            {
                MySql sqluser1 = new MySql();
                DataSet dsuser1 = new DataSet();
                string stAdmin1 = "UPDATE tblAdmin SET tblAdmin.AdminUserName = '" + txtupdateAdminName.Text + "' WHERE(((tblAdmin.AdminUserName) ='" + Session["Admin"].ToString() + "'));";
                dsuser1 = sqluser1.testdata(stAdmin1);
                lblsucc.Visible = true;
                Session["Admin"] = txtupdateAdminName.Text;
                lblsucc.Visible = true;
                Response.Redirect("ChangeAdminInfo.aspx");
            }
        }
        else if (pnlEmail.Visible == true)
        {
            MySql sqluser = new MySql();
            DataSet dsuser = new DataSet();
            string stuser = "SELECT tblAdmin.Email FROM tblAdmin WHERE(((tblAdmin.Email) ='" + txtupEmail.Text + "'));";
            dsuser = sqluser.testdata(stuser);
            MySql sqlAdmince = new MySql();
            DataSet dsAdmince = new DataSet();
            string stAdmince = "SELECT tblAdmin.Email FROM tblAdmin WHERE(((tblAdmin.Email) ='"+txtupEmail.Text+"'));";
            dsAdmince = sqlAdmince.testdata(stAdmince);
            if(dsAdmince.Tables[0].Rows.Count > 0|| dsuser.Tables[0].Rows.Count > 0)
            {
                lblemailt.Visible = true;
            }
            if(dsAdmince.Tables[0].Rows.Count <= 0 && dsuser.Tables[0].Rows.Count <= 0 && chk()&& email())
            {
                MySql sqluser1 = new MySql();
                DataSet dsuser1 = new DataSet();
                string stAdmin1 = "UPDATE tblAdmin SET tblAdmin.Email = '" + txtupEmail.Text + "' WHERE(((tblAdmin.Email) ='" + Session["AdminEmail"].ToString() + "'));";
                dsuser1 = sqluser1.testdata(stAdmin1);
                Session["AdminEmail"] = txtupEmail.Text;
                lblsucc.Visible = true;
            }
        }
        else if (pnlPassword.Visible == true)
        {
            MySql sqluser = new MySql();
            DataSet dsuser = new DataSet();
            string stAdmin = "UPDATE tblAdmin SET tblAdmin.AdminPassword = '" + txtupdatepassword.Text + "' WHERE(((tblAdmin.AdminUserName) ='" + Session["Admin"].ToString() + "'));";
            dsuser = sqluser.testdata(stAdmin);
            lblsucc.Visible = true;
        }
        else if(ddlt.SelectedItem.Text == "ChangeAdminName")
        {
            lblerr.Visible = true;
        }
    }
}