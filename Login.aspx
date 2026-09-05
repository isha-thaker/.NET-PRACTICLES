<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs"
    Inherits="StudentLeave.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Student Login</title>

    <link href="Content/StudentLeave.css"
          rel="stylesheet" />

</head>

<body>

<form id="form1" runat="server">

    <div class="login-box">

        <h2>Student Login</h2>

        <p>Please enter your login details.</p>


        <!-- Username -->

        <div class="form-row">

            <label>Username:</label>

            <asp:TextBox
                ID="txtUsername"
                runat="server">
            </asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvUsername"
                runat="server"
                ControlToValidate="txtUsername"
                ErrorMessage="Enter username."
                ForeColor="Red">
            </asp:RequiredFieldValidator>

        </div>


        <!-- Password -->

        <div class="form-row">

            <label>Password:</label>

            <asp:TextBox
                ID="txtPassword"
                runat="server"
                TextMode="Password">
            </asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvPassword"
                runat="server"
                ControlToValidate="txtPassword"
                ErrorMessage="Enter password."
                ForeColor="Red">
            </asp:RequiredFieldValidator>

        </div>


        <!-- Login Button -->

        <asp:Button
            ID="btnLogin"
            runat="server"
            Text="Login"
            CssClass="button"
            OnClick="btnLogin_Click" />

        <br />
        <br />


        <!-- Error message -->

        <asp:Label
            ID="lblMessage"
            runat="server"
            ForeColor="Red">
        </asp:Label>


       

    </div>

</form>

</body>
</html>
