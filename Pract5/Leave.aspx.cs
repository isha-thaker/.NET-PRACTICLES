using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentLeave
{
    public partial class Leave : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check whether the student is logged in.
            if (Session["StudentName"] == null)
            {
                Response.Redirect("Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }


            if (!IsPostBack)
            {
                // Display student name.
                lblStudentName.Text =
                    Session["StudentName"].ToString();


                // Display previously submitted leaves.
                LoadLeaveApplications();
            }
        }


        // =================================================
        // ACADEMIC CALENDAR
        // =================================================

        protected void academicCalendar_DayRender(
            object sender,
            DayRenderEventArgs e)
        {
            DateTime date = e.Day.Date;


            // Republic Day
            if (date.Day == 26 &&
                date.Month == 1)
            {
                e.Cell.Text +=
                    "<br />Republic Day";
            }


            // Independence Day
            if (date.Day == 15 &&
                date.Month == 8)
            {
                e.Cell.Text +=
                    "<br />Independence Day";
            }


            // Gandhi Jayanti
            if (date.Day == 2 &&
                date.Month == 10)
            {
                e.Cell.Text +=
                    "<br />Gandhi Jayanti";
            }
        }


        // =================================================
        // CALENDAR DATE SELECTION
        // =================================================

        protected void academicCalendar_SelectionChanged(
            object sender,
            EventArgs e)
        {
            DateTime selectedDate =
                academicCalendar.SelectedDate;


            lblCalendarMessage.Text =
                "Selected date: " +
                selectedDate.ToString("dd-MM-yyyy");
        }


        // =================================================
        // SUBMIT LEAVE
        // =================================================

        protected void btnApplyLeave_Click(
            object sender,
            EventArgs e)
        {
            // Check validation controls.
            if (!Page.IsValid)
            {
                return;
            }


            DateTime fromDate;
            DateTime toDate;


            // Check From Date.
            if (!DateTime.TryParse(
                txtFromDate.Text,
                out fromDate))
            {
                lblLeaveMessage.Text =
                    "Enter a valid from date.";

                return;
            }


            // Check To Date.
            if (!DateTime.TryParse(
                txtToDate.Text,
                out toDate))
            {
                lblLeaveMessage.Text =
                    "Enter a valid to date.";

                return;
            }


            // Check date order.
            if (toDate < fromDate)
            {
                lblLeaveMessage.Text =
                    "To date cannot be before from date.";

                return;
            }


            // Get existing applications from Session.
            List<LeaveApplication> leaves =
                Session["LeaveApplications"]
                as List<LeaveApplication>;


            // Create list if no applications exist.
            if (leaves == null)
            {
                leaves =
                    new List<LeaveApplication>();
            }


            // Create new leave application.
            LeaveApplication leave =
                new LeaveApplication();


            leave.StudentName =
                Session["StudentName"].ToString();


            leave.LeaveType =
                ddlLeaveType.SelectedValue;


            leave.FromDate =
                fromDate.ToString("dd-MM-yyyy");


            leave.ToDate =
                toDate.ToString("dd-MM-yyyy");


            // Store reason.
            leave.Reason =
                txtReason.Text.Trim();


            // Initially all applications are pending.
            leave.Status =
                "Pending";


            // Add the application.
            leaves.Add(leave);


            // Store the updated list in Session.
            Session["LeaveApplications"] =
                leaves;


            // Show success message.
            lblLeaveMessage.Text =
                "Leave application submitted successfully.";


            // Clear form fields.
            ClearLeaveForm();


            // Refresh GridView.
            LoadLeaveApplications();
        }


        // =================================================
        // DISPLAY LEAVE APPLICATIONS
        // =================================================

        private void LoadLeaveApplications()
        {
            List<LeaveApplication> leaves =
                Session["LeaveApplications"]
                as List<LeaveApplication>;


            if (leaves != null)
            {
                gvLeaves.DataSource = leaves;

                gvLeaves.DataBind();
            }
        }


        // =================================================
        // CLEAR FORM
        // =================================================

        private void ClearLeaveForm()
        {
            ddlLeaveType.SelectedIndex = 0;

            txtFromDate.Text = "";

            txtToDate.Text = "";

            txtReason.Text = "";
        }


        // =================================================
        // LOGOUT
        // =================================================

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear all session data
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();

            // Remove the student login cookie
            if (Request.Cookies["StudentUser"] != null)
            {
                HttpCookie cookie = new HttpCookie("StudentUser");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            // Prevent the browser from caching Leave.aspx
            Response.Cache.SetCacheability(
                System.Web.HttpCacheability.NoCache);

            Response.Cache.SetNoStore();

            Response.Cache.SetExpires(DateTime.UtcNow.AddYears(-1));

            // Go back to Login page
            Response.Redirect("Login.aspx", false);

            Context.ApplicationInstance.CompleteRequest();
        }


        // =====================================================
        // LEAVE APPLICATION CLASS
        // =====================================================

        public class LeaveApplication
        {
            public string StudentName { get; set; }

            public string LeaveType { get; set; }

            public string FromDate { get; set; }

            public string ToDate { get; set; }

            public string Reason { get; set; }

            public string Status { get; set; }
        }
    }
}
