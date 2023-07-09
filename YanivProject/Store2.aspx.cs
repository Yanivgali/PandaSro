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

public partial class YanivProject_Store2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        //get userid
        if (Session["User"] != null)
        {
            MySql sqlusid = new MySql();
            DataSet dsusid = new DataSet();
            string stusid = "SELECT TblUser.[ID] FROM TblUser WHERE(((TblUser.[UserName]) ='" + Session["User"] + "'));";
            dsusid = sqlusid.testdata(stusid);
            Session["Userid"] = dsusid.Tables[0].Rows[0][0].ToString();
        }
        lblcosucc.Visible = false;
        lblnotexist.Visible = false;
        lblsucc.Visible = false;
        lblerr.Visible = false;
        pnlCheckout.Visible =false;
        if (ddlname.SelectedItem.Text == "Choose weapon")
        {
            pnlCheckout.Visible = false;
        }
    }

    protected void rblRace_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlname.Items.Count > 1)
        {
            for (int i = 0; i < ddlname.Items.Count; i++)
            {
                ddlname.Items.Clear();
            }
            ddlname.Items.Add("Choose weapon");
        }
        pnlCheckout.Visible = false;
        MySql sqlrace = new MySql();
        DataSet dsrace = new DataSet();
        string strace = "SELECT TblWeapon.WeaponName FROM TblWeapon WHERE(((TblWeapon.Race) ='"+rblRace.SelectedValue.ToString()+"'));";
        dsrace = sqlrace.testdata(strace);
        for(int i = 0; i < dsrace.Tables[0].Rows.Count; i++)
        {
            ddlname.Items.Add(dsrace.Tables[0].Rows[i][0].ToString());
        }
    }

    protected void ddlname_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlname.SelectedItem.Text == "Choose weapon")
        {
            pnlCheckout.Visible = false;
        }
        if (ddlname.SelectedItem.Text != "Choose weapon")
        {
            pnlCheckout.Visible = true;
        }
        
        MySql sqldisplay= new MySql();
        DataSet dsdisplay = new DataSet();
        string stdisplay = "SELECT TblWeapon.Price, TblWeapon.WeaponImg, TblWeapon.ID, TblWeapon.description FROM TblWeapon WHERE(((TblWeapon.WeaponName) ='" + ddlname.SelectedItem.Text+"'));";
        dsdisplay = sqldisplay.testdata(stdisplay);
        Session["Price"] = dsdisplay.Tables[0].Rows[0][0].ToString();
        if (dsdisplay.Tables[0].Rows.Count > 0)
        {
            Session["ProudctId"] = dsdisplay.Tables[0].Rows[0][2].ToString();
            string img = "Pictures/zWeapons/" + dsdisplay.Tables[0].Rows[0][1].ToString();
            imgweapon.ImageUrl = img;
            lbltotalprice.Text = dsdisplay.Tables[0].Rows[0][0].ToString();
        }

    }
    protected void btnOrder_Click(object sender, EventArgs e)
    {

        ServiceReference1.ServiceSoapClient dsCheckvisa = new ServiceReference1.ServiceSoapClient();
        ServiceReference1.Credit Checkvisa = new ServiceReference1.Credit();
        Checkvisa.Cvv = txtCVC.Text;
        Checkvisa.CardNum = txtvisa.Text;
        Checkvisa.Expr = txtexpiredate.Text;
        Checkvisa.FName = txtVisaholder.Text;
        if (dsCheckvisa.checkvisa(Checkvisa.CardNum, Checkvisa.Expr, Checkvisa.Cvv, Checkvisa.FName))
        {
            if (Session["Coupon"] != null && Session["Coupon"].ToString() == "true")
            {
                lbltotalprice.Text = Session["Price"].ToString();
                ServiceReference1.ServiceSoapClient dsdelcoupon = new ServiceReference1.ServiceSoapClient();
                ServiceReference1.coupon DeleteCoupon = new ServiceReference1.coupon();
                DeleteCoupon.Txtcoupon = txtcoupon.Text;
                DeleteCoupon.Username = Session["User"].ToString();
                dsdelcoupon.DeleteCoupon(DeleteCoupon.Username, DeleteCoupon.Txtcoupon);
            }
            lblsucc.Visible = true;
            pnlCheckout.Visible = true;
            //insert to tblorder
            MySql sqliOrder = new MySql();
            DataSet dsiOrder = new DataSet();
            string time = DateTime.Now.ToLongTimeString();
            string stiOrder = "insert into TblOrder(UserId, CardNumber, OrderTime, Phone, Email, VisaHolder, ExpiredDated, CVC, TotalOrderAmount, ProtuctID) values(" + Session["Userid"] + ",'" + txtvisa.Text + "', '" + time + "', '" + Session["phone"] + "', '" + Session["UserEmail"] + "','" + txtVisaholder.Text + "','" + txtexpiredate.Text + "','" + txtCVC.Text + "','" + lbltotalprice.Text + "','" + Session["ProudctId"] + "')";
            sqliOrder.updelin(stiOrder);
            //get orderid and ProudctId from tblorder
            MySql sqlorderid = new MySql();
            DataSet dsorderid = new DataSet();
            string storderid = "SELECT TblOrder.OrderId FROM TblOrder WHERE(((TblOrder.UserId) =" + Session["Userid"] + ") AND((TblOrder.OrderTime) ='" + time + "'));";
            dsorderid = sqlorderid.testdata(storderid);
            Session["OrderId"] = dsorderid.Tables[0].Rows[0][0].ToString();
            //insert to tblsuborder
            MySql sqlisubOrder = new MySql();
            DataSet dsisubOrder = new DataSet();
            string stisubOrder = "insert into TblSubOrder(OrderId, ProudctId, OrderAmount) values(" + Session["OrderId"] + ",'" + Session["ProudctId"] + "', '" + lbltotalprice.Text + "')";
            sqlisubOrder.updelin(stisubOrder);
            //email*/
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            mail.IsBodyHtml = true;
            mail.From = new MailAddress("silkroadpandasro@gmail.com");
            mail.To.Add(Session["UserEmail"].ToString());
            mail.Subject = "Your order was Successfully executed";
            mail.Body = "<p>We are pleased to inform you that your purchase on Pandasro has been successful: " + Session["User"] + "</p> <p>we hope to serve you agian thank you for your purchase we appreciate it very much.</p><br/><table style=\"font-family: arial, sans-serif; border-collapse: collapse; width: 50%;\"><tr style=\"background-color: #dddddd;\"><th style=\"border: 1px solid #dddddd; text-align: left;\"></th><th style=\"border: 1px solid #dddddd; text-align: left;\"></th></tr></table>";
            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("silkroadpandasro@gmail.com", "19735647");
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);
        }
        else
        {
            pnlCheckout.Visible = true;
            lblerr.Visible = true;
            lblsucc.Visible = false;
        }
    }

    protected void btncheek_Click(object sender, EventArgs e)
    {
        pnlCheckout.Visible = true;
        ServiceReference1.ServiceSoapClient dsdelcoupon = new ServiceReference1.ServiceSoapClient();
        ServiceReference1.coupon checkcoupon = new ServiceReference1.coupon();
        checkcoupon.Txtcoupon = txtcoupon.Text;
        checkcoupon.Username = Session["User"].ToString();
        if (dsdelcoupon.chkCoupon(checkcoupon.Txtcoupon, checkcoupon.Username))
        {
            lbltotalprice.Text = Math.Abs(int.Parse(Session["Price"].ToString()) * 0.85).ToString();
            lblcoupon.Visible = true;
            txtcoupon.Visible = true;
            btncheek.Visible = true;
            lblcosucc.Visible = true;
            Session["Price"] = lbltotalprice.Text;
            Session["Coupon"] = "true";
        }
        else
        {
            lbltotalprice.Text = Session["Price"].ToString();
            Session["Coupon"] = "false";
            lblnotexist.Visible = true;
        }
    }
}