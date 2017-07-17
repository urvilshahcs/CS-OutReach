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
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminDBManager db = new AdminDBManager();
            
            //Get the upcomming events
            List<Event> upCommingEvents = db.GetUpcommingEvents();
            mdlEvents.DataSource = upCommingEvents;
            mdlEvents.DataBind();

            //Get the upcomming instructors on leave
            List<Person> instructors = db.GetUpcommingInstructorsOnLeave();
            mdlLeave.DataSource = instructors;
            mdlLeave.DataBind();

            //Get the current courses
            List<Course> courses = db.GetCurrentCourses();
            mdlCourses.DataSource = courses;
            mdlCourses.DataBind();
        }
    }
}