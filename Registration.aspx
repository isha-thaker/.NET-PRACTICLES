<%@ Page Title="Registration"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Registration.aspx.cs"
    Inherits="RegistrationDemo.Registration" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="registration-box">

        <h2>Event Registration</h2>

        <asp:ValidationSummary
            ID="ValidationSummary1"
            runat="server"
            HeaderText="Please correct the following errors:"
            ForeColor="Red" />

        <!-- Full Name -->
        <div class="form-row">
            <label>Full Name</label>

            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvName"
                runat="server"
                ControlToValidate="txtName"
                ErrorMessage="Full Name is required."
                Text="*"
                ForeColor="Red">
            </asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator
                ID="revName"
                runat="server"
                ControlToValidate="txtName"
                ValidationExpression="^[A-Za-z ]{2,50}$"
                ErrorMessage="Name should contain only letters and spaces."
                Text="*"
                ForeColor="Red">
            </asp:RegularExpressionValidator>
        </div>


        <!-- Email -->
        <div class="form-row">
            <label>Email</label>

            <asp:TextBox ID="txtEmail"
                runat="server"
                TextMode="Email">
            </asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvEmail"
                runat="server"
                ControlToValidate="txtEmail"
                ErrorMessage="Email is required."
                Text="*"
                ForeColor="Red">
            </asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator
                ID="revEmail"
                runat="server"
                ControlToValidate="txtEmail"
                ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
                ErrorMessage="Enter a valid email address."
                Text="*"
                ForeColor="Red">
            </asp:RegularExpressionValidator>
        </div>


        <!-- Mobile -->
        <div class="form-row">
            <label>Mobile Number</label>

            <asp:TextBox ID="txtMobile"
                runat="server"
                MaxLength="10">
            </asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvMobile"
                runat="server"
                ControlToValidate="txtMobile"
                ErrorMessage="Mobile number is required."
                Text="*"
                ForeColor="Red">
            </asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator
                ID="revMobile"
                runat="server"
                ControlToValidate="txtMobile"
                ValidationExpression="^[6-9][0-9]{9}$"
                ErrorMessage="Enter a valid 10-digit mobile number."
                Text="*"
                ForeColor="Red">
            </asp:RegularExpressionValidator>
        </div>


        <!-- College -->
        <div class="form-row">
            <label>College</label>

            <asp:TextBox ID="txtCollege"
                runat="server">
            </asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvCollege"
                runat="server"
                ControlToValidate="txtCollege"
                ErrorMessage="College name is required."
                Text="*"
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>


        <!-- Department -->
        <div class="form-row">
            <label>Department</label>

            <asp:RadioButtonList
                ID="rblDepartment"
                runat="server">

                <asp:ListItem Value="">Select Department</asp:ListItem>
                <asp:ListItem>CSE</asp:ListItem>
                <asp:ListItem>IT</asp:ListItem>
                <asp:ListItem>ECE</asp:ListItem>
                <asp:ListItem>Mechanical</asp:ListItem>
                <asp:ListItem>Civil</asp:ListItem>

            </asp:RadioButtonList>

            <asp:CustomValidator
                ID="cvDepartment"
                runat="server"
                ErrorMessage="Please select a department."
                Text="*"
                ForeColor="Red"
                OnServerValidate="cvDepartment_ServerValidate">
            </asp:CustomValidator>
        </div>


        <!-- Event -->
        <div class="form-row">
            <label>Event</label>

            <asp:DropDownList
                ID="ddlEvent"
                runat="server">

                <asp:ListItem Text="-- Select an Event --" Value=""></asp:ListItem>
                <asp:ListItem>Hackathon</asp:ListItem>
                <asp:ListItem>Technical Quiz</asp:ListItem>
                <asp:ListItem>Web Development Workshop</asp:ListItem>
                <asp:ListItem>Coding Competition</asp:ListItem>

            </asp:DropDownList>

            <asp:RequiredFieldValidator
                ID="rfvEvent"
                runat="server"
                ControlToValidate="ddlEvent"
                InitialValue=""
                ErrorMessage="Please select an event."
                Text="*"
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>


        <!-- Gender -->
        <div class="form-row">
            <label>Gender</label>

            <asp:RadioButtonList
                ID="rblGender"
                runat="server">

                <asp:ListItem Value="">Select Gender</asp:ListItem>
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>

            </asp:RadioButtonList>

            <asp:CustomValidator
                ID="cvGender"
                runat="server"
                ErrorMessage="Please select your gender."
                Text="*"
                ForeColor="Red"
                OnServerValidate="cvGender_ServerValidate">
            </asp:CustomValidator>
        </div>


        <!-- Password -->
        <div class="form-row">
            <label>Password</label>

            <asp:TextBox
                ID="txtPassword"
                runat="server"
                TextMode="Password">
            </asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvPassword"
                runat="server"
                ControlToValidate="txtPassword"
                ErrorMessage="Password is required."
                Text="*"
                ForeColor="Red">
            </asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator
                ID="revPassword"
                runat="server"
                ControlToValidate="txtPassword"
                ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"
                ErrorMessage="Password must contain at least 8 characters, one uppercase letter, one lowercase letter and one number."
                Text="*"
                ForeColor="Red">
            </asp:RegularExpressionValidator>
        </div>


        <!-- Confirm Password -->
        <div class="form-row">
            <label>Confirm Password</label>

            <asp:TextBox
                ID="txtConfirmPassword"
                runat="server"
                TextMode="Password">
            </asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvConfirmPassword"
                runat="server"
                ControlToValidate="txtConfirmPassword"
                ErrorMessage="Please confirm your password."
                Text="*"
                ForeColor="Red">
            </asp:RequiredFieldValidator>

            <asp:CompareValidator
                ID="cvPassword"
                runat="server"
                ControlToValidate="txtConfirmPassword"
                ControlToCompare="txtPassword"
                Operator="Equal"
                Type="String"
                ErrorMessage="Password and Confirm Password must match."
                Text="*"
                ForeColor="Red">
            </asp:CompareValidator>
        </div>


        <!-- Skills -->
        <div class="form-row">
            <label>Skills</label>

            <asp:CheckBoxList
                ID="cblSkills"
                runat="server">

                <asp:ListItem>HTML</asp:ListItem>
                <asp:ListItem>CSS</asp:ListItem>
                <asp:ListItem>C#</asp:ListItem>
                <asp:ListItem>Java</asp:ListItem>
                <asp:ListItem>Python</asp:ListItem>
                <asp:ListItem>JavaScript</asp:ListItem>

            </asp:CheckBoxList>

            <asp:CustomValidator
                ID="cvSkills"
                runat="server"
                ErrorMessage="Please select at least one skill."
                Text="*"
                ForeColor="Red"
                OnServerValidate="cvSkills_ServerValidate">
            </asp:CustomValidator>
        </div>


        <!-- Address -->
        <div class="form-row">
            <label>Address</label>

            <asp:TextBox
                ID="txtAddress"
                runat="server"
                TextMode="MultiLine">
            </asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvAddress"
                runat="server"
                ControlToValidate="txtAddress"
                ErrorMessage="Address is required."
                Text="*"
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>


        <!-- Terms -->
        <div class="form-row">

            <asp:CheckBox
                ID="chkTerms"
                runat="server"
                Text=" I agree to the Terms & Conditions" />

            <asp:CustomValidator
                ID="cvTerms"
                runat="server"
                ErrorMessage="You must agree to the Terms & Conditions."
                Text="*"
                ForeColor="Red"
                OnServerValidate="cvTerms_ServerValidate">
            </asp:CustomValidator>

        </div>


        <!-- Register Button -->
        <div class="form-row">

            <asp:Button
                ID="btnRegister"
                runat="server"
                Text="Register"
                CssClass="register-button"
                OnClick="btnRegister_Click" />

        </div>


        <!-- Success Message -->
        <div class="message">

            <asp:Label
                ID="lblMessage"
                runat="server">
            </asp:Label>

        </div>

    </div>

</asp:Content>
