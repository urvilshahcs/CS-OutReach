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
    public partial class AddStudentToEvent : System.Web.UI.Page
    {
        private static int studentIdToBeAdded = 0;
        AdminDBManager db = new AdminDBManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            //getting student Id....
            studentIdToBeAdded = Convert.ToInt32(Session["studentEventAddId"]);

            ///Rest of initialization...........
            List<EventType> eventTypes = new List<EventType>();
            drpEventName.Items.Add("---SELECT---");
            drpEventName.AppendDataBoundItems = true;
            eventTypes = db.GetEventTypes();
            drpEventName.DataSource = eventTypes;
            drpEventName.DataBind();


            List<Course> courseTypes = new List<Course>();
            drpCourseName.Items.Add("---SELECT---");
            drpCourseName.AppendDataBoundItems = true;
            courseTypes = db.GetCourseTypes();
            drpCourseName.DataSource = courseTypes;
            drpCourseName.DataBind();



        }

        

        protected void addStudentToEvent_Click(object sender, EventArgs e)
        {
           foreach (RepeaterItem aItem in addStudentToEventRepeater.Items)
            {
                CheckBox chkInstructor = (CheckBox)aItem.FindControl("checkbx");
                if (chkInstructor.Checked)
                {
                    int i = Convert.ToInt32(chkInstructor.Attributes["value"]);
                    i++;
                    db.addStudentToEventAdmin(Convert.ToInt32(chkInstructor.Attributes["value"]), studentIdToBeAdded);
                }
            }

        }

        protected void btnSearchEvents_Click(object sender, EventArgs e)
        {
            try
            {

                using (DBCSEntities entity = new DBCSEntities())
                {
                    //Creating global eventObject..
                    Event even = new Event();

                    //Checking if user has selected any filters or not....
                    String instructorText = null, locationText = null, eventTypeText = null, courseTypeText = null;
                    even.CourseId = 0;
                    int InstructorId = 0;
                    even.EventTypeId = 0;

                    if (!(drpEventName.SelectedItem.Text.Equals("---SELECT---")))
                    {
                        eventTypeText = drpEventName.SelectedItem.Text;
                        even.EventTypeId = (from per in entity.EventTypes
                                            where per.TypeName == eventTypeText
                                            select per.EventTypeId).FirstOrDefault();
                    }
                    if (!(drpCourseName.SelectedItem.Text.Equals("---SELECT---")))
                    {
                        courseTypeText = drpCourseName.SelectedItem.Text;
                        even.CourseId = (from per in entity.Courses
                                         where per.CourseName == courseTypeText
                                         select per.CourseId).FirstOrDefault();
                    }
                    if (!(Instructor.Value.Equals("")))
                    {
                        instructorText = Instructor.ToString();
                        InstructorId = (from per in entity.People
                                        where per.FirstName.Contains(Instructor.Value) || per.LastName.Contains(Instructor.Value)
                                        select per.PersonId).First();

                    }
                    if (!(Location.Value.Equals("")))
                    {
                        locationText = Location.Value;
                    }





                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



                    //0000
                    if (even.EventTypeId == 0 && even.CourseId == 0 && InstructorId == 0 && locationText == null)
                    {
                        var q = (from evnt in entity.Events
                                 join et in entity.EventTypes on evnt.EventTypeId equals et.EventTypeId into InnersType
                                 from ext in InnersType.DefaultIfEmpty()
                                 join ec in entity.Courses on evnt.CourseId equals ec.CourseId into InnersCourse
                                 from exc in InnersCourse.DefaultIfEmpty()
                                 select new { id = evnt.EventId, name = evnt.Name, eventTypeName = ext.TypeName, eventCourseName = exc.CourseName, sDate = evnt.StartDate, sTime = evnt.StartTime, eDate = evnt.EndDate, eTime = evnt.EndTime, locationTextname = evnt.Location });
                        addStudentToEventRepeater.DataSource = q;
                        addStudentToEventRepeater.DataBind();

                    }
                    //0001
                    else if (even.EventTypeId == 0 && even.CourseId == 0 && InstructorId == 0 && locationText != null)
                    {

                        var q = (from evnt in entity.Events
                                 join et in entity.EventTypes on evnt.EventTypeId equals et.EventTypeId into InnersType
                                 from ext in InnersType.DefaultIfEmpty()
                                 join ec in entity.Courses on evnt.CourseId equals ec.CourseId into InnersCourse
                                 from exc in InnersCourse.DefaultIfEmpty()
                                 where evnt.Location.Contains(locationText)
                                 select new { id = evnt.EventId, name = evnt.Name, eventTypeName = ext.TypeName, eventCourseName = exc.CourseName, sDate = evnt.StartDate, sTime = evnt.StartTime, eDate = evnt.EndDate, eTime = evnt.EndTime, locationTextname = evnt.Location });
                        addStudentToEventRepeater.DataSource = q;
                        addStudentToEventRepeater.DataBind();
                    }
                    //0010
                    else if (even.EventTypeId == 0 && even.CourseId == 0 && InstructorId != 0 && locationText == null)
                    {


                        var q = (from evnt in entity.Events
                                 join et in entity.EventTypes on evnt.EventTypeId equals et.EventTypeId into InnersType
                                 from ext in InnersType.DefaultIfEmpty()
                                 join ec in entity.Courses on evnt.CourseId equals ec.CourseId into InnersCourse
                                 from exc in InnersCourse.DefaultIfEmpty()
                                 join ei in entity.EventInstructors on evnt.EventId equals ei.EventId into Inners
                                 from exi in Inners.DefaultIfEmpty()
                                 where exi.InstructorId == InstructorId
                                 select new { id = evnt.EventId, name = evnt.Name, eventTypeName = ext.TypeName, eventCourseName = exc.CourseName, sDate = evnt.StartDate, sTime = evnt.StartTime, eDate = evnt.EndDate, eTime = evnt.EndTime, locationTextname = evnt.Location });
                        addStudentToEventRepeater.DataSource = q;
                        addStudentToEventRepeater.DataBind();



                    }
                    //0011
                    else if (even.EventTypeId == 0 && even.CourseId == 0 && InstructorId != 0 && locationText != null)
                    {
                        var q = (from evnt in entity.Events
                                 join et in entity.EventTypes on evnt.EventTypeId equals et.EventTypeId into InnersType
                                 from ext in InnersType.DefaultIfEmpty()
                                 join ec in entity.Courses on evnt.CourseId equals ec.CourseId into InnersCourse
                                 from exc in InnersCourse.DefaultIfEmpty()
                                 join ei in entity.EventInstructors on evnt.EventId equals ei.EventId into Inners
                                 from exi in Inners.DefaultIfEmpty()
                                 where exi.InstructorId == InstructorId && evnt.Location.Contains(locationText)
                                 select new { id = evnt.EventId, name = evnt.Name, eventTypeName = ext.TypeName, eventCourseName = exc.CourseName, sDate = evnt.StartDate, sTime = evnt.StartTime, eDate = evnt.EndDate, eTime = evnt.EndTime, locationTextname = evnt.Location });
                        addStudentToEventRepeater.DataSource = q;
                        addStudentToEventRepeater.DataBind();


                    }
                    //0100
                    else if (even.EventTypeId == 0 && even.CourseId != 0 && InstructorId == 0 && locationText == null)
                    {

                        var q = (from evnt in entity.Events
                                 join et in entity.EventTypes on evnt.EventTypeId equals et.EventTypeId into InnersType
                                 from ext in InnersType.DefaultIfEmpty()
                                 join ec in entity.Courses on evnt.CourseId equals ec.CourseId into InnersCourse
                                 from exc in InnersCourse.DefaultIfEmpty()
                                 where evnt.CourseId == even.CourseId
                                 select new { id = evnt.EventId, name = evnt.Name, eventTypeName = ext.TypeName, eventCourseName = exc.CourseName, sDate = evnt.StartDate, sTime = evnt.StartTime, eDate = evnt.EndDate, eTime = evnt.EndTime, locationTextname = evnt.Location });
                        addStudentToEventRepeater.DataSource = q;
                        addStudentToEventRepeater.DataBind();





                    }
                    //0101
                    else if (even.EventTypeId == 0 && even.CourseId != 0 && InstructorId == 0 && locationText != null)
                    {


                        var q = (from evnt in entity.Events
                                 join et in entity.EventTypes on evnt.EventTypeId equals et.EventTypeId into InnersType
                                 from ext in InnersType.DefaultIfEmpty()
                                 join ec in entity.Courses on evnt.CourseId equals ec.CourseId into InnersCourse
                                 from exc in InnersCourse.DefaultIfEmpty()
                                 where evnt.CourseId == even.CourseId && evnt.Location.Contains(locationText)
                                 select new { id = evnt.EventId, name = evnt.Name, eventTypeName = ext.TypeName, eventCourseName = exc.CourseName, sDate = evnt.StartDate, sTime = evnt.StartTime, eDate = evnt.EndDate, eTime = evnt.EndTime, locationTextname = evnt.Location });
                        addStudentToEventRepeater.DataSource = q;
                        addStudentToEventRepeater.DataBind();


                    }
                    //0110
                    else if (even.EventTypeId == 0 && even.CourseId != 0 && InstructorId != 0 && locationText == null)
                    {

                        var q = (from evnt in entity.Events
                                 join et in entity.EventTypes on evnt.EventTypeId equals et.EventTypeId into InnersType
                                 from ext in InnersType.DefaultIfEmpty()
                                 join ec in entity.Courses on evnt.CourseId equals ec.CourseId into InnersCourse
                                 from exc in InnersCourse.DefaultIfEmpty()
                                 join ei in entity.EventInstructors on evnt.EventId equals ei.EventId into Inners
                                 from exi in Inners.DefaultIfEmpty()
                                 where evnt.CourseId == even.CourseId && exi.InstructorId == InstructorId
                                 select new { id = evnt.EventId, name = evnt.Name, eventTypeName = ext.TypeName, eventCourseName = exc.CourseName, sDate = evnt.StartDate, sTime = evnt.StartTime, eDate = evnt.EndDate, eTime = evnt.EndTime, locationTextname = evnt.Location });
                        addStudentToEventRepeater.DataSource = q;
                        addStudentToEventRepeater.DataBind();
                    }
                    //0111
                    else if (even.EventTypeId == 0 && even.CourseId != 0 && InstructorId != 0 && locationText != null)
                    {

                        var q = (from evnt in entity.Events
                                 join et in entity.EventTypes on evnt.EventTypeId equals et.EventTypeId into InnersType
                                 from ext in InnersType.DefaultIfEmpty()
                                 join ec in entity.Courses on evnt.CourseId equals ec.CourseId into InnersCourse
                                 from exc in InnersCourse.DefaultIfEmpty()
                                 join ei in entity.EventInstructors on evnt.EventId equals ei.EventId into Inners
                                 from exi in Inners.DefaultIfEmpty()
                                 where evnt.CourseId == even.CourseId && exi.InstructorId == InstructorId && evnt.Location.Contains(locationText)
                                 select new { id = evnt.EventId, name = evnt.Name, eventTypeName = ext.TypeName, eventCourseName = exc.CourseName, sDate = evnt.StartDate, sTime = evnt.StartTime, eDate = evnt.EndDate, eTime = evnt.EndTime, locationTextname = evnt.Location });
                        addStudentToEventRepeater.DataSource = q;
                        addStudentToEventRepeater.DataBind();
                    }
                    //1000
                    else if (even.EventTypeId != 0 && even.CourseId == 0 && InstructorId == 0 && locationText == null)
                    {

                        var q = (from evnt in entity.Events
                                 join et in entity.EventTypes on evnt.EventTypeId equals et.EventTypeId into InnersType
                                 from ext in InnersType.DefaultIfEmpty()
                                 join ec in entity.Courses on evnt.CourseId equals ec.CourseId into InnersCourse
                                 from exc in InnersCourse.DefaultIfEmpty()
                                 where evnt.EventTypeId == even.EventTypeId
                                 select new { id = evnt.EventId, name = evnt.Name, eventTypeName = ext.TypeName, eventCourseName = exc.CourseName, sDate = evnt.StartDate, sTime = evnt.StartTime, eDate = evnt.EndDate, eTime = evnt.EndTime, locationTextname = evnt.Location });
                        addStudentToEventRepeater.DataSource = q;
                        addStudentToEventRepeater.DataBind();


                    }
                    //1001
                    else if (even.EventTypeId != 0 && even.CourseId == 0 && InstructorId == 0 && locationText != null)
                    {
                        var q = (from evnt in entity.Events
                                 join et in entity.EventTypes on evnt.EventTypeId equals et.EventTypeId into InnersType
                                 from ext in InnersType.DefaultIfEmpty()
                                 join ec in entity.Courses on evnt.CourseId equals ec.CourseId into InnersCourse
                                 from exc in InnersCourse.DefaultIfEmpty()
                                 where evnt.EventTypeId == even.EventTypeId && evnt.Location.Contains(locationText)
                                 select new { id = evnt.EventId, name = evnt.Name, eventTypeName = ext.TypeName, eventCourseName = exc.CourseName, sDate = evnt.StartDate, sTime = evnt.StartTime, eDate = evnt.EndDate, eTime = evnt.EndTime, locationTextname = evnt.Location });
                        addStudentToEventRepeater.DataSource = q;
                        addStudentToEventRepeater.DataBind();
                    }
                    //1010
                    else if (even.EventTypeId != 0 && even.CourseId == 0 && InstructorId != 0 && locationText == null)
                    {

                        var q = (from evnt in entity.Events
                                 join et in entity.EventTypes on evnt.EventTypeId equals et.EventTypeId into InnersType
                                 from ext in InnersType.DefaultIfEmpty()
                                 join ec in entity.Courses on evnt.CourseId equals ec.CourseId into InnersCourse
                                 from exc in InnersCourse.DefaultIfEmpty()
                                 join ei in entity.EventInstructors on evnt.EventId equals ei.EventId into Inners
                                 from exi in Inners.DefaultIfEmpty()
                                 where evnt.EventTypeId == even.EventTypeId && exi.InstructorId == InstructorId
                                 select new { id = evnt.EventId, name = evnt.Name, eventTypeName = ext.TypeName, eventCourseName = exc.CourseName, sDate = evnt.StartDate, sTime = evnt.StartTime, eDate = evnt.EndDate, eTime = evnt.EndTime, locationTextname = evnt.Location });
                        addStudentToEventRepeater.DataSource = q;
                        addStudentToEventRepeater.DataBind();
                    }
                    //1011
                    else if (even.EventTypeId != 0 && even.CourseId == 0 && InstructorId != 0 && locationText != null)
                    {

                        var q = (from evnt in entity.Events
                                 join et in entity.EventTypes on evnt.EventTypeId equals et.EventTypeId into InnersType
                                 from ext in InnersType.DefaultIfEmpty()
                                 join ec in entity.Courses on evnt.CourseId equals ec.CourseId into InnersCourse
                                 from exc in InnersCourse.DefaultIfEmpty()
                                 join ei in entity.EventInstructors on evnt.EventId equals ei.EventId into Inners
                                 from exi in Inners.DefaultIfEmpty()
                                 where evnt.EventTypeId == even.EventTypeId && exi.InstructorId == InstructorId && evnt.Location.Contains(locationText)
                                 select new { id = evnt.EventId, name = evnt.Name, eventTypeName = ext.TypeName, eventCourseName = exc.CourseName, sDate = evnt.StartDate, sTime = evnt.StartTime, eDate = evnt.EndDate, eTime = evnt.EndTime, locationTextname = evnt.Location });
                        addStudentToEventRepeater.DataSource = q;
                        addStudentToEventRepeater.DataBind();
                    }
                    //1100
                    else if (even.EventTypeId != 0 && even.CourseId != 0 && InstructorId == 0 && locationText == null)
                    {

                        var q = (from evnt in entity.Events
                                 join et in entity.EventTypes on evnt.EventTypeId equals et.EventTypeId into InnersType
                                 from ext in InnersType.DefaultIfEmpty()
                                 join ec in entity.Courses on evnt.CourseId equals ec.CourseId into InnersCourse
                                 from exc in InnersCourse.DefaultIfEmpty()
                                 join ei in entity.EventInstructors on evnt.EventId equals ei.EventId into Inners
                                 from exi in Inners.DefaultIfEmpty()
                                 where evnt.EventTypeId == even.EventTypeId && evnt.CourseId == even.CourseId
                                 select new { id = evnt.EventId, name = evnt.Name, eventTypeName = ext.TypeName, eventCourseName = exc.CourseName, sDate = evnt.StartDate, sTime = evnt.StartTime, eDate = evnt.EndDate, eTime = evnt.EndTime, locationTextname = evnt.Location });
                        addStudentToEventRepeater.DataSource = q;
                        addStudentToEventRepeater.DataBind();


                    }
                    //1101
                    else if (even.EventTypeId != 0 && even.CourseId != 0 && InstructorId == 0 && locationText != null)
                    {

                        var q = (from evnt in entity.Events
                                 join et in entity.EventTypes on evnt.EventTypeId equals et.EventTypeId into InnersType
                                 from ext in InnersType.DefaultIfEmpty()
                                 join ec in entity.Courses on evnt.CourseId equals ec.CourseId into InnersCourse
                                 from exc in InnersCourse.DefaultIfEmpty()
                                 where evnt.EventTypeId == even.EventTypeId && evnt.CourseId == even.CourseId && evnt.Location.Contains(locationText)
                                 select new { id = evnt.EventId, name = evnt.Name, eventTypeName = ext.TypeName, eventCourseName = exc.CourseName, sDate = evnt.StartDate, sTime = evnt.StartTime, eDate = evnt.EndDate, eTime = evnt.EndTime, locationTextname = evnt.Location });
                        addStudentToEventRepeater.DataSource = q;
                        addStudentToEventRepeater.DataBind();

                    }
                    //1110
                    else if (even.EventTypeId != 0 && even.CourseId != 0 && InstructorId != 0 && locationText == null)
                    {

                        var q = (from evnt in entity.Events
                                 join et in entity.EventTypes on evnt.EventTypeId equals et.EventTypeId into InnersType
                                 from ext in InnersType.DefaultIfEmpty()
                                 join ec in entity.Courses on evnt.CourseId equals ec.CourseId into InnersCourse
                                 from exc in InnersCourse.DefaultIfEmpty()
                                 join ei in entity.EventInstructors on evnt.EventId equals ei.EventId into Inners
                                 from exi in Inners.DefaultIfEmpty()
                                 where evnt.EventTypeId == even.EventTypeId && evnt.CourseId == even.CourseId && exi.InstructorId == InstructorId
                                 select new { id = evnt.EventId, name = evnt.Name, eventTypeName = ext.TypeName, eventCourseName = exc.CourseName, sDate = evnt.StartDate, sTime = evnt.StartTime, eDate = evnt.EndDate, eTime = evnt.EndTime, locationTextname = evnt.Location });
                        addStudentToEventRepeater.DataSource = q;
                        addStudentToEventRepeater.DataBind();

                    }
                    //1111
                    else if (even.EventTypeId != 0 && even.CourseId != 0 && InstructorId != 0 && locationText != null)
                    {

                        var q = (from evnt in entity.Events
                                 join et in entity.EventTypes on evnt.EventTypeId equals et.EventTypeId into InnersType
                                 from ext in InnersType.DefaultIfEmpty()
                                 join ec in entity.Courses on evnt.CourseId equals ec.CourseId into InnersCourse
                                 from exc in InnersCourse.DefaultIfEmpty()
                                 join ei in entity.EventInstructors on evnt.EventId equals ei.EventId into Inners
                                 from exi in Inners.DefaultIfEmpty()
                                 where evnt.EventTypeId == even.EventTypeId && evnt.CourseId == even.CourseId && exi.InstructorId == InstructorId && evnt.Location.Contains(locationText)
                                 select new { id = evnt.EventId, name = evnt.Name, eventTypeName = ext.TypeName, eventCourseName = exc.CourseName, sDate = evnt.StartDate, sTime = evnt.StartTime, eDate = evnt.EndDate, eTime = evnt.EndTime, locationTextname = evnt.Location });
                        addStudentToEventRepeater.DataSource = q;
                        addStudentToEventRepeater.DataBind();

                    }



                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////











                }//end of using.........

            }//end of try.......
            catch (Exception k)
            {
                Console.WriteLine(k.ToString());
                ContentPlaceHolder ce = this.Master.Master.FindControl("BodyContent") as ContentPlaceHolder;
                HtmlGenericControl diverror = ce.FindControl("AdminContent").FindControl("diverror") as HtmlGenericControl;
                if (diverror != null)
                    diverror.Style["display"] = "block";
            }
        }
    }
}