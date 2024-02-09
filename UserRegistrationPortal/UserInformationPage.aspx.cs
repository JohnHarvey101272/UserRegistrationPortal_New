using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserRegistrationPortal
{
    public partial class UserInformationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridViewData();
            }
        }

        private void BindGridViewData()
        {
            gvUserInformation.DataSource = UserDataAccessLayer.GetAllUsers();
            gvUserInformation.DataBind();
        }

        private void BindGridViewDataWithSort(string sortColumn)
        {
            gvUserInformation.DataSource = UserDataAccessLayer.GetAllUsers(sortColumn);
            gvUserInformation.DataBind();
        }

        protected void gvUserInformation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                gvUserInformation.EditIndex = rowIndex;
                BindGridViewData();
            }
            else if (e.CommandName == "DeleteRow")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                int original_UserId = Convert.ToInt32(e.CommandArgument);
                string original_UserName = ((Label)gvUserInformation.Rows[rowIndex].FindControl("lblUserName")).Text;
                int original_UserNo = Convert.ToInt32(((Label)gvUserInformation.Rows[rowIndex].FindControl("lblUserNo")).Text);

                UserDataAccessLayer.DeleteUser(original_UserId, original_UserName, original_UserNo);
                this.BindGridViewData();
            }
            else if (e.CommandName == "CancelUpdate")
            {
                gvUserInformation.EditIndex = -1;
                BindGridViewData();
            }
            else if (e.CommandName == "UpdateRow")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                int original_UserId = Convert.ToInt32(e.CommandArgument);
                //string original_UserName = ((Label)gvUserInformation.Rows[rowIndex].FindControl("lblUserName")).Text;
                //int original_UserNo = Convert.ToInt32(((Label)gvUserInformation.Rows[rowIndex].FindControl("lblUserNo")).Text);
                string UserName = ((TextBox)gvUserInformation.Rows[rowIndex].FindControl("txtUserName")).Text;
                int UserNo = Convert.ToInt32(((TextBox)gvUserInformation.Rows[rowIndex].FindControl("txtUserNo")).Text);
                DateTime CreateDate = Convert.ToDateTime(((TextBox)gvUserInformation.Rows[rowIndex].FindControl("txtCreateDate")).Text);

                UserDataAccessLayer.UpdateUser(original_UserId, UserName, UserNo, CreateDate);

                gvUserInformation.EditIndex = -1;
                BindGridViewData();
            }
        }

        protected void gvUserInformation_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string sortField = string.Empty;

            SortGridView((GridView)sender, e, out sortDirection, out sortField);
            string strSortDirection = sortDirection == SortDirection.Ascending ? "ASC" : "DESC";

            //BindGridViewData();
            gvUserInformation.DataSource = UserDataAccessLayer.GetAllUsers(e.SortExpression + " " + strSortDirection);
            gvUserInformation.DataBind();
        }

        private void SortGridView(GridView gridView, GridViewSortEventArgs e, out SortDirection sortDirection, out string sortField)
        {
            sortField = e.SortExpression;
            sortDirection = e.SortDirection;

            if (gridView.Attributes["CurrentSortField"] != null && gridView.Attributes["CurrentSortDirection"] != null)
            {
                if (sortField == gridView.Attributes["CurrentSortField"])
                {
                    if (gridView.Attributes["CurrentSortDirection"] == "ASC")
                    {
                        sortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        sortDirection = SortDirection.Ascending;
                    }
                }

                gridView.Attributes["CurrentSortField"] = sortField;
                gridView.Attributes["CurrentSortDirection"] = (sortDirection == SortDirection.Ascending ? "ASC" : "DESC");
            }
        }
    }
}