//This page holds the authentication of all student pages.

using DataOperations.DBEntity;
using DataOperations.DBEntityManager;
using StudentEntity.PageTraversal;
using StudentEntity.Session;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CSOutreach.Pages.Student
{
    public class StudentBasePage : Page
    {

        protected override void OnInit(EventArgs e)
        {
            if (!AuthenticateUser())
            {
                LogOffUser();
            }
        }

        private bool AuthenticateUser()
        {
            if (Session[Authentication.SessionVariable.USERNAME.ToString()] != null)
            {
                if (Session[Authentication.SessionVariable.ROLE.ToString()].ToString().CompareTo(Role.STUDENT.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void LogOffUser()
        {
            Response.Redirect(TraverseManager.GetPage(PageData.LoginPage));
        }

        /*This property can be used to store intermediate informations across page transitions. View 
         * "DetailedEventsListing.cs page for example usage
         * */
        protected object CrossPageInformation
        {
            get
            {
                return Session[StudentSession.CROSS_PAGE_INFORMATION] as object;
            }
            set
            {
                Session[StudentSession.CROSS_PAGE_INFORMATION] = value;
            }
        }

        protected Person StudentDetails
        {
            get
            {
                string ID = Session[Authentication.SessionVariable.USERNAME.ToString()].ToString();
                PersonDBManager StudentPerson = new PersonDBManager();
                return StudentPerson.GetUser(ID);
            }
        }

        protected List<StudentEvent> StudentEvents
        {
            get
            {

                StudentDBManager StudentDB = new StudentDBManager();
                List<StudentEvent> StudentEvents = new List<StudentEvent>();
                object StudentEventsDetail = (from StudentEventElement in StudentDB.AllStudentEvents
                                                                      where StudentEventElement.StudentId == this.StudentDetails.PersonId
                                                                      select StudentEventElement);
                ObjectQuery<StudentEvent> StudentEventsDataRaw = StudentEventsDetail as ObjectQuery<StudentEvent>;
                foreach(StudentEvent StudentEventsData in StudentEventsDataRaw )
                {
                    StudentEvents.Add(StudentEventsData);
                }
                return StudentEvents;

            }
        }

        protected List<Course> StudentCourses
        {
            get
            {
                DBCSEntities ent = new DBCSEntities();
               
                List<Course> AllStudentCourses = new List<Course>();
                if (StudentEvents != null)
                {
                    foreach (StudentEvent Event in StudentEvents)
                    {
                        if (!AllStudentCourses.Contains(Event.Event.Course))
                        {
                            AllStudentCourses.Add(Event.Event.Course);
                        }
                    }


                }
                return AllStudentCourses;
            }

        }

        protected int StudentLevel
        {
            get
            {
                int MaxCourseLevel = 1;
                foreach (Course CourseEntity in StudentCourses)
                {
                    if (CourseEntity.CourseLevel > MaxCourseLevel)
                    {
                        MaxCourseLevel = CourseEntity.CourseLevel;
                    }
                }
                return MaxCourseLevel;
            }
        }


    }
}