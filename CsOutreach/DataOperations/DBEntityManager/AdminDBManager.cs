using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataOperations.DBEntity;

namespace DataOperations.DBEntityManager
{
    public class AdminDBManager
    {
        public List<EventType> GetEventTypes()
        {
            List<EventType> eventTypes = new List<EventType>();
            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    eventTypes = (from eventTypeTemp in entity.EventTypes select eventTypeTemp).ToList();
                }
            }
            catch (Exception)
            {
               
               
            }
            return eventTypes;
        }

        public List<Course> GetCourseTypes()
        {
            List<Course> courseTypes = new List<Course>();
            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    courseTypes = (from courseTypeTemp in entity.Courses select courseTypeTemp).ToList();
                }
            }
            catch (Exception)
            {


            }
            return courseTypes;
        }

        public List<Event> GetUpcommingEvents()
        {
            DateTime thisDay = DateTime.Today;

            //Using this because there are no events that will start from today
            DateTime someDay = new DateTime(2014,9,2);
            List<Event> events = new List<Event>();
            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    events = (from eventTemp in entity.Events where eventTemp.StartDate>=someDay  select eventTemp).ToList();
                }
            }
            catch (Exception)
            {


            }
            return events;
        }

        public List<String> GetAvailableInstructors()
        {
            DateTime thisDay = DateTime.Today;

            //Using this because there are no events that will start from today
            DateTime someDay = new DateTime(2014, 9, 2);
            List<String> instructor = new List<String>();
            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    instructor = (from instructorTemp in entity.People
                                  where instructorTemp.Role=="Instructor" 
                                  select instructorTemp.FirstName+" "+instructorTemp.LastName).ToList();
                }
            }
            catch (Exception)
            {


            }
            return instructor;
        }

        public List<Person> GetUpcommingInstructorsOnLeave()
        {
            DateTime thisDay = DateTime.Today;

            //Using this because there are no events that will start from today
            DateTime someDay = new DateTime(2014, 9, 2);
            List<Person> instructor = new List<Person>();
            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    instructor = (from ei in entity.EventInstructors 
                                  join p in entity.People 
                                  on ei.InstructorId equals p.PersonId
                                  join e in entity.Events
                                  on ei.EventId equals e.EventId
                                  where e.StartDate>=someDay 
                                  && ei.LeaveApplied == true
                                  select p).ToList();
                }
            }
            catch (Exception)
            {


            }
            return instructor;
        }


        public List<Course> GetCurrentCourses()
        {
            DateTime thisDay = DateTime.Today;

            //Using this because there are no events that will start from today
            DateTime someDay = new DateTime(2014, 9, 2);
            List<Course> course = new List<Course>();
            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    course = (from c in entity.Courses
                                  join e in entity.Events
                                  on c.CourseId equals e.CourseId
                                  where e.StartDate>=someDay
                                  select c).Distinct().ToList();
                }
            }
            catch (Exception)
            {


            }
            return course;
        }

        public void InsertEventInstructor(String name, DateTime date, int eventid)
        {

            //Data to insert in event table 
            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    EventInstructor ei = new EventInstructor();
                    String[] Name = name.Split(' ');
                    String fName = Name[0];
                    String lName = Name[1];
                    ei.EventId = eventid;
                    ei.InstructorId =
                    ((from per in entity.People
                      where per.FirstName == fName && per.LastName == lName
                      select per.PersonId).FirstOrDefault());
                    ei.Date = date;
                    ei.ACCEPTED = false;
                    ei.LeaveApplied = false;
                    entity.AddToEventInstructors(ei);
                    entity.SaveChanges();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

           


        public List<SkillSet> GetSkillSet()
        {
            List<SkillSet> skillsets = new List<SkillSet>();
            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    skillsets = (from Skillset in entity.SkillSets select Skillset).ToList();
                }
            }
            catch (Exception)
            {}
            return skillsets;
        }



        public List<EventInstructor> GetEventInstructors()
        {
            List<EventInstructor> eventInstructors = new List<EventInstructor>();
            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    eventInstructors = (from eventInstructorTemp in entity.EventInstructors select eventInstructorTemp).ToList();
                }
            }
            catch (Exception)
            {


            }

            return eventInstructors;
        }

        public String UpdateReviewApplicantsAccept(int instructorID)
        {
            Instructor instructors = new Instructor();
            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    instructors = (from instructorTemp in entity.Instructors where instructorTemp.InstructorId == instructorID select instructorTemp).FirstOrDefault<Instructor>();
                    instructors.canTeach = true;
                    entity.SaveChanges();

                }
            }
            catch (Exception)
            {
                return "failed";

            }

            return "success";
        }

        public String UpdateReviewApplicantsReject(int instructorID)
        {
            Instructor instructors = new Instructor();
            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    instructors = (from instructorTemp in entity.Instructors where instructorTemp.InstructorId == instructorID select instructorTemp).FirstOrDefault<Instructor>();
                    instructors.canTeach = false;
                    entity.SaveChanges();
                }
            }
            catch (Exception)
            {
                return "failed";

            }

            return "success";
        }

        public void UpdateLeaveApplicationsApprove(int EventInstructorID)
        {
            EventInstructor eventInstructor = new EventInstructor();
            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    eventInstructor = (from eventInstructorTemp in entity.EventInstructors
                                       where eventInstructorTemp.EventInstructorId == EventInstructorID 
                                       select eventInstructorTemp).FirstOrDefault();
                    eventInstructor.ACCEPTED = true;
                    eventInstructor.LeaveApplied = false;
                    entity.SaveChanges();

                }
            }
            catch (Exception)
            {
                
            }
        }

        public void AddNewEvent(string other, string reccurance)
        {
            EventType et = new EventType();
            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    et.TypeName = other;
                    et.Recurrence = reccurance;
                    entity.AddToEventTypes(et);
                    entity.SaveChanges();

                }
            }
            catch (Exception)
            {

            }

        }

        public String addStudentToEventAdmin(int eventIdToAdd, int studentIdToAdd)
        {
            StudentEvent stuEvnt = new StudentEvent();
            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    stuEvnt.EventId = eventIdToAdd;
                    stuEvnt.StudentId = studentIdToAdd;
                    stuEvnt.RegistrationDate = DateTime.Today;

                    entity.AddToStudentEvents(stuEvnt);
                    entity.SaveChanges();
                }
            }
            catch (Exception)
            {
                return "failed";

            }

            return "success";
        }



    }
}
