<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInformationPage.aspx.cs" Inherits="UserRegistrationPortal.UserInformationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Information Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family: Arial">
                <asp:GridView ID="gvUserInformation" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="UserID" EmptyDataText="No records has been added." OnRowCommand="gvUserInformation_RowCommand" AllowSorting="true" OnSorting="gvUserInformation_Sorting" CurrentSortField="UserID" CurrentSortDirection="ASC" >
                    <Columns>
                        <asp:TemplateField HeaderText="UserID" InsertVisible="False" SortExpression="UserID">
                            <EditItemTemplate>
                                <asp:Label ID="lblUserId" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblUserId" runat="server" Text='<%# Bind("UserID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UserName" SortExpression="UserName">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server" ErrorMessage="UserName is a required field" ForeColor="Red" Text="*" ControlToValidate="txtUserName">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorUserName" runat="server" ErrorMessage="Special characters not allowed" ForeColor="Red" Text="*" ControlToValidate="txtUserNo" ValidationExpression="[a-zA-Z0-9]{1,20}$"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UserNo" SortExpression="UserNo">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtUserNo" runat="server" Text='<%# Bind("UserNo") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserNo" runat="server" ErrorMessage="UserNo is a required field" ForeColor="Red" Text="*" ControlToValidate="txtUserNo">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorUserNo" runat="server" ErrorMessage="Only up to 4 digit number allowed for UserNo" Text="*" ForeColor="Red" ControlToValidate="txtUserNo" ValidationExpression="\d{1,4}"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblUserNo" runat="server" Text='<%# Bind("UserNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CreateDate" InsertVisible="False" SortExpression="CreateDate" >
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCreateDate" runat="server" Text='<%# Bind("CreateDate","{0:G}") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCreateDate" runat="server" ErrorMessage="CreateDate is a required field" ForeColor="Red" Text="*" ControlToValidate="txtCreateDate">
                                </asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCreateDate" runat="server" Text='<%# Bind("CreateDate","{0:G}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbEdit" CommandArgument='<%# Eval("UserId") %>' CommandName="EditRow" ForeColor="#8C4510" runat="server">Edit</asp:LinkButton>
                                <asp:LinkButton ID="lbDelete" CommandArgument='<%# Eval("UserId") %>' CommandName="DeleteRow" ForeColor="#8C4510" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this row');">Delete</asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="lbUpdate" CommandArgument='<%# Eval("UserId") %>' CommandName="UpdateRow" ForeColor="#8C4510" runat="server">Update</asp:LinkButton>
                                <asp:LinkButton ID="lbCancel" CommandArgument='<%# Eval("UserId") %>' CommandName="CancelUpdate" ForeColor="#8C4510" runat="server" CausesValidation="false">Cancel</asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle ForeColor="#003399" HorizontalAlign="Left" BackColor="#99CCCC" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                <br />
                <br />
                <asp:HyperLink ID="HyperLink1" NavigateUrl="~/RegisterPage.aspx" Text="Create New User" runat="server"></asp:HyperLink>
                <br />
            </div>
    </form>
</body>
</html>
