using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;


using DataOperations.DBEntity;
using DataOperations.DBEntityManager;
using StudentEntity.CrossPageInformation;
using StudentEntity.PageTraversal;

namespace CSOutreach.Pages.Student
{
    public partial class EventRegistration : StudentBasePage
    {
        EventDBManager eventDBMgr = new EventDBManager();
        PersonDBManager personDBMgr = new PersonDBManager();
        StudentDBManager studentDBMgr = new StudentDBManager();
        StudentEventDBManager studEventDBMgr = new StudentEventDBManager();
        CrossPageEventRegistration crossEventData;
        Person loggedInStudent;
        DataOperations.DBEntity.Student student;
        Event selectedEvent;
        StudentEvent studentEvent;

        /// <summary>
        /// Method to load data to the page
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        protected void Page_Load(object sender, EventArgs e)
        {
            EventRegistration eventReg = new EventRegistration();
            if (!IsPostBack)
            {
                Page.Title = "Event Registration";
                this.crossEventData = this.CrossPageInformation as CrossPageEventRegistration;
                
                studentEvent = new StudentEvent();

                // Get student details from session
                string username = (string)HttpContext.Current.Session[Authentication.SessionVariable.USERNAME.ToString()];
                // Call DB to get the student details
                loggedInStudent = personDBMgr.GetUser(username);
                
                // Setup values in the screen
                if (loggedInStudent != null)
                {
                    FirstName.Value = loggedInStudent.FirstName;
                    LastName.Value = loggedInStudent.LastName;
                }
                // Get Student details from DB
                student = studentDBMgr.GetStudent(loggedInStudent.PersonId);
                if (student != null)
                {
                    EmergConName.Value = student.EmergencyName;
                    EmergConRelation.Value = student.EmergencyRelation;
                    EmergPhoneArea.Value = student.EmergencyNumber.Substring(0, 3);
                    EmergPhoneFirst.Value = student.EmergencyNumber.Substring(3, 3);
                    EmergPhoneSecond.Value = student.EmergencyNumber.Substring(6, 4);
                }

                // Get Selected Event details from DB                
                selectedEvent = eventDBMgr.GetSelectedEventDetails(this.crossEventData.RegistrationEventID);            
                if (selectedEvent != null)
                {
                    EventTitle.Text = selectedEvent.Name;
                    EventType.Text = selectedEvent.EventType.TypeName;
                    EventTime.Text = selectedEvent.StartDate.Add(selectedEvent.StartTime).ToString();                   
                }

                conflictsRepeater.DataSource = eventReg.getEventConflicts(loggedInStudent.PersonId, selectedEvent);
                conflictsRepeater.DataBind();

                List<Event> eventsList = studEventDBMgr.GetStudentRegisteredEvent(loggedInStudent.PersonId);
                List<Event> preReqEventsList = eventReg.getEventPrerequisites(loggedInStudent.PersonId, selectedEvent);
                preReqRepeater.DataSource = preReqEventsList;
                preReqRepeater.DataBind();

            }
            
        }


        /// <summary>
        /// Method to get the event Conflicts
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        private List<Event> getEventConflicts(int userID, Event selectedEvent)
        {

            List<Event> eventsList = studEventDBMgr.GetStudentRegisteredEvent(userID);
            List<Event> conflictEventsList = new List<Event>();

            if (eventsList != null)
            {
                foreach (Event eventItem in eventsList) // Loop through List with foreach
                {

                    if (selectedEvent.StartDate.Ticks > eventItem.StartDate.Ticks && selectedEvent.StartDate.Ticks < eventItem.EndDate.Ticks)
                    {
                        if ((selectedEvent.StartTime.Ticks > eventItem.StartTime.Ticks && selectedEvent.StartTime.Ticks < eventItem.EndTime.Ticks) ||
                            (selectedEvent.EndTime.Ticks > eventItem.StartTime.Ticks && selectedEvent.EndTime.Ticks < eventItem.EndTime.Ticks))                       
                        {
                            conflictEventsList.Add(eventItem);
                        }
                        
                    }
                    else if (selectedEvent.EndDate.Ticks > eventItem.StartDate.Ticks && selectedEvent.EndDate.Ticks < eventItem.EndDate.Ticks)
                    {
                        if ((selectedEvent.StartTime.Ticks > eventItem.StartTime.Ticks && selectedEvent.StartTime.Ticks < eventItem.EndTime.Ticks) ||
                            (selectedEvent.EndTime.Ticks > eventItem.StartTime.Ticks && selectedEvent.EndTime.Ticks < eventItem.EndTime.Ticks))
                        {
                            conflictEventsList.Add(eventItem);
                        }
                    }

                }
            }

            return conflictEventsList;
        }

        /// <summary>
        /// Method to get the event Prerequisites
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        private List<Event> getEventPrerequisites(int userID, Event selectedEvent)
        {
            List<Event> eventsList = studEventDBMgr.GetEventPrereq(userID, selectedEvent);
            if (eventsList != null)
            {
                foreach (Event eventItem in eventsList) // Loop through List with foreach
                {
                    Console.WriteLine();
                    //Process if needed
                }
            }
            return eventsList;
        }

        /// <summary>
        /// Method to register the event to the user
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        protected void registerEvent(object sender, EventArgs e)
        {
            Boolean statusFlag = false;
            this.crossEventData = this.CrossPageInformation as CrossPageEventRegistration;
            // Get student details from session
            string username = (string)HttpContext.Current.Session[Authentication.SessionVariable.USERNAME.ToString()];
            // Call DB to get the student details
            loggedInStudent = personDBMgr.GetUser(username);
            selectedEvent = eventDBMgr.GetSelectedEventDetails(this.crossEventData.RegistrationEventID);            
            studentEvent = new StudentEvent();
    
            if (loggedInStudent != null && selectedEvent != null)
            {
                studentEvent.StudentId = loggedInStudent.PersonId;
                studentEvent.EventId = selectedEvent.EventId;
                studentEvent.RegistrationDate = DateTime.Now;
                statusFlag = studEventDBMgr.RegisterEvent(studentEvent);
            }
            if (statusFlag)
            {
                Response.Redirect("DefaultHome.aspx");                
            }
            else
            {
                // Show error
            }
        }
     

        /// <summary>
        /// Method to check if the student emergency details are already present, if not add the details
        /// </summary>
        /// <param name="studentData">JSON Data of User Emergency Information</param>
        /// <returns></returns>
        [WebMethod()]
        public static bool isEmergDataAvailable(DataOperations.DBEntity.Student studentData)
        {
            try
            {
                StudentDBManager studentDBMgr = new StudentDBManager();
                int userID = (int) HttpContext.Current.Session[Authentication.SessionVariable.USERID.ToString()];                
                DataOperations.DBEntity.Student student = studentDBMgr.GetStudent(userID);
                if (student == null)
                {
                    // User is not present, add the student and the emergency details
                    student = new DataOperations.DBEntity.Student();
                    student.StudentId = userID;
                    student.EmergencyName = studentData.EmergencyName;
                    student.EmergencyRelation = studentData.EmergencyRelation;
                    student.EmergencyNumber = studentData.EmergencyNumber;                   
                    return studentDBMgr.addStudent(student);
                }
                else
                {
                    // User is present , Update the emergency details
                    student = new DataOperations.DBEntity.Student();
                    student.EmergencyName = studentData.EmergencyName;
                    student.EmergencyRelation = studentData.EmergencyRelation;
                    student.EmergencyNumber = studentData.EmergencyNumber;
                    return studentDBMgr.addStudent(student);
                }                    
            }
            catch (Exception e)
            {
            }
            return false;
        }     
    }
}