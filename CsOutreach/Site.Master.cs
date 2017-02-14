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
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected string getDynamicMenuContent()
        {
           // TODO: Replace this dummy content with html of the same format generated dynamically from the database.
            string sampleMenuContent = "<li class=\"dropdown\">" +
                   "<a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">Dynamic Content <span class=\"caret\"></span></a>" +
                   "<ul class=\"dropdown-menu\" role=\"menu\">" +
                     "<li><a href=\"#\">Action</a></li>" +
                     "<li><a href=\"#\">Another action</a></li>" +
                   "</ul>" +
                 "</li>";

            return sampleMenuContent;
        }

        protected string getLoginButtonText()
        {
            if (Session["username"] != null){
                return "Log Out";
            }
            return "Log In";
        }

        protected void login_ServerClick(object sender, EventArgs e){
            //TODO: Add real code (or redirect) to log in or log out as appropriate.
            if (Session["username"] == null)
            {
                Session["username"] = "user";
            }
            else
            {
                Session["username"] = null;
            }
        }
    }
}