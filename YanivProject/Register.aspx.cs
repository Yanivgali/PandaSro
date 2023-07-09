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

public partial class YanivProject_Register1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    public bool email()
    {
        string stmail = txtem.Value;
        if (stmail[stmail.Length - 1] != 'm')
        {
            lblem.Attributes["style"] = "color:red;";
            lblem.InnerText = "Email isn't valid.";
            return false;
        }
        if (stmail[stmail.Length - 2] != 'o')
        {
            lblem.Attributes["style"] = "color:red;";
            lblem.InnerText = "Email isn't valid.";
            return false;
        }
        if (stmail[stmail.Length - 3] != 'c')
        {
            lblem.Attributes["style"] = "color:red;";
            lblem.InnerText = "Email isn't valid.";
            return false;
        }
        if (stmail[stmail.Length - 4] != '.')
        {
            lblem.Attributes["style"] = "color:red;";
            lblem.InnerText = "Email isn't valid.";
            return false;
        }
        return true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        lblem.Attributes["style"] = "color:white;";
        lblun.Attributes["style"] = "color:white;";
        lblpscon.Attributes["style"] = "color:white;";
        lblem.InnerText = "Email";
        lblpscon.InnerText = "Confirm UserPassword";
        lblun.InnerText = "Username";
        MySql sqlAdmin = new MySql();
        DataSet dsAdmin = new DataSet();
        string stAdmin = "SELECT tblAdmin.AdminUserName FROM tblAdmin WHERE(((tblAdmin.AdminUserName) ='" + txtun.Value + "'));";
        dsAdmin = sqlAdmin.testdata(stAdmin);
        MySql sqlUser = new MySql();
        DataSet dsUser = new DataSet();
        string stUser = "SELECT TblUser.UserName, TblUser.UserPassword, TblUser.Email FROM TblUser WHERE(((TblUser.UserName) ='" + txtun.Value + "'));";
        dsUser = sqlUser.testdata(stUser);
        MySql sqlEmail = new MySql();
        DataSet dsEmail = new DataSet();
        string stemail = "SELECT TblUser.UserName, TblUser.UserPassword, TblUser.Email FROM TblUser WHERE(((TblUser.Email) ='" + txtem.Value + "'));";
        dsEmail = sqlEmail.testdata(stemail);
        if (txtps.Value != txtcon.Value)
        {
            lblpscon.Attributes["style"] = "color:red;";
            lblpscon.InnerText = "UserPassword doesn't match";
        }
        if (dsUser.Tables[0].Rows.Count > 0)
        {
            lblun.Attributes["style"] = "color:red;";
            lblun.InnerText = "Username already taken.";
            if (dsEmail.Tables[0].Rows.Count > 0)
            {
                lblem.Attributes["style"] = "color:red;";
                lblem.InnerText = "Email already taken.";
            }
        }
        if (dsEmail.Tables[0].Rows.Count > 0)
        {
            lblem.Attributes["style"] = "color:red;";
            lblem.InnerText = "Email already taken.";
            if (dsUser.Tables[0].Rows.Count > 0)
            {
                lblun.Attributes["style"] = "color:red;";
                lblun.InnerText = "Username already taken.";
            }
        }
        if (dsUser.Tables[0].Rows.Count == 0 && dsAdmin.Tables[0].Rows.Count == 0 && dsEmail.Tables[0].Rows.Count == 0 && txtps.Value == txtcon.Value && email() == true)
        {
            Session["User2"] = txtun.Value;
            Session["UserPassword2"] = txtps.Value;
            Session["UserEmail2"] = txtem.Value;
            Random rnd = new Random();
            string code = (rnd.Next(10000, 100000)).ToString();
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            mail.IsBodyHtml = true;
            mail.From = new MailAddress("silkroadpandasro@gmail.com");
            mail.To.Add(txtem.Value);
            mail.Subject = "Hello there, " + txtun.Value + ".";
            mail.Body = "We are glad you choose to join us, This server is play2win work smart&hard and be on our top list we hope that you will have a nice a pleasant experience with us :), Your verification code is " + code + ", If you have any question or problem you may always send us email we will answer in 24 hours, Good luck on your journey my friend!";
            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("silkroadpandasro@gmail.com", "rubwfwvfyjetgsfk");
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);
            Session["Code"] = code;
            Session["count"] = 0;
            Response.Redirect("Emailverification.aspx");
        }
    }
}