using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Collections.Specialized;

public partial class YanivProject_ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblun.Visible = false;
        btnSend.Visible = true;
        lblsucc.Visible = false;
        lblerr1.Visible = false;
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        MySql sqlUser = new MySql();
        DataSet dsUser = new DataSet();
        string stUser = "SELECT TblUser.UserPassword, TblUser.Email, TblUser.Phonenumber FROM TblUser WHERE(((TblUser.UserName) ='" + txtUsername.Text + "'));";
        dsUser = sqlUser.testdata(stUser);
        if (dsUser.Tables[0].Rows.Count > 0)
        {
            string str = dsUser.Tables[0].Rows[0][1].ToString();
            string stpass = dsUser.Tables[0].Rows[0][0].ToString();
            string stphone = dsUser.Tables[0].Rows[0][2].ToString();
            Session["usPassword"] = stpass;
            Session["usEmail"] = str;
            Session["usPhone"] = stphone;
            if (txtEmail.Text == Session["usEmail"].ToString())
            {
                btnSend.Visible = false;
                lblsucc.Visible = true;
                lblEmailname.Visible = true;
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                mail.IsBodyHtml = true;
                mail.From = new MailAddress("silkroadpandasro@gmail.com");
                mail.To.Add(Session["usEmail"].ToString());
                mail.Subject = "Your Password is:";
                mail.Body = "<h1 style=\"text-align: left;\">:Your password is</h1><table style=\"font-family: arial, sans-serif; border-collapse: collapse; width: 50%;\"><tr style=\"background-color: #dddddd;\"><th style=\"border: 1px solid #dddddd; text-align: left; padding: 8px;\">" + Session["usPassword"].ToString() + "</th></tr></table>";
                smtpServer.Port = 587;
                smtpServer.Credentials = new System.Net.NetworkCredential("silkroadpandasro@gmail.com", "19735647");
                smtpServer.EnableSsl = true;
                smtpServer.Send(mail);
                lblEmailname.Text = Session["usEmail"].ToString();
            }
            else
            {
                lblerr1.Visible = true;
            }
        }
        MySql sqlAdmin = new MySql();
        DataSet dsAdmin = new DataSet();
        string stAdmin = "SELECT tblAdmin.AdminPassword, tblAdmin.Email, tblAdmin.Phonenumber FROM tblAdmin WHERE(((tblAdmin.AdminUserName) ='" + txtUsername.Text + "'));";
        dsAdmin = sqlAdmin.testdata(stAdmin);
        if (dsAdmin.Tables[0].Rows.Count <= 0 && dsUser.Tables[0].Rows.Count <= 0)
        {
            lblun.Visible = true;
        }
        if (dsAdmin.Tables[0].Rows.Count > 0)
        {
            string stpass1 = dsAdmin.Tables[0].Rows[0][0].ToString();
            string str1 = dsAdmin.Tables[0].Rows[0][1].ToString();
            string stphone1 = dsAdmin.Tables[0].Rows[0][2].ToString();
            Session["Password1"] = stpass1;
            Session["Email1"] = str1;
            Session["Phone1"] = stphone1;
            if (txtEmail.Text == Session["Email1"].ToString())
            {
                btnSend.Visible = false;
                lblsucc.Visible = true;
                lblEmailname.Visible = true;
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("silkroadpandasro@gmail.com");
                mail.To.Add(Session["Email1"].ToString());
                mail.Subject = "Your Password is:";
                mail.Body = "<h1 style=\"text-align: left;\">:Your password is</h1><table style=\"font-family: arial, sans-serif; border-collapse: collapse; width: 50%;\"><tr style=\"background-color: #dddddd;\"><th style=\"border: 1px solid #dddddd; text-align: left; padding: 8px;\">" + Session["Password1"].ToString() + "</th></tr></table>";
                smtpServer.Port = 587;
                smtpServer.Credentials = new System.Net.NetworkCredential("silkroadpandasro@gmail.com", "19735647");
                smtpServer.EnableSsl = true;
                smtpServer.Send(mail);
                lblEmailname.Text = Session["Email1"].ToString();
            }
            else
            {
                lblerr1.Visible = true;
            }
        }
        
    }
}