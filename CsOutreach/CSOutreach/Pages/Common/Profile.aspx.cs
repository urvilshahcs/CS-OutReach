using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSOutreach.Pages.Common
{
    public partial class Profile : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Master.AuthenticationRequired = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}