using DataOperations.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperations.DBEntityManager
{
   public class EventDBManager
    {
        /// <summary>
        /// Get Student Events
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<Event> GetAllEvents()
        {
            List<Event> studentEventList = null;

            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    var query = from Event in entity.Events select Event;
                    studentEventList = (query).ToList();
                    Console.WriteLine("No of Events available:"+studentEventList.Count);
                }
            }
            catch (Exception ex)
            {

            }
            return studentEventList;
        }

        public Event GetSelectedEventDetails(int eventID)
        {
            Event selectedEvent = null;
            try
            {
                using (DBCSEntities entity = new DBCSEntities())
                {
                    var query = from Event in entity.Events
                                where Event.EventId == eventID
                                select Event;
                    selectedEvent = query.First();
                    Console.WriteLine(selectedEvent.EventType + selectedEvent.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in EventDBManager.GetSelectedEventDetails() method" + ex.Message);                
            }
            return selectedEvent;
        }

        public void RegisterEvent()
        {

        }

    }
}
