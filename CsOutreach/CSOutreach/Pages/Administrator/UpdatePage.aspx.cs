using DataOperations.DBEntity;
using DataOperations.DBEntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CSOutreach.Pages.Administrator
{
    public partial class UpdatePage : System.Web.UI.Page
    {
        private static int eventIdtoUpdateId = 0;
        AdminDBManager db = new AdminDBManager();


        protected void Page_Load(object sender, EventArgs e)
        {
            //getting the eventId from the previous page
            if (IsPostBack)
                return;


            eventIdtoUpdateId = Convert.ToInt32(Session["EventIdPassed"]);

            //populating all the fields if the event id is not 0..........



            if (eventIdtoUpdateId != 0)
            {
                List<EventType> eventTypes = db.GetEventTypes();
                drpEventType.Items.Add("---SELECT---");
                drpEventType.AppendDataBoundItems = true;
                drpEventType.DataSource = eventTypes;
                drpEventType.DataBind();
                ListItem lst = new ListItem("OTHER", "0");
                drpEventType.Items.Add(lst);



                drpCourseType.Items.Add("---SELECT---");
                drpCourseType.AppendDataBoundItems = true;
                List<Course> courseTypes = db.GetCourseTypes();
                drpCourseType.DataSource = courseTypes;
                drpCourseType.DataBind();




                //hiding both success aand error messages....
                ContentPlaceHolder cp = this.Master.Master.FindControl("BodyContent") as ContentPlaceHolder;
                HtmlGenericControl divsuccess = cp.FindControl("AdminContent").FindControl("divsuccess") as HtmlGenericControl;
                if (divsuccess != null)
                    divsuccess.Style["display"] = "none";
                ContentPlaceHolder ce = this.Master.Master.FindControl("BodyContent") as ContentPlaceHolder;
                HtmlGenericControl diverror = ce.FindControl("AdminContent").FindControl("diverror") as HtmlGenericControl;
                if (diverror != null)
                    diverror.Style["display"] = "none";


                try
                {

                    using (DBCSEntities entity = new DBCSEntities())
                    {
                        Event even = new Event();

                        even = (from eventObject in entity.Events
                                where eventObject.EventId == eventIdtoUpdateId
                                select eventObject).FirstOrDefault();

                        txtEventName.Text = even.Name;



                        var selecteditem = (from evnt in entity.Events
                                            join et in entity.EventTypes on evnt.EventTypeId equals et.EventTypeId into InnersType
                                            from ext in InnersType.DefaultIfEmpty()
                                            where evnt.EventId == eventIdtoUpdateId
                                            select ext.TypeName).FirstOrDefault();

                        // drpEventType.SelectedValue = selecteditem;
                        drpEventType.Items.FindByText(selecteditem).Selected = true;


                        var selecteditem2 = (from evnt in entity.Events
                                             join ec in entity.Courses on evnt.CourseId equals ec.CourseId into InnersCourse
                                             from exc in InnersCourse.DefaultIfEmpty()
                                             where evnt.EventId == eventIdtoUpdateId
                                             select exc.CourseName).FirstOrDefault();

                        drpCourseType.Items.FindByText(selecteditem2).Selected = true;



                        startDate.Text = even.StartDate.ToShortDateString();
                        endDate.Text = even.EndDate.ToShortDateString();
                        starttime.Text = even.StartTime.ToString();
                        endtime.Text = even.EndTime.ToString();
                        txtLocation.Text = even.Location;
                        txtDescription.Text = even.Description;

                        even.CreatedDate = even.CreatedDate;

                        lstSelectedInstructors.DataSource = (from eventinst in entity.EventInstructors
                                                             join evntlst in entity.People on eventinst.InstructorId equals evntlst.PersonId into InnersCourse
                                                             from exc in InnersCourse.DefaultIfEmpty()
                                                             where eventinst.EventId == eventIdtoUpdateId
                                                             select exc.FirstName + " "+ exc.LastName).Distinct().ToList();

                        lstSelectedInstructors.DataBind();



                        lstInstructor.DataSource = (from instructorTemp in entity.People
                                                    join evntlst in entity.Instructors on instructorTemp.PersonId equals evntlst.InstructorId 
                                                    where instructorTemp.Role == "Instructor" || instructorTemp.Role == "Admin" && evntlst.canTeach == true
                                                    select instructorTemp.FirstName + " " + instructorTemp.LastName).Distinct().Except(from eventinst in entity.EventInstructors
                                                                                                                                                                                                                                                        join evntlst in entity.People on eventinst.InstructorId equals evntlst.PersonId into InnersCourse
                                                                                                                                                                                                                                                        from exc in InnersCourse.DefaultIfEmpty()
                                                                                                                                                                                                                                                        where eventinst.EventId == eventIdtoUpdateId
                                                                                                                                                                                                                                                        select exc.FirstName + " " + exc.LastName).ToList();
                        
                        
                        lstInstructor.DataBind();
                     

                        //even.CreatedBy = userName;
                        // bool flag;

                        //flag = true;
                        //if (flag)
                        //{
                        //    ContentPlaceHolder cp = this.Master.Master.FindControl("BodyContent") as ContentPlaceHolder;
                        //    HtmlGenericControl divsuccess = cp.FindControl("AdminContent").FindControl("divsuccess") as HtmlGenericControl;
                        //    if (divsuccess != null)
                        //        divsuccess.Style["display"] = "block";
                        //}
                    }
                }

                catch (Exception k)
                {
                    //Console.WriteLine(k.ToString());
                    //ContentPlaceHolder ce = this.Master.Master.FindControl("BodyContent") as ContentPlaceHolder;
                    //HtmlGenericControl diverror = ce.FindControl("AdminContent").FindControl("diverror") as HtmlGenericControl;
                    //if (diverror != null)
                    //    diverror.Style["display"] = "block";
                }

            }
            else
            {
                //send him back to updatepage
                Server.Transfer("UpdateEvent.aspx", true);
            }



        }

        protected void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            try
            {

                using (DBCSEntities entity = new DBCSEntities())
                {
                    Event even = new Event();
                    // get the existing event object 
                    even = (from eventObject in entity.Events
                            where eventObject.EventId == eventIdtoUpdateId
                            select eventObject).FirstOrDefault();

                   //new Event Name
                    even.Name = txtEventName.Text;

                    //new Event Type
                    String eventType = drpEventType.SelectedItem.ToString();
                    even.EventTypeId = (from per in entity.EventTypes
                                        where per.TypeName == eventType
                                        select per.EventTypeId).FirstOrDefault();

                   //new Course type
                    String courseType = drpCourseType.Text;
                    even.CourseId = (from per in entity.Courses
                                     where per.CourseName == courseType
                                     select per.CourseId).FirstOrDefault();

                    // new SartDate, StartTime, End Date and End Time....
                    even.StartDate = Convert.ToDateTime(startDate.Text);
                    even.EndDate = Convert.ToDateTime(endDate.Text);

                    even.StartTime = DateTime.Parse(starttime.Text).TimeOfDay;
                    even.EndTime = DateTime.Parse(endtime.Text).TimeOfDay;

                    even.Location = txtLocation.Text;
                    even.Description = txtDescription.Text;

                    //Update information in the table
                    even.UpdatedDate = DateTime.Today;

                    string userName = CSOutreach.Authentication.Username;
                    even.UpdatedBy = (from per in entity.People
                                      where per.Email == userName
                                      select per.PersonId).FirstOrDefault();

                    
                    //Regenerating all the event instructor entries...........

                    //first deleting all the event instructors from that event
                    var evntinstToDelete = (from evntinst in entity.EventInstructors
                                            where evntinst.EventId == eventIdtoUpdateId
                                            select evntinst).ToList();
                    foreach (EventInstructor obj in evntinstToDelete) {
                        entity.DeleteObject(obj);
                    }

                    // re entering all the instructors...........
                    foreach (var item in lstSelectedInstructors.Items) {
                        db.InsertEventInstructor(item.ToString(), even.StartDate, eventIdtoUpdateId);
                    }

                    //updating in database........
                    entity.SaveChanges();


                    Server.Transfer("UpdateEvent.aspx", true);
                }
            }
            catch (Exception k)
            {
                Console.WriteLine(k.ToString());
                ContentPlaceHolder ce = this.Master.Master.FindControl("BodyContent") as ContentPlaceHolder;
                HtmlGenericControl diverror = ce.FindControl("AdminContent").FindControl("diverror") as HtmlGenericControl;
                if (diverror != null)
                    diverror.Style["display"] = "block";
            }
        }

        protected void btnRemoveInstructor_Click(object sender, EventArgs e)
        {
            List<ListItem> selectedValues = (from item in lstSelectedInstructors.Items.Cast<ListItem>()
                                             where item.Selected
                                             select item).ToList();
            foreach (ListItem value in selectedValues)
            {
                lstSelectedInstructors.Items.Remove(value);
                lstInstructor.Items.Add(value);

            }

        }

        protected void btnAddInstructor_Click(object sender, EventArgs e)
        {
            List<ListItem> selectedValues = (from item in lstInstructor.Items.Cast<ListItem>()
                                             where item.Selected
                                             select item).ToList();
            foreach (ListItem value in selectedValues)
            {
                lstSelectedInstructors.Items.Add(value);
                lstInstructor.Items.Remove(value);

            }
        }
    }
}