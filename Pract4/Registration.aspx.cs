using System;
using System.Text;
using System.Web.UI.WebControls;

namespace RegistrationDemo
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Department validation
        protected void cvDepartment_ServerValidate(
            object source,
            ServerValidateEventArgs args)
        {
            args.IsValid = !string.IsNullOrEmpty(rblDepartment.SelectedValue);
        }


        // Gender validation
        protected void cvGender_ServerValidate(
            object source,
            ServerValidateEventArgs args)
        {
            args.IsValid = !string.IsNullOrEmpty(rblGender.SelectedValue);
        }


        // Skills validation
        protected void cvSkills_ServerValidate(
            object source,
            ServerValidateEventArgs args)
        {
            bool skillSelected = false;

            foreach (ListItem skill in cblSkills.Items)
            {
                if (skill.Selected)
                {
                    skillSelected = true;
                    break;
                }
            }

            args.IsValid = skillSelected;
        }


        // Terms and Conditions validation
        protected void cvTerms_ServerValidate(
            object source,
            ServerValidateEventArgs args)
        {
            args.IsValid = chkTerms.Checked;
        }


        // Register button
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Check all validation controls
            if (!Page.IsValid)
            {
                lblMessage.Text = "";
                return;
            }

            // Collect selected skills
            StringBuilder selectedSkills = new StringBuilder();

            foreach (ListItem skill in cblSkills.Items)
            {
                if (skill.Selected)
                {
                    if (selectedSkills.Length > 0)
                    {
                        selectedSkills.Append(", ");
                    }

                    selectedSkills.Append(skill.Text);
                }
            }

            // Display successful registration
            lblMessage.Text =
                "Registration successful!<br/><br/>" +
                "Name: " + Server.HtmlEncode(txtName.Text) + "<br/>" +
                "Email: " + Server.HtmlEncode(txtEmail.Text) + "<br/>" +
                "Mobile: " + Server.HtmlEncode(txtMobile.Text) + "<br/>" +
                "College: " + Server.HtmlEncode(txtCollege.Text) + "<br/>" +
                "Department: " + Server.HtmlEncode(rblDepartment.SelectedValue) + "<br/>" +
                "Event: " + Server.HtmlEncode(ddlEvent.SelectedValue) + "<br/>" +
                "Gender: " + Server.HtmlEncode(rblGender.SelectedValue) + "<br/>" +
                "Skills: " + Server.HtmlEncode(selectedSkills.ToString()) + "<br/>" +
                "Address: " + Server.HtmlEncode(txtAddress.Text);
        }
    }
}