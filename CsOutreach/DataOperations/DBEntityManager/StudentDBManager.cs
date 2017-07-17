using DataOperations.DBEntity;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperations.DBEntityManager
{
    public class StudentDBManager
    {
        DBCSEntities Entities;
        Student student;
        public StudentDBManager()
        {
            student = new Student();
            Entities = new DBCSEntities();
        }
        public ObjectSet<Course> AllCourses
        {
            get
            {
                List<string> courses = new List<string>();
                return Entities.Courses;
            }
        }

        public ObjectSet<StudentEvent> AllStudentEvents
        {
            get
            {
               
                return Entities.StudentEvents;
                
            }
        }

        public ObjectSet<Event> AllEvents
        {
            get
            {
                return Entities.Events;
            }
        }
		
        public Student GetStudent(int studentID)
        {
            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    student = (from studentRecord in entity.Students
                               where studentRecord.StudentId == studentID
                               select studentRecord).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return student;
        }

        public Boolean addStudent(Student student)
        {
            Boolean oprnStatus = true;
            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    entity.AddToStudents(student);
                    entity.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                oprnStatus = false;
            }
            return oprnStatus;
        }
    }
}
