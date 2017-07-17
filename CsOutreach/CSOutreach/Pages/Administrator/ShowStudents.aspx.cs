using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Web.ModelBinding;
using DataOperations.DBEntity;
using DataOperations.DBEntityManager;

namespace CSOutreach.Pages.Administrator
{
    public partial class ShowStudents : System.Web.UI.Page
    {
        AdminDBManager db = new AdminDBManager();
        private static int eventIdtoShowStudents = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            eventIdtoShowStudents = Convert.ToInt32(Session["EventIdPassed"]);
            
         
            Person even = new Person();
            using (DBCSEntities entity = new DBCSEntities())
            {
                

           

                var selecteditem = (from stuEvnt in entity.StudentEvents
                                    join per in entity.People on stuEvnt.StudentId equals per.PersonId into InnersType
                                    from ext in InnersType.DefaultIfEmpty()
                                    where stuEvnt.EventId == eventIdtoShowStudents
                                    select  new { firstname = ext.FirstName, lastname = ext.LastName, email = ext.Email });
                
                
                ShowStudentsRepeater.DataSource = selecteditem;
                ShowStudentsRepeater.DataBind();

            }

        }
    }
}