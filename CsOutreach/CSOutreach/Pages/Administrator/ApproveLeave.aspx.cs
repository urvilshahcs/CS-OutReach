
using DataOperations.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal; 
using System.Threading; 
using System.Web.UI.HtmlControls; 
using System.Data.Entity;
using System.Web.ModelBinding;  
using DataOperations.DBEntityManager;


namespace CSOutreach.Pages.Administrator
{
    public partial class ApproveLeave : System.Web.UI.Page


    {                 
        AdminDBManager db = new AdminDBManager();
        
        protected void Page_Load(object sender, EventArgs e) 
        {
            bool flag = false;
            ContentPlaceHolder cp = this.Master.Master.FindControl("BodyContent") as ContentPlaceHolder;
            
            HtmlGenericControl hidden_label = cp.FindControl("AdminContent").FindControl("hidden_label") as HtmlGenericControl;
            hidden_label.Style["display"] = "none";
                        
            HtmlGenericControl hidden_label2 = cp.FindControl("AdminContent").FindControl("hidden_label2") as HtmlGenericControl;
            hidden_label2.Style["display"] = "none";
                        
            EventInstructor eventInstructor = new EventInstructor();
            DataOperations.DBEntity.Instructor instructor = new DataOperations.DBEntity.Instructor();
            DataOperations.DBEntity.Event even = new DataOperations.DBEntity.Event();

            if (!IsPostBack)
            {
                using (DBCSEntities entity = new DBCSEntities())
                {

                    {
                        var query = from eventInstructorTemp in entity.EventInstructors
                                    join person in entity.People on
                                        eventInstructorTemp.InstructorId equals person.PersonId
                                    where eventInstructorTemp.LeaveApplied == true
                                    select new
                                    {
                                        evInsId = eventInstructorTemp.EventInstructorId,
                                        evId = eventInstructorTemp.EventId,
                                        instrFname = person.FirstName,
                                        instrLname = person.LastName,
                                        date = eventInstructorTemp.Date,
                                        leaveApplied = eventInstructorTemp.LeaveApplied
                                    };

                        
                        LeaveApplicationsRepeater.DataSource = query;
                        LeaveApplicationsRepeater.DataBind();
                        
                        int n= query.Count();
                        if(n == 0)
                        {
                            hidden_label.Style["display"] = "block";
                        }

                    }
                    
                                        

                }
            }
        }

        protected void butnAccept_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem aItem in LeaveApplicationsRepeater.Items)
            {
                CheckBox chkEventInstructor = (CheckBox)aItem.FindControl("chkbox");
                if (chkEventInstructor.Checked)
                {
                    db.UpdateLeaveApplicationsApprove(Convert.ToInt32(chkEventInstructor.Attributes["value"]));
                }
            }
                        
            ContentPlaceHolder cp = this.Master.Master.FindControl("BodyContent") as ContentPlaceHolder;
            HtmlGenericControl hidden_label2 = cp.FindControl("AdminContent").FindControl("hidden_label2") as HtmlGenericControl;
            hidden_label2.Style["display"] = "block";
            
        }
                
    }
}