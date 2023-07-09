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

public partial class YanivProject_Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        lblcosucc.Visible = false;
        lblnotexist.Visible = false;
        lblerr.Visible = false;
        lblsucc.Visible = false;
        pnlCheckout.Visible = false;
        if (!IsPostBack)
        {
            //get userid
            MySql sqlusid = new MySql();
            DataSet dsusid = new DataSet();
            string stusid = "SELECT TblUser.[ID] FROM TblUser WHERE(((TblUser.[UserName]) ='" + Session["User"] + "'));";
            dsusid = sqlusid.testdata(stusid);
            Session["Userid"] = dsusid.Tables[0].Rows[0][0].ToString();
            //show items on gridview
            MySql sqlcart1 = new MySql();
            DataSet dscart1 = new DataSet();
            string stcart1 = "SELECT TblShoppingCart.Weaponimg, TblShoppingCart.ProtuctID, TblShoppingCart.Price, TblShoppingCart.OrderId,TblShoppingCart.Amount FROM TblShoppingCart WHERE(((TblShoppingCart.UserId) =" + Session["Userid"] + "));";
            dscart1 = sqlcart1.testdata(stcart1);
            grdCart.DataSource = dscart1.Tables[0];
            grdCart.DataBind();
            if (dscart1.Tables[0].Rows.Count > 0)
            {
                Session["ProudctId"] = dscart1.Tables[0].Rows[0][1].ToString();
            }
            for (int i = 0; i < grdCart.Rows.Count; i++)
            {
                grdCart.HeaderRow.Cells[7].Visible = false;
                grdCart.Rows[i].Cells[7].Visible = false;
                grdCart.HeaderRow.Cells[3].Visible = false;
                grdCart.Rows[i].Cells[3].Visible = false;
            }
            DataSet ds = new DataSet();
            MySql sql = new MySql();
            string selectItem = "SELECT Sum(TblShoppingCart.Price) AS SumOfPrice FROM TblShoppingCart GROUP BY TblShoppingCart.UserId HAVING(((TblShoppingCart.UserId) =" + Session["Userid"] + "));";
            ds = sql.testdata(selectItem);
            btn.Visible = false;
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblempty.Visible = false;
                btn.Visible = true;
                lbltotalprice.Text = ds.Tables[0].Rows[0][0].ToString();
                Session["Price"] = lbltotalprice.Text;
            }
            if (Session["Ispurchase"] != null && ds.Tables[0].Rows.Count == 0)
            {
                lblsucc.Visible = true;
                pnlCheckout.Visible = true;
                lbltotalprice.Text = "0";
            }
            else
            {
                pnlCheckout.Visible = false;
            }
        }
    }
    protected void grdCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int row = e.RowIndex;
        MySql sqlDel = new MySql();
        string ID = grdCart.Rows[row].Cells[6].Text;
        string stDel = "DELETE TblShoppingCart.OrderId, TblShoppingCart.UserId, TblShoppingCart.ProtuctID, TblShoppingCart.Weaponimg, TblShoppingCart.Price  FROM TblShoppingCart WHERE(((TblShoppingCart.OrderId) =" + ID + "));";
        sqlDel.updelin(stDel);
        Response.Redirect("Cart.aspx");
    }

    protected void grdCart_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        grdCart.PageIndex = e.NewPageIndex;
        //show items on gridview
        MySql sqlcart1 = new MySql();
        DataSet dscart1 = new DataSet();
        string stcart1 = "SELECT TblShoppingCart.Weaponimg, TblShoppingCart.ProtuctID, TblShoppingCart.Price, TblShoppingCart.OrderId,TblShoppingCart.Amount FROM TblShoppingCart WHERE(((TblShoppingCart.UserId) =" + Session["Userid"] + "));";
        dscart1 = sqlcart1.testdata(stcart1);
        grdCart.DataSource = dscart1.Tables[0];
        grdCart.DataBind();
        for (int i = 0; i < grdCart.Rows.Count; i++)
        {
            grdCart.HeaderRow.Cells[7].Visible = false;
            grdCart.Rows[i].Cells[7].Visible = false;
            grdCart.HeaderRow.Cells[3].Visible = false;
            grdCart.Rows[i].Cells[3].Visible = false;
        }
    }

    protected void btn_Click(object sender, EventArgs e)
    {
        pnlCheckout.Visible = true;
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
                lblnotexist.Visible = true;
                lbltotalprice.Text =Session["Price"].ToString();
                ServiceReference1.ServiceSoapClient dsdelcoupon = new ServiceReference1.ServiceSoapClient();
                ServiceReference1.coupon DeleteCoupon = new ServiceReference1.coupon();
                DeleteCoupon.Txtcoupon = txtcoupon.Text;
                DeleteCoupon.Username = Session["User"].ToString();
                dsdelcoupon.DeleteCoupon(DeleteCoupon.Txtcoupon, DeleteCoupon.Username);
            }
            lblsucc.Visible = true;
            pnlCheckout.Visible = true;
            MySql sqlcart1 = new MySql();
            DataSet dscart1 = new DataSet();
            string stcart1 = "SELECT TblShoppingCart.Weaponimg, TblShoppingCart.ProtuctID, TblShoppingCart.Price, TblShoppingCart.OrderId FROM TblShoppingCart WHERE(((TblShoppingCart.UserId) =" + Session["Userid"] + "));";
            dscart1 = sqlcart1.testdata(stcart1);
            string time = DateTime.Now.ToLongTimeString();
            for (int i = 0; i < dscart1.Tables[0].Rows.Count; i++)
            {
                Session["ProudctId"] = dscart1.Tables[0].Rows[i][1].ToString();
                //insert to tblorder
                MySql sqliOrder = new MySql();
                DataSet dsiOrder = new DataSet();
                string stiOrder = "insert into TblOrder(UserId, CardNumber, OrderTime, Phone, Email, VisaHolder, ExpiredDated, CVC, TotalOrderAmount, ProtuctID) values(" + Session["Userid"] + ",'" + txtvisa.Text + "', '" + time + "', '" + Session["phone"] + "', '" + Session["UserEmail"] + "','" + txtVisaholder.Text + "','" + txtexpiredate.Text + "','" + txtCVC.Text + "','" + lbltotalprice.Text + "','" + Session["ProudctId"] + "')";
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
                string stisubOrder = "insert into TblSubOrder(OrderId, ProudctId, OrderAmount) values(" + Session["OrderId"] + ",'" + Session["ProudctId"] + "', '" + lbltotalprice.Text + "')";
                sqlisubOrder.updelin(stisubOrder);
            }
            //delete from cart
            MySql sqldfsc = new MySql();
            DataSet dsdfsc = new DataSet();
            string stdfsc = "DELETE TblShoppingCart.UserId, TblShoppingCart.ProtuctID, TblShoppingCart.Weaponimg, TblShoppingCart.Price, TblShoppingCart.OrderId FROM TblShoppingCart WHERE(((TblShoppingCart.UserId) =" + Session["Userid"] + "));";
            sqldfsc.updelin(stdfsc);
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
            for (int i = 0; i < dscart1.Tables[0].Rows.Count; i++)
            {
                string stUser = "SELECT TblWeapon.id, TblWeapon.Race, TblWeapon.WeaponName, TblWeapon.Price, TblWeapon.WeaponImg, TblWeapon.description, TblWeapon.ImgSource FROM TblWeapon WHERE(((TblWeapon.id) = " + dscart1.Tables[0].Rows[i][1].ToString() + "));";
                ds = sqlUser.testdata(stUser);
                mail.Body += "<div id='f1_container" + i + "' style='float:left; margin: 10px auto; width: 242px; height: 360p; border:groove; perspective: 1000px;'><div id='f1_card" + i + "' style='width: 98%; height: 98%; text-align: left; transform-style: preserve-3d; transition: all 1.2s linear;'><strong id='asd " + i + "' style='color:black; text-align: center; margin-left: 30%;'>" + ds.Tables[0].Rows[0][2].ToString() + "</strong><hr class='style - two" + i + "'/><lable style='width:22px; text-align: left; margin-right:10px; color:black;'>Price:</lable><lable name='asdd' id='TextBox" + i + "' style='width:22px; margin-left:7px; color:black;'>" + ds.Tables[0].Rows[0][3].ToString() + "</lable><span  dir='rtl' id='Lblname" + i + "' style='margin-right:10px; float:right; color:red;'>" + ds.Tables[0].Rows[0][1].ToString() + "</span><br/><span  dir='rtl' id='Lblname" + i + "' style='margin-right:10px; color:black;'>" + ds.Tables[0].Rows[0][5].ToString() + "</span><img id='Image" + i + "' src='" + ds.Tables[0].Rows[0][6].ToString() + "' style='height:205px;width:100%;border-width:0px; margin-left:3px; margin-top:23px;'/></div></div>";

            }
            mail.Body += "<p>Total sum:</p><storng>" + lbltotalprice.Text + "</storng>";
            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("silkroadpandasro@gmail.com", "19735647");
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);
            Session["Ispurchase"] = "purchasesucc".ToString();
            Response.Redirect("Cart.aspx");
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

    protected void ddlamount_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Name"), new DataColumn("Country") });
        foreach (GridViewRow row in grdCart.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlamount = row.Cells[3].FindControl("ddlamount") as DropDownList;
                Image image = row.Cells[1].FindControl("img") as Image;
                string img = image.ImageUrl.ToString();
                img = img.Substring(18);
                DataSet ds = new DataSet();
                MySql sql = new MySql();
                string selectItem = "SELECT TblWeapon.Price, TblWeapon.[ID] FROM TblWeapon WHERE(((TblWeapon.WeaponImg) ='"+img+"'));";
                ds = sql.testdata(selectItem);
                row.Cells[5].Text = (int.Parse(ddlamount.SelectedItem.Text) * int.Parse(ds.Tables[0].Rows[0][0].ToString())).ToString();
                MySql sqlcart1 = new MySql();
                string stcart1 = "UPDATE TblShoppingCart SET TblShoppingCart.Price = '" + row.Cells[5].Text + "', TblShoppingCart.Amount = '" + ddlamount.SelectedItem.Text.ToString() + "', TblShoppingCart.ProtuctID = " + ds.Tables[0].Rows[0][1].ToString() + " WHERE(((TblShoppingCart.OrderId) =" + row.Cells[6].Text + "));";
                sqlcart1.updelin(stcart1);
                //get userid
                MySql sqlusid = new MySql();
                DataSet dsusid = new DataSet();
                string stusid = "SELECT TblUser.[ID] FROM TblUser WHERE(((TblUser.[UserName]) ='" + Session["User"] + "'));";
                dsusid = sqlusid.testdata(stusid);
                Session["Userid"] = dsusid.Tables[0].Rows[0][0].ToString();
                //show items on gridview
                MySql sqlcart2 = new MySql();
                DataSet dscart2 = new DataSet();
                string stcart2 = "SELECT TblShoppingCart.Weaponimg, TblShoppingCart.ProtuctID, TblShoppingCart.Price, TblShoppingCart.OrderId,TblShoppingCart.Amount FROM TblShoppingCart WHERE(((TblShoppingCart.UserId) =" + Session["Userid"] + "));";
                dscart2 = sqlcart2.testdata(stcart2);
                grdCart.DataSource = dscart2.Tables[0];
                grdCart.DataBind();
                for (int i = 0; i < grdCart.Rows.Count; i++)
                {
                    grdCart.HeaderRow.Cells[7].Visible = false;
                    grdCart.Rows[i].Cells[7].Visible = false;
                    grdCart.HeaderRow.Cells[3].Visible = false;
                    grdCart.Rows[i].Cells[3].Visible = false;
                }
                DataSet ds2 = new DataSet();
                MySql sql2 = new MySql();
                string selectItem2 = "SELECT Sum(TblShoppingCart.Price) AS SumOfPrice FROM TblShoppingCart GROUP BY TblShoppingCart.UserId HAVING(((TblShoppingCart.UserId) =" + Session["Userid"] + "));";
                ds2 = sql2.testdata(selectItem2);
                btn.Visible = false;
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    lblempty.Visible = false;
                    btn.Visible = true;
                    lbltotalprice.Text = ds2.Tables[0].Rows[0][0].ToString();
                    Session["Price"] = lbltotalprice.Text;
                }
                if (Session["Ispurchase"] != null && ds2.Tables[0].Rows.Count == 0)
                {
                    lblsucc.Visible = true;
                    pnlCheckout.Visible = true;
                    lbltotalprice.Text = "0";
                }
                else
                {
                    pnlCheckout.Visible = false;
                }
            }

        }
    }
}