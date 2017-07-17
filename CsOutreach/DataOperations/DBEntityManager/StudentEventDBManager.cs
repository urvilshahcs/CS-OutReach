using DataOperations.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperations.DBEntityManager
{
    public class StudentEventDBManager
    {
        /// <summary>
        /// Get Student Events
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<Event> GetStudentRegisteredEvent(int userid)
        {
            List<Event> studentEventList = new List<Event>();

            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {

                    var query = from Event in entity.Events
                                join studentEvent in entity.StudentEvents on Event.EventId equals studentEvent.EventId
                                where studentEvent.StudentId == userid
                                select Event;
                    studentEventList = (query).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return studentEventList;
        }

        /// <summary>
        /// To get upcoming events related to registered events
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<Event> GetUpcomingEvents(int userid)
        {
            List<Event> UpcomingEventList = new List<Event>();
            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    var query = GetStudentRegisteredEvent(userid);
                    var subquery=from event1 in entity.Events join studentEvent in entity.StudentEvents on event1.EventId equals studentEvent.EventId where studentEvent.StudentId==userid
                                 select event1.CourseId;
                    var innerquery = (from event2 in entity.Events where subquery.Contains(event2.CourseId)  && event2.StartDate>DateTime.Now  select event2).ToList();

                    UpcomingEventList = (from eventget in innerquery
                                         where !(from e in query select e.Name).Contains(eventget.Name) orderby eventget.StartDate
                                      select eventget).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return UpcomingEventList;
        }

        /// <summary>
        /// To check if paper work is complete
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool IsPaperWorkComplete(int userid)
        {
            bool ispaperworkComplete = false;

            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    var query = from student1 in entity.Students select student1;
                    query = query.Where((o => o.StudentId == userid && o.IsPaperWorkComplete == true));
                    if (query.ToList().Count() > 0)
                    {
                        ispaperworkComplete = true;
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return ispaperworkComplete;
        }
		
		
       /// <summary>
       /// Get Events PreReq
       /// </summary>
       /// <param name="userid"></param>
       /// <returns></returns>
       public List<Event> GetEventPrereq(int userID, Event selectedEvent)
       {
           int courseLevel;
           List<Event> studentEventList = null;
           int courseID = selectedEvent.CourseId;

           try
           {
               using (DBCSEntities entity = new DBCSEntities())
               {
                   var query = from course in entity.Courses
                               join regEvent in entity.Events on course.CourseId equals regEvent.CourseId
                               where regEvent.EventId == selectedEvent.EventId 
                               select course.CourseLevel;
                   courseLevel = query.SingleOrDefault();
               }

               using (DBCSEntities entity = new DBCSEntities())
               {                   
                   var query = from Event in entity.Events                               
                               join eventCourse in entity.Courses on Event.CourseId equals eventCourse.CourseId
                               join studentEvent in entity.StudentEvents on Event.EventId equals studentEvent.EventId
                               where studentEvent.StudentId == userID 
                               where eventCourse.CourseLevel < courseLevel   
                               select Event;
                   studentEventList = (query).ToList();                   
               }
           }
           catch (Exception ex)
           {
               
           }
           return studentEventList;
       }


       public Boolean RegisterEvent(StudentEvent studentEvent)
       {
           Boolean statusFlag = true;
           try
           {
               using (DBCSEntities entity = new DBCSEntities())
               {
                   entity.AddToStudentEvents(studentEvent);
                   entity.SaveChanges();
               }

           }
           catch (Exception ex)
           {
               statusFlag = false;
           }
           return statusFlag;
       }

       public Boolean isStudentEmergDataAvailable(int userID) {
           Boolean isAvailable = false;
           try
           {
               using (DBCSEntities entity = new DBCSEntities())
               {
                   var query = from studentEvent in entity.StudentEvents
                               where studentEvent.StudentId == userID
                               select studentEvent;
                   if(query.ToList().Count>0){
                       isAvailable = true;
                   }
               }

           }
           catch (Exception ex)
           {
               
           }
           return isAvailable;
       }
    }
    
}
