<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="UserRegistrationPortal.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        .container {
            height: 800px;
            position: relative;
            background-color: azure;
        }

        .center {
            margin: 0;
            position: absolute;
            top: 50%;
            left: 50%;
            -ms-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);
        }
    </style>
    <title>Registration Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="font-family: Arial">
            <div class="center">
                <table <%--style="margin-left: auto; margin-right: auto; margin-top: 15%;"--%>>
                    <thead>
                        <tr>
                            <td colspan="2" align="center"><b><u>Register</u></b></td>
                            <td></td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>User Name </td>
                            <td>: <asp:TextBox ID="txtUserName" runat="server" MaxLength="20"></asp:TextBox></td>
                            <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server" ForeColor="Red" Display="Dynamic"
                                ErrorMessage="User Name is required" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorUserName" runat="server" ErrorMessage="Special characters not allowed" Display="Dynamic" ForeColor="Red" ControlToValidate="txtUserNo" ValidationExpression ="[a-zA-Z0-9]{1,20}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>User No </td>
                            <td>: <asp:TextBox ID="txtUserNo" runat="server" MaxLength="4"></asp:TextBox></td>
                            <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorUserNo" runat="server" ForeColor="Red" Display="Dynamic" 
                                ErrorMessage="User No is required" ControlToValidate="txtUserNo"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorUserNo" runat="server" ErrorMessage="Only up to 4 digit number allowed" Display="Dynamic" ForeColor="Red" ControlToValidate="txtUserNo" ValidationExpression="\d{1,4}"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" /></td>
                            <td><asp:Label ID="lblStatus" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <script type="text/javascript">
            document.getElementById("txtUserName").focus();
        </script>
    </form>
</body>
</html>
