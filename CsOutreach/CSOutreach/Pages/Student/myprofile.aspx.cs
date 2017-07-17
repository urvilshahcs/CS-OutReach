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


namespace CSOutreach.Pages.Student
{
    public partial class myprofile : StudentBasePage
    {
        PersonDBManager personDBMgr = new PersonDBManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (divsuccess != null)
                divsuccess.Style["display"] = "none";
            //HtmlGenericControl diverror = Master.FindControl("BodyContent").FindControl("diverror") as HtmlGenericControl;
            if (diverror != null)
                diverror.Style["display"] = "none";

            if (!IsPostBack)
            {
                try
                {
                    List<Person> personelist = new List<Person>();
                    using (DBCSEntities entity = new DBCSEntities())
                    {
                        string userName = CSOutreach.Authentication.Username;
                        Person person = personDBMgr.GetUser(userName);
                        //Person person = personDBMgr.getStudent(username);
                        //var query = from person in entity.People
                        //            where person.Email == userName
                        //            select new { firstname = person.FirstName, lastname = person.LastName, contactnum = person.ContactNumber, email=person.Email, password=person.Password, address=person.Address};
                        First_Name.Value = person.FirstName;
                        Last_Name.Value = person.LastName;
                        Address.Value = person.Address;
                        Contact_Number.Value = person.ContactNumber;
                        Email.Value = person.Email;
                        Email.Disabled = true;

                        //Password.Value = person.Password;
                        //CPassword.Value = person.Password;

                    }




                }
                catch (Exception ex)
                {
                }
            }



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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            PersonDBManager persondb = new PersonDBManager();

            Person signup_user = new Person();
            signup_user.FirstName = First_Name.Value;
            signup_user.LastName = Last_Name.Value.Trim();
            signup_user.Address = Address.Value.Trim();
            signup_user.Email = Email.Value.Trim();
            signup_user.ContactNumber = Contact_Number.Value.Trim();
            //signup_user.Password = Password.Value;

            bool result = persondb.UpdateUserDetails(signup_user);
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

        protected void lnk_changepassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("Changepassword.aspx");
        }


    }
}

