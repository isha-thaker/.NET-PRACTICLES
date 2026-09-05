using System;
using System.Web;

namespace StudentLeave
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If the student is already logged in,
            // open the leave page.
            if (!IsPostBack && Session["StudentName"] != null)
            {
                Response.Redirect("Leave.aspx");
                return;
            }


            // If a username cookie already exists,
            // display the saved username.
            if (!IsPostBack &&
                Request.Cookies["StudentUser"] != null)
            {
                txtUsername.Text =
                    Request.Cookies["StudentUser"].Value;
            }
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }


            string username =
                txtUsername.Text.Trim();

            string password =
                txtPassword.Text.Trim();


            // Simple login credentials
            // for the lab practical.
            if (username == "Isha Thaker" &&
                password == "12345")
            {
                // Store student name in Session.
                Session["StudentName"] = username;


                // Create username cookie.
                HttpCookie studentCookie =
                    new HttpCookie("StudentUser");

                studentCookie.Value = username;

                studentCookie.Expires =
                    DateTime.Now.AddDays(7);

                Response.Cookies.Add(studentCookie);


                // Open leave page.
                Response.Redirect("Leave.aspx");
            }
            else
            {
                lblMessage.Text =
                    "Invalid username or password.";
            }
        }
    }
}