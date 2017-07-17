using DataOperations.DBEntity;
using DataOperations.DBEntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CSOutreach.Pages.Common
{
    public partial class Signup : System.Web.UI.Page
    {
        public const string ROLENAME = "Student";  //setting to student when registering for first time
        public const bool ISLOCKED = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            //To hide the success and error messages initially
            HtmlGenericControl divsuccess = Master.FindControl("BodyContent").FindControl("divsuccess") as HtmlGenericControl;
            if (divsuccess != null)
                divsuccess.Style["display"] = "none";
            HtmlGenericControl diverror = Master.FindControl("BodyContent").FindControl("diverror") as HtmlGenericControl;
            if (diverror != null)
                diverror.Style["display"] = "none";


        }

        /// <summary>
        /// Check User Id exist or Not in database.
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <returns></returns>
        [WebMethod()]
        public static bool CheckUserExists(string userName)
        {
            try
            {
                PersonDBManager user = new PersonDBManager();
                Person personDetails = new Person();
                personDetails = user.GetUser(userName.Trim());
                if (personDetails == null)
                    return true;
            }
            catch (Exception e)
            {
            }
            return false;
        }
        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            PersonDBManager persondb = new PersonDBManager();

            Person signup_user = new Person();
            signup_user.FirstName = FirstName.Value.Trim();
            signup_user.LastName = LastName.Value.Trim();
            signup_user.Address = Address1.Value.Trim().Replace("'", "''") + Address2.Value.Trim().Replace("'", "''") + City.Value.Trim() + State.Value.Trim() + Zip.Value.Trim();
            signup_user.ContactNumber = PhoneAreaCode.Value.Trim() + PhoneFirstPart.Value.Trim() + PhoneSecondPart.Value.Trim();
            signup_user.Email = Email.Value.Trim();
            signup_user.Password = Password.Value.Trim();
            signup_user.Role = ROLENAME;
            signup_user.IsLocked = ISLOCKED;

            bool result = persondb.AddNewUserDetails(signup_user);
            if (result == true)
            {
                HtmlGenericControl divsuccess = Master.FindControl("BodyContent").FindControl("divsuccess") as HtmlGenericControl;
                if (divsuccess != null)
                    divsuccess.Style["display"] = "block";
            }
            else
            {
                HtmlGenericControl diverror = Master.FindControl("BodyContent").FindControl("diverror") as HtmlGenericControl;
                if (diverror != null)
                    diverror.Style["display"] = "block";
            }
            ClearValues();
        }
        protected void ClearValues()
        {
            //Clear all the textboxes.
            foreach (Control ctrl in Master.FindControl("BodyContent").Controls)
            {
                if (ctrl.GetType().Name == "HtmlInputText")
                {
                    ((HtmlInputText)ctrl).Value = string.Empty;
                }
            }
        }
       
    }
}