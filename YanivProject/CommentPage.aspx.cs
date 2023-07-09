using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class YanivProject_CommentPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        txtDate.Text = DateTime.Now.ToString();
        MySql sqlComments = new MySql();
        DataSet dsComments = new DataSet();
        string stComments = "SELECT tblComment.ID, tblComment.Mail, tblComment.CommentDate, tblComment.CommentType, tblComment.CommentContent FROM tblComment;";
        dsComments = sqlComments.testdata(stComments);
        grdComments.DataSource = dsComments.Tables[0];
        grdComments.DataBind();

    }

    protected void ddlCommentsType_SelectedIndexChanged(object sender, EventArgs e)
    {
        MySql sqlComments = new MySql();
        DataSet dsComments = new DataSet();
        string stComments = "SELECT tblComment.ID, tblComment.Mail, tblComment.CommentDate, tblComment.CommentContent FROM tblComment WHERE(((tblComment.CommentType) ='" + ddlCommentsType.SelectedItem.Value + "'));";
        dsComments = sqlComments.testdata(stComments);
        grdComments.DataSource = dsComments.Tables[0];
        grdComments.DataBind();
        if(ddlCommentsType.SelectedItem.Value== "בחר סוג תגובה")
        {
            MySql sqlComments1 = new MySql();
            DataSet dsComments1 = new DataSet();
            string stComments1 = "SELECT tblComment.ID, tblComment.Mail, tblComment.CommentDate, tblComment.CommentType, tblComment.CommentContent FROM tblComment;";
            dsComments1 = sqlComments1.testdata(stComments1);
            grdComments.DataSource = dsComments1.Tables[0];
            grdComments.DataBind();
        }
    }

    protected void grdComments_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        int row = e.RowIndex;
        MySql sqlDel = new MySql();
        string ID = grdComments.Rows[row].Cells[1].Text;
        MySql sqlid = new MySql();
        string stid = "DELETE tblComment.ID, tblComment.Mail, tblComment.CommentDate, tblComment.CommentType, tblComment.CommentContent FROM tblComment WHERE(((tblComment.ID) ="+ID+"));";
        sqlid.updelin(stid);
        Response.Redirect("CommentPage.aspx");
    }
}