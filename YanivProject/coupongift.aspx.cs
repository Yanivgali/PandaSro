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

public partial class YanivProject_coupongift : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        lblsend.Visible = false;
        lblchoose.Visible = false;
    }
    static class RandomLetter
    {
        static Random _random = new Random();
        public static char GetLetter()
        {
            // This method returns a random lowercase letter.
            // ... Between 'a' and 'z' inclusize.
            int num = _random.Next(0, 26); // Zero to 25
            char let = (char)('a' + num);
            return let;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddlus.SelectedItem.Text == "Select User to gift")
        {
            lblchoose.Visible = true;
        }
        else
        {
            lblsend.Visible = true;
            string letters ="";
            for(int i = 0; i < 6; i++)
            {
                letters += RandomLetter.GetLetter();
            }
            MySql sqlemail = new MySql();
            DataSet dsemail = new DataSet();
            string stemail = "SELECT TblUser.Email FROM TblUser WHERE(((TblUser.UserName) ='"+ ddlus.SelectedItem.Text + "'));";
            dsemail = sqlemail.testdata(stemail);
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            mail.IsBodyHtml = true;
            mail.From = new MailAddress("silkroadpandasro@gmail.com");
            mail.To.Add(dsemail.Tables[0].Rows[0][0].ToString());
            mail.Subject = "Hi "+ ddlus.SelectedItem.Text +".";
            mail.Body = "We are glad to announce that you have been found deserving a free coupon in our site you can activate it when ever you want for 1 time.  Use it smart! Coupon:"+ letters;
            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("silkroadpandasro@gmail.com", "19735647");
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);
            ServiceReference1.ServiceSoapClient dsinscoupon = new ServiceReference1.ServiceSoapClient();
            ServiceReference1.coupon insertCoupon = new ServiceReference1.coupon();
            insertCoupon.Username = ddlus.SelectedItem.Text;
            insertCoupon.Letters = letters;
            dsinscoupon.insertCoupon(insertCoupon.Username, insertCoupon.Letters);
        }
    }
}