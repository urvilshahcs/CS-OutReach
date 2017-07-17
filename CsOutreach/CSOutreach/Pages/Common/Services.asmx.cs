using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CSOutreach.Pages.Common
{
    /// <summary>
    /// Summary description for Services
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Services : System.Web.Services.WebService
    {

        public class LoginResult
        {
            public bool success { get; set; }
            public string message { get; set; }
            public bool email { get; set; }
            public bool password { get; set; }
        }

        [WebMethod]
        public LoginResult login(string username, string password)
        {
            LoginResult result = new LoginResult();

            bool success = Authentication.login(username, password);
            if (!success)
            {
                result.success = false;
                if (!Authentication.IsValidUserName)
                {
                    result.message = "Incorrect email.";
                    result.email = false;
                }
                else if (!Authentication.IsValidPassword)
                {
                    result.message = "Incorrect password.";
                    result.email = true;
                    result.password = false;
                }
            }
            else
            {
                result.success = true;
                result.message = "Logging in...";
                result.email = true;
                result.password = true;
            }

            return result;
        }
    }
}
