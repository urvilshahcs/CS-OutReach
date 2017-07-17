using CSOutreach.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSOutreach
{
    public partial class Site : System.Web.UI.MasterPage
    {

        // Child Pages should set AuthenticationRequired and AuthenticationRole in Page_PreInit
        private bool auth = false;
        public bool AuthenticationRequired { get { return auth; } set { auth = value; } }

        private Role role = Role.ANONYMOUS;
        public Role Role { get { return role; } set { role = value; } }

        public bool LoggedIn { get { return Authentication.Authenticated; } }
        public string Username
        {
            get
            {
                if (Authentication.Authenticated)
                {
                    return Authentication.Username;
                }
                return "";
            }
        }



        public bool UsernameError { get; set; }
        public bool PasswordError { get; set; }


        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsernameError = false;
                PasswordError = false;
            }

            if (AuthenticationRequired)
            {
                if (!Authentication.Authenticated
                    || !Authentication.hasRequiredRole(this.Role))
                {
                    // Save current page to optionally return once log in is completed.
                    Session["return_to_page"] = Request.Url.ToString();

                    if (Session["redirected_on_logout"] == null
                        || (Boolean)(Session["redirected_on_logout"]) == false)
                    {
                        Session["error_message"] = "You must be logged in to view that page.";
                    }
                    else
                    {
                        Session["redirected_on_logout"] = null;
                    }

                    Response.Redirect(ResolveClientUrl("~/Pages/Common/Default.aspx"));
                };
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Output page alert messages, if the exist and reset the session variables to clear message.
            if (Session["error_message"] != null)
            {
                ErrorMessage.Visible = true;
                ErrorMessage.InnerHtml = Session["error_message"].ToString();
                Session["error_message"] = null;
            }
            if (Session["warning_message"] != null)
            {
                WarningMessage.Visible = true;
                WarningMessage.InnerHtml = Session["warning_message"].ToString();
                Session["warning_message"] = null;
            }
            if (Session["info_message"] != null)
            {
                InfoMessage.Visible = true;
                InfoMessage.InnerHtml = Session["info_message"].ToString();
                Session["info_message"] = null;
            }
            if (Session["success_message"] != null)
            {
                SuccessMessage.Visible = true;
                SuccessMessage.InnerHtml = Session["success_message"].ToString();
                Session["success_message"] = null;
            }

            if (!Page.IsPostBack)
            {
                InitPage();
            }
        }

        private void InitPage()
        {
            getDynamicMenuContent();
        }
        protected string getDynamicMenuContent()
        {
            // TODO: Replace this dummy content with html of the same format generated dynamically from the database.
            //string MenuContent = MenuRender.DynamicMenu;

            // return MenuContent;
            return string.Empty;
        }

        protected void login_ServerClick(object sender, EventArgs e)
        {
            LoginFormStatusMessage.InnerHtml = String.Empty;
            LoginFormErrorMessage.InnerHtml = String.Empty;

            string error = String.Empty;

            if (inputUsername.Value.Trim() == String.Empty)
            {
                error = "<strong>Username</strong> is required.<br />";
                UsernameError = true;
            }
            if (inputPassword.Value.Trim() == String.Empty)
            {
                error += "<strong>Password</strong> is required.<br />";
                PasswordError = true;
            }

            if (error != String.Empty)
            {
                LoginFormErrorMessage.InnerHtml = error;
                return;
            }

            Role UserRole = Authentication.login(inputUsername.Value, inputPassword.Value);

            if (UserRole == Role.ANONYMOUS)
            {

                if (!Authentication.IsValidUserName)
                {
                    LoginFormErrorMessage.InnerHtml = "Incorrect user <strong>email</strong>.";
                    UsernameError = true;
                }
                else if (!Authentication.IsValidPassword)
                {
                    LoginFormErrorMessage.InnerHtml = "Incorrect <strong>password</strong>.";
                    PasswordError = true;
                }
            }
            else // if successful
            {
                //Response.Redirect(Request.Url.ToString()); // full page reload

                if (UserRole == Role.STUDENT)
                {
                    Response.Redirect("../Student/DefaultHome.aspx");
                }
                else if (UserRole == Role.ADMIN) {
                    Response.Redirect("../Administrator/Dashboard.aspx");
                }
            }
        }

        protected void logoutButton_ServerClick(object sender, EventArgs e)
        {
            // TODO: add real code to sign out
            Authentication.logout();
            Session["redirected_on_logout"] = true;
            Response.Redirect(Request.Url.ToString()); // Force full page reload
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            Authentication.reset();
        }
    }
}