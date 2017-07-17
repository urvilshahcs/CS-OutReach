using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.Entity;
using System.Web.ModelBinding;
using DataOperations.DBEntity;
using DataOperations.DBEntityManager;


namespace CSOutreach.Pages.Administrator
{
    public partial class ManageStudent : System.Web.UI.Page
    {
        AdminDBManager db = new AdminDBManager();
      
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;


            ContentPlaceHolder cph = this.Master.Master.FindControl("BodyContent") as ContentPlaceHolder;
            HtmlGenericControl delsuccess = cph.FindControl("AdminContent").FindControl("delsuccess") as HtmlGenericControl;
            if (delsuccess != null)
                delsuccess.Style["display"] = "none";
            ContentPlaceHolder c = this.Master.Master.FindControl("BodyContent") as ContentPlaceHolder;
            HtmlGenericControl delcatch = c.FindControl("AdminContent").FindControl("delcatch") as HtmlGenericControl;
            if (delcatch != null)
                delcatch.Style["display"] = "none";
            
                
           
           

        }
      

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Person even = new Person();
            using (DBCSEntities entity = new DBCSEntities())
            {

              
                    var query = from person in entity.People
                                where (person.Role=="Student")&& (person.FirstName.Contains(StudentName.Value) || person.LastName.Contains(StudentName.Value))
                                select new { studentID=person.PersonId, firstname = person.FirstName, lastname = person.LastName, email = person.Email};
                    SearchStudentRepeater.DataSource = query;
                    SearchStudentRepeater.DataBind();
                
            }

           
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

            Person perobject = new Person();
            
            Button btn = (Button)sender;
            int studentid = Convert.ToInt32(btn.Attributes["value"]); 
            DataOperations.DBEntity.StudentEvent studevent = new DataOperations.DBEntity.StudentEvent();
            DataOperations.DBEntity.Event registeredevent = new DataOperations.DBEntity.Event();

            
            ContentPlaceHolder ce = this.Master.Master.FindControl("BodyContent") as ContentPlaceHolder;
            HtmlGenericControl searchdiv = ce.FindControl("AdminContent").FindControl("studentsearchdiv") as HtmlGenericControl;
            if (searchdiv != null)
                searchdiv.Style["display"] = "none";
   
            using (DBCSEntities entity = new DBCSEntities())
            {
            
                var q = from person in entity.People
                        join studentevent in entity.StudentEvents on person.PersonId equals studentevent.StudentId
                        join ev in entity.Events on studentevent.EventId equals ev.EventId
                        where person.PersonId == studentid
                        select new { studenteventID=studentevent.StudentEventId, eventname = ev.Name,startdate = ev.StartDate, starttime=ev.StartTime };

              StudentEventRepeater.DataSource = q;
              StudentEventRepeater.DataBind();
                




                

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int studeventid = Convert.ToInt32(btn.Attributes["value"]);
            try
            {
                DataOperations.DBEntity.StudentEvent studevent = new DataOperations.DBEntity.StudentEvent();
                using (DBCSEntities entity = new DBCSEntities())
                {
                    StudentEvent registration = new StudentEvent();
                    registration = (from studentevent in entity.StudentEvents
                                    where studentevent.StudentEventId == studeventid
                                    select studentevent).FirstOrDefault();



                    entity.DeleteObject(registration);
                    entity.SaveChanges();
                }
            }
                catch(Exception ex)
                {
                    ContentPlaceHolder c = this.Master.Master.FindControl("BodyContent") as ContentPlaceHolder;
                    HtmlGenericControl delcatch = c.FindControl("AdminContent").FindControl("delcatch") as HtmlGenericControl;
                    if (delcatch != null)
                        delcatch.Style["display"] = "block";

                    
                   

                }

            ContentPlaceHolder cph = this.Master.Master.FindControl("BodyContent") as ContentPlaceHolder;
            HtmlGenericControl delsuccess = cph.FindControl("AdminContent").FindControl("delsuccess") as HtmlGenericControl;
            if (delsuccess != null)
                delsuccess.Style["display"] = "block";


            }

        protected void btnAddToEvent_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int studeventid = Convert.ToInt32(btn.Attributes["value"]);
            Session["studentEventAddId"] = studeventid; 
            Server.Transfer("AddStudentToEvent.aspx", true);

        }
           
            
         

        }

    }
