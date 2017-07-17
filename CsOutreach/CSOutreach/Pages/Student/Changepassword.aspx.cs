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
using System.Web.ModelBinding;
using DataOperations.DBEntity;
using DataOperations.DBEntityManager;

namespace CSOutreach.Pages.Student
{
    public partial class WebForm1 : StudentBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (divsuccess != null)
                divsuccess.Style["display"] = "none";
            //HtmlGenericControl diverror = Master.FindControl("BodyContent").FindControl("diverror") as HtmlGenericControl;
            if (diverror != null)
                diverror.Style["display"] = "none";

            if (divmismatch != null)
                divmismatch.Style["display"] = "none";


        }
        static string hashvaluepassword, emailId;
        protected void btn_update_Click(object sender, EventArgs e)
        {
            
            int up = 0;
            PersonDBManager personDBMgr = new PersonDBManager();
            try
            {
                List<Person> personelist = new List<Person>();
                using (DBCSEntities entity = new DBCSEntities())
                {
                    string userName = CSOutreach.Authentication.Username;
                    Person person = personDBMgr.GetUser(userName);
                    hashvaluepassword = person.Password;
                    emailId = person.Email;
                    //Password.Value = person.Password;
                    //CPassword.Value = person.Password;

                }
            }
            catch (Exception ex)
            {
            }

            if (personDBMgr.Encrypt(txt_cpassword.Text) == hashvaluepassword)
            {
                    up = 1;
            }
            if (up == 1)
            {
                
                
                Person password_user = new Person();
                password_user.Password = txt_npassword.Text;
                password_user.Email = emailId;
                bool result = personDBMgr.UpdateUserPassword(password_user);
                if (result == true)
                {
                    if (divsuccess != null)
                        divsuccess.Style["display"] = "block";
                }
                else
                {
                    if (diverror != null)
                        diverror.Style["display"] = "block";
                }

            }
            else
            {
                if (divmismatch != null)
                    divmismatch.Style["display"] = "block";
               
            }
        }
    }
}