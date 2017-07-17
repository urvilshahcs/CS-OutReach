using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataOperations.DBEntityManager;
using DataOperations.DBEntity;
using CSOutreach.Pages.Student;
using System.Web.UI.HtmlControls;
using StudentEntity.CrossPageInformation;


namespace CSOutreach.Pages
{
    public partial class DefaultHome : StudentBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userid = Authentication.UserId;  /* session value of user id 10054 is for demo*/
                StudentEventDBManager studentevent = new StudentEventDBManager();

                repRegisteredEvents.DataSource = studentevent.GetStudentRegisteredEvent(userid);
                repRegisteredEvents.DataBind();
                repEventSchedule.DataSource = studentevent.GetStudentRegisteredEvent(userid);
                repEventSchedule.DataBind();
                repUpcomingEvents.DataSource = studentevent.GetUpcomingEvents(userid).Take(3);
                repUpcomingEvents.DataBind();
                if (!studentevent.IsPaperWorkComplete(userid))
                {
                    ltrlPaperWorkComplete.Text = "Paper work not complete";
                }
            }
        }
       
        protected void repEventSchedule_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltrltimings = e.Item.FindControl("ltrlTimings") as Literal;
                Literal ltrlLocation = e.Item.FindControl("ltrlLocation") as Literal;
                Literal ltrlDate = e.Item.FindControl("ltrlDate") as Literal;
                HtmlAnchor lnkEventName = e.Item.FindControl("lnkEventName") as HtmlAnchor;
                CrossPageEventDetails EventSpecifics = new CrossPageEventDetails();
                EventSpecifics.AlreadyRegistered = true;
                this.CrossPageInformation = EventSpecifics;
                lnkEventName.HRef = "../Student/EventDetails.aspx?eventid=" + DataBinder.Eval(e.Item.DataItem, "EventId").ToString();
            
                try
                {
                    ltrltimings.Text = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "StartTime", "{0}")).TimeOfDay + " - " + DataBinder.Eval(e.Item.DataItem, "EndTime", "{0}").ToString();
                    ltrlLocation.Text = DataBinder.Eval(e.Item.DataItem, "Location").ToString();
                    ltrlDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "StartDate")).ToString("MMM dd, yyyy");
                }

                catch (Exception ex)
                {
                }
            }
        
        }

        protected void repRegisteredEvents_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlAnchor lnkName = e.Item.FindControl("lnkName") as HtmlAnchor;
                CrossPageEventDetails EventSpecifics = new CrossPageEventDetails();
                EventSpecifics.AlreadyRegistered = true;
                this.CrossPageInformation = EventSpecifics;
                lnkName.HRef ="../Student/EventDetails.aspx?eventid=" +DataBinder.Eval(e.Item.DataItem, "EventId").ToString();
            }
        }

        protected void repUpcomingEvents_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {


            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlAnchor lnkUpcomingEventName = e.Item.FindControl("lnkUpcomingEventName") as HtmlAnchor;
                
                lnkUpcomingEventName.HRef = "../Student/EventDetails.aspx?eventid=" + DataBinder.Eval(e.Item.DataItem, "EventId").ToString();
            }

        }

        

    }
}