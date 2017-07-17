using DataOperations.DBEntity;
using DataOperations.DBEntityManager;
using StudentEntity.CrossPageInformation;
using StudentEntity.PageTraversal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSOutreach.Pages.Student
{

    //This page temporarily inherits System.Web.UI.page as against StudentBasePage
    public partial class DetailedEventsListing : StudentBasePage
    {
        private CrossPageDetailedEventsListing CrossPageInfo;

        StudentDBManager StudentDB;
        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
        }


        private void Initialize()
        {
            StudentDB = new StudentDBManager();
            if (!IsPostBack)
            {
                //Temporarily disabled for demo purpose
                //  CrossPageInfo = this.CrossPageInformation as CrossPageDetailedEventsListing;

                RenderPageData();
               
               
            }

        }



        private List<Course> ApplicableCourses
        {
            get
            {


                List<Course> FilteredCourses = new List<Course>();
                int StudentLevel = this.StudentLevel;
                ObjectSet<Course> AllCourses = StudentDB.AllCourses;
                foreach (Course CourseElement in AllCourses)
                {
                    if (CourseElement.CourseLevel <= StudentLevel)
                    {
                        if (!FilteredCourses.Contains(CourseElement))
                        {
                            FilteredCourses.Add(CourseElement);
                        }
                    }
                }

                return FilteredCourses;
            }
        }

        private List<Event> ApplicableEvents
        {
            get
            {
                List<Event> FilteredEvents = new List<Event>();
                
                    foreach (Event EventElement in SelectedCourse.Events)
                    {
                        bool EventFound = false;
                        foreach (StudentEvent StudentEventElement in this.StudentEvents)
                        {
                            if (StudentEventElement.EventId == EventElement.EventId)
                            {
                                EventFound = true;
                                break;
                            }
                        }
                        if (!EventFound)
                        {
                            FilteredEvents.Add(EventElement);
                        }
                    }
                
                return FilteredEvents;
            }
        }


        private void RenderPageData()
        {
           
        
           
           foreach(Course CourseItem in ApplicableCourses)
           {
               CourseFilterList.Items.Add(CourseItem.CourseName +" - "+CourseItem.CourseId);
           }
            if(CourseFilterList.Items.Count>0)
            {
                CourseFilterList.Items[0].Selected = true;
                SelectedCourse = ApplicableCourses[0];
            }

            RenderEventDetails();
        }

        private void RenderEventDetails()
        {
            DataTable EventListingsTable = new DataTable();
            EventListingsTable.Columns.Add("EventNo");
            EventListingsTable.Columns.Add("EventName");
            EventListingsTable.Columns.Add("EventStartDate");
            EventListingsTable.Columns.Add("EventStartTime");
            EventListingsTable.Columns.Add("EventID");
            int Count = 0;
            foreach (Event EventData in ApplicableEvents)
            {
                ++Count;
                DataRow Drow = EventListingsTable.NewRow();
                Drow[0] = Count.ToString();
                Drow[1] = EventData.Name;
                Drow[2] = EventData.StartDate.ToString("MM-dd-yyyy");
                Drow[3] = EventData.StartTime.ToString(@"hh\:mm");
                Drow[4] = EventData.EventId.ToString();
                EventListingsTable.Rows.Add(Drow);
            }
            EventDetailsRepeater.DataSource = EventListingsTable;
            EventDetailsRepeater.DataBind();
        }


        protected void EventDetailsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            RepeaterItem SelectedItem = e.Item;
            Button SelectedButton = (Button)e.CommandSource;
            Label EventIDLabel = SelectedItem.FindControl("EventID") as Label;
            switch (SelectedButton.Text)
            {
                case "Register":

                    int SelectedEventID = Int32.Parse(EventIDLabel.Text);
                    CrossPageEventRegistration EventRegistrationParameters = new CrossPageEventRegistration();
                    EventRegistrationParameters.RegistrationEventID = SelectedEventID;
                    this.CrossPageInformation = EventRegistrationParameters;
                    Response.Redirect(TraverseManager.GetPage(PageData.EventRegistration));
                    break;
                case "Details":
                    CrossPageEventDetails EventSpec = new CrossPageEventDetails();
                    EventSpec.AlreadyRegistered = false;
                    this.CrossPageInformation = EventSpec;
                    Response.Redirect(TraverseManager.GetPage(PageData.EventDetails) + "?eventid=" + EventIDLabel.Text);
                    break;
            }
        }

        private Course SelectedCourse
        {
            get;
            set;
        }

        protected void CourseFilterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SelectedIndex = CourseFilterList.SelectedIndex;
            SelectedCourse = ApplicableCourses[SelectedIndex];
            RenderEventDetails();
        }
       


    }
}