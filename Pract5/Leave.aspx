<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Leave.aspx.cs"
    Inherits="StudentLeave.Leave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Student Leave Management</title>

    <link href="Content/StudentLeave.css"
          rel="stylesheet" />

</head>

<body>

<form id="form1" runat="server">

    <div class="page">


        <!-- HEADER -->

        <div class="header">

            <h1>Student Leave Management</h1>

            <div class="user-area">

                Welcome,

                <asp:Label
                    ID="lblStudentName"
                    runat="server">
                </asp:Label>

                &nbsp;&nbsp;

                <asp:Button
                    ID="btnLogout"
                    runat="server"
                    Text="Logout"
                    CssClass="button small-button"
                    OnClick="btnLogout_Click" />

            </div>

        </div>


        <!-- ACADEMIC CALENDAR -->

        <div class="section">

            <h2>Academic Calendar</h2>

            <p class="note">
                Select a date from the calendar.
            </p>


            <asp:Calendar
                ID="academicCalendar"
                runat="server"
                OnDayRender="academicCalendar_DayRender"
                OnSelectionChanged="academicCalendar_SelectionChanged">
            </asp:Calendar>


            <br />


            <asp:Label
                ID="lblCalendarMessage"
                runat="server">
            </asp:Label>

        </div>


        <!-- LEAVE FORM -->

        <div class="section">

            <h2>Apply for Leave</h2>


            <!-- Leave Type -->

            <div class="form-row">

                <label>Leave Type:</label>

                <asp:DropDownList
                    ID="ddlLeaveType"
                    runat="server">

                    <asp:ListItem
                        Text="-- Select Leave Type --"
                        Value="">
                    </asp:ListItem>

                    <asp:ListItem
                        Text="Casual Leave"
                        Value="Casual Leave">
                    </asp:ListItem>

                    <asp:ListItem
                        Text="Medical Leave"
                        Value="Medical Leave">
                    </asp:ListItem>

                    <asp:ListItem
                        Text="Emergency Leave"
                        Value="Emergency Leave">
                    </asp:ListItem>

                    <asp:ListItem
                        Text="Other"
                        Value="Other">
                    </asp:ListItem>

                </asp:DropDownList>


                <asp:RequiredFieldValidator
                    ID="rfvLeaveType"
                    runat="server"
                    ControlToValidate="ddlLeaveType"
                    InitialValue=""
                    ErrorMessage="Select leave type."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>

            </div>


            <!-- From Date -->

            <div class="form-row">

                <label>From Date:</label>

                <asp:TextBox
                    ID="txtFromDate"
                    runat="server"
                    TextMode="Date">
                </asp:TextBox>


                <asp:RequiredFieldValidator
                    ID="rfvFromDate"
                    runat="server"
                    ControlToValidate="txtFromDate"
                    ErrorMessage="Select from date."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>

            </div>


            <!-- To Date -->

            <div class="form-row">

                <label>To Date:</label>

                <asp:TextBox
                    ID="txtToDate"
                    runat="server"
                    TextMode="Date">
                </asp:TextBox>


                <asp:RequiredFieldValidator
                    ID="rfvToDate"
                    runat="server"
                    ControlToValidate="txtToDate"
                    ErrorMessage="Select to date."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>

            </div>


            <!-- Reason -->

            <div class="form-row">

                <label>Reason for Leave:</label>

                <asp:TextBox
                    ID="txtReason"
                    runat="server"
                    TextMode="MultiLine"
                    Rows="4">
                </asp:TextBox>


                <asp:RequiredFieldValidator
                    ID="rfvReason"
                    runat="server"
                    ControlToValidate="txtReason"
                    ErrorMessage="Please enter the reason for leave."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>

            </div>


            <!-- Submit Button -->

            <asp:Button
                ID="btnApplyLeave"
                runat="server"
                Text="Submit Leave"
                CssClass="button"
                OnClick="btnApplyLeave_Click" />

            <br />
            <br />


            <asp:Label
                ID="lblLeaveMessage"
                runat="server"
                CssClass="message">
            </asp:Label>

        </div>


        <!-- LEAVE APPLICATIONS -->

        <div class="section">

            <h2>My Leave Applications</h2>


            <asp:GridView
                ID="gvLeaves"
                runat="server"
                AutoGenerateColumns="true"
                CssClass="leave-table">
            </asp:GridView>

        </div>


    </div>

</form>

</body>
</html>
