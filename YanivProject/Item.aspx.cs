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

public partial class YanivProject_Store : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("Store.aspx");
        }
        //get userid
        MySql sqlusid = new MySql();
        DataSet dsusid = new DataSet();
        string stusid = "SELECT TblUser.[ID] FROM TblUser WHERE(((TblUser.[UserName]) ='" + Session["User"] + "'));";
        dsusid = sqlusid.testdata(stusid);
        Session["Userid"] = dsusid.Tables[0].Rows[0][0].ToString();
        lblcosucc.Visible = false;
        lblnotexist.Visible = false;
        lblsucc.Visible = false;
        lblerr.Visible = false;
        DataSet ds = new DataSet(); 
        MySql sql = new MySql();
        string selectItem = "SELECT TblWeapon.Race, TblWeapon.WeaponName, TblWeapon.Price, TblWeapon.WeaponImg, TblWeapon.description, TblWeapon.ID FROM TblWeapon WHERE(((TblWeapon.id) = " + Request.QueryString["id"] + "));";
        ds = sql.testdata(selectItem);
        Session["ProudctId"] = ds.Tables[0].Rows[0][5].ToString();
        lblRace.Text = ds.Tables[0].Rows[0][0].ToString();
        Lblitemname1.Text = ds.Tables[0].Rows[0][1].ToString();
        lblitemprice1.Text = ds.Tables[0].Rows[0][2].ToString();
        itemimage1.ImageUrl = "/YanivProject/Pictures/zWeapons/" + ds.Tables[0].Rows[0][3].ToString();
        lbldiscription.Text = ds.Tables[0].Rows[0][4].ToString();
        DataSet dsAddToStore = new DataSet();
        MySql sqlAddToStore = new MySql();
        string AddToStore = "INSERT INTO TblBasket ( UserName, Phone, Email, ProtuctID, OrderAmount)values ( '" + Session["User"] + "', '" + Session["phone"] + "', '" + Session["UserEmail"] + "'," + Request.QueryString["id"] + ",'" + lblitemprice1.Text + "');";
        dsAddToStore = sqlAddToStore.testdata(AddToStore);
        Session["price"] = ds.Tables[0].Rows[0][2].ToString();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        MySql sql = new MySql();
        string selectItem = "SELECT TblWeapon.Race, TblWeapon.WeaponName, TblWeapon.Price, TblWeapon.WeaponImg, TblWeapon.description FROM TblWeapon WHERE(((TblWeapon.id) = " + Request.QueryString["id"] + "));";
        ds = sql.testdata(selectItem);
        int x = int.Parse(ds.Tables[0].Rows[0][2].ToString());
        Session["price"] = x;
        int b = int.Parse(ddlamount.SelectedItem.Value);
        lblitemprice1.Text = (x * b).ToString();
        if (Session["User"] != null)
        {
            DataSet dschangStore = new DataSet();
            MySql sqlchangStore = new MySql();
            string changStore = "UPDATE TblBasket SET TblBasket.OrderAmount = '" + lblitemprice1.Text + "' WHERE(((TblBasket.ProtuctID) =" + Request.QueryString["id"] + "));";
            dschangStore = sqlchangStore.testdata(changStore);
        }
    }

    protected void btnOrder_Click(object sender, EventArgs e)
    {
        ServiceReference1.ServiceSoapClient dsCheckvisa = new ServiceReference1.ServiceSoapClient();
        ServiceReference1.Credit Checkvisa = new ServiceReference1.Credit();
        Checkvisa.Cvv = txtCVC.Text;
        Checkvisa.CardNum = txtvisa.Text;
        Checkvisa.Expr = txtexpiredate.Text;
        Checkvisa.FName = txtvisaholder.Text;
        if (dsCheckvisa.checkvisa(Checkvisa.CardNum, Checkvisa.Expr, Checkvisa.Cvv, Checkvisa.FName))
        {
            if (Session["Coupon"] != null && Session["Coupon"].ToString() == "true")
            {
                lblnotexist.Visible = true;
                lblitemprice1.Text = Math.Abs(int.Parse(ddlamount.SelectedItem.Value) * int.Parse(lblitemprice1.Text) * 0.85).ToString();
                ServiceReference1.ServiceSoapClient dsdelcoupon = new ServiceReference1.ServiceSoapClient();
                ServiceReference1.coupon DeleteCoupon = new ServiceReference1.coupon();
                DeleteCoupon.Txtcoupon = txtcoupon.Text;
                DeleteCoupon.Username = Session["User"].ToString();
                dsdelcoupon.DeleteCoupon(DeleteCoupon.Username, DeleteCoupon.Txtcoupon);
            }
            string time = DateTime.Now.ToLongTimeString();
            for (int i = 0; i < int.Parse(ddlamount.SelectedItem.Text); i++)
            {
                //insert to tblorder
                MySql sqliOrder = new MySql();
                DataSet dsiOrder = new DataSet();
                string stiOrder = "insert into TblOrder(UserId, CardNumber, OrderTime, Phone, Email, VisaHolder, ExpiredDated, CVC, TotalOrderAmount, ProtuctID) values(" + Session["Userid"] + ",'" + txtvisa.Text + "', '" + time + "', '" + Session["phone"] + "', '" + Session["UserEmail"] + "','" + txtvisaholder.Text + "','" + txtexpiredate.Text + "','" + txtCVC.Text + "','" + lblitemprice1.Text + "','" + Session["ProudctId"] + "')";
                sqliOrder.updelin(stiOrder);
                //get orderid and ProudctId from tblorder
                MySql sqlorderid = new MySql();
                DataSet dsorderid = new DataSet();
                string storderid = "SELECT TblOrder.OrderId FROM TblOrder WHERE(((TblOrder.UserId) =" + Session["Userid"] + ") AND((TblOrder.OrderTime) ='" + time + "'));";
                dsorderid = sqlorderid.testdata(storderid);
                Session["OrderId"] = dsorderid.Tables[0].Rows[i][0].ToString();
                //insert to tblsuborder
                MySql sqlisubOrder = new MySql();
                DataSet dsisubOrder = new DataSet();
                string stisubOrder = "insert into TblSubOrder(OrderId, ProudctId, OrderAmount) values(" + Session["OrderId"] + ",'" + Session["ProudctId"] + "', '" + lblitemprice1.Text + "')";
                sqlisubOrder.updelin(stisubOrder);
            }
            //email*/
            MySql sqlUser = new MySql();
            DataSet ds = new DataSet();
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            mail.IsBodyHtml = true;
            mail.From = new MailAddress("silkroadpandasro@gmail.com");
            mail.To.Add(Session["UserEmail"].ToString());
            mail.Subject = "Your order was Successfully executed";
            mail.Body = "<p>We are pleased to inform you that your purchase on Pandasro has been successful: " + Session["User"] + "</p><p>we hope to serve you agian thank you for your purchase we appreciate it very much.</p><br/><h1 style=\"text-align: left; text-decoration: underline;\">:Your purchase info</h1><table style=\"font-family: arial, sans-serif; border-collapse: collapse; width: 50%;\"><tr style=\"background-color: #dddddd;\">";
            MySql sqlweapon = new MySql();
            DataSet dsweapon = new DataSet();
            string stUser = "SELECT TblWeapon.id, TblWeapon.Race, TblWeapon.WeaponName, TblWeapon.Price, TblWeapon.WeaponImg, TblWeapon.description, TblWeapon.ImgSource FROM TblWeapon WHERE(((TblWeapon.id) = " + Request.QueryString["id"] + "));";
            dsweapon = sqlweapon.testdata(stUser);
            for (int i = 0; i < int.Parse(ddlamount.SelectedItem.Text); i++)
            {
                ds = sqlUser.testdata(stUser);
                mail.Body += "<div id='f1_container' style='float:left; margin: 10px auto; width: 242px; height: 360p; border:groove; perspective: 1000px;'><div id='f1_card' style='width: 98%; height: 98%; text-align: left; transform-style: preserve-3d; transition: all 1.2s linear;'><strong id='asd' style='color:black; text-align: center; margin-left: 30%;'>" + dsweapon.Tables[0].Rows[0][2].ToString() + "</strong><hr class='style - two'/><lable style='width:22px; text-align: left; margin-right:10px; color:black;'>Price:</lable><lable name='asdd' id='TextBox' style='width:22px; margin-left:7px; color:black;'>" + dsweapon.Tables[0].Rows[0][3].ToString() + "</lable><span  dir='rtl' id='Lblname' style='margin-right:10px; float:right; color:red;'>" + dsweapon.Tables[0].Rows[0][1].ToString() + "</span><br/><span  dir='rtl' id='Lblname' style='margin-right:10px; color:black;'>" + dsweapon.Tables[0].Rows[0][5].ToString() + "</span><img id='Image' src='" + dsweapon.Tables[0].Rows[0][6].ToString() + "' style='height:205px;width:100%;border-width:0px; margin-left:3px; margin-top:23px;'/></div></div>";

            }
            mail.Body += "<p>Total sum:</p><storng>" + lblitemprice1.Text + "</storng>";
            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("silkroadpandasro@gmail.com", "19735647");
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);
            lblsucc.Visible = true;
        }
        else
        {
            lblitemprice1.Text = (int.Parse(lblitemprice1.Text) * int.Parse(ddlamount.SelectedItem.Text)).ToString();
            lblerr.Visible = true;
            lblsucc.Visible = false;
        }
    }

    protected void btncheek_Click(object sender, EventArgs e)
    {
        ServiceReference1.ServiceSoapClient dsdelcoupon = new ServiceReference1.ServiceSoapClient();
        ServiceReference1.coupon checkcoupon = new ServiceReference1.coupon();
        checkcoupon.Txtcoupon = txtcoupon.Text;
        checkcoupon.Username = Session["User"].ToString();
        if (dsdelcoupon.chkCoupon(checkcoupon.Txtcoupon, checkcoupon.Username))
        {
            lblitemprice1.Text = Math.Abs(int.Parse(ddlamount.SelectedItem.Value) * int.Parse(lblitemprice1.Text) * 0.85).ToString();
            lblcoupon.Visible = true;
            txtcoupon.Visible = true;
            btncheek.Visible = true;
            lblcosucc.Visible = true;
            Session["Coupon"] = "true";
        }
        else
        {
            Session["Coupon"] = "false";
            lblnotexist.Visible = true;
            DataSet ds1 = new DataSet();
            MySql sql1 = new MySql();
            string selectItem1 = "SELECT TblWeapon.Race, TblWeapon.WeaponName, TblWeapon.Price, TblWeapon.WeaponImg, TblWeapon.description FROM TblWeapon WHERE(((TblWeapon.id) = " + Request.QueryString["id"] + "));";
            ds1 = sql1.testdata(selectItem1);
            int amount = int.Parse(ddlamount.SelectedItem.Value);
            lblitemprice1.Text = (int.Parse(Session["price"].ToString()) * amount).ToString();
        }
    }
}