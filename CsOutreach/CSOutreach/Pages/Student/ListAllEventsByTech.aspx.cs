using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataOperations.DBEntityManager;
using DataOperations.DBEntity;

namespace CSOutreach.Pages.Student
{
    public partial class ListAllEventsByTech : System.Web.UI.Page
    {
        EventDBManager eventDBMgr = new EventDBManager();
        List<Event> eventsList = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            eventsList = eventDBMgr.GetAllEvents();
            if (eventsList != null)
            {
                Console.WriteLine("No of Events:"+eventsList.Count);
                //eventsGrid.DataSource = eventsList;
            }            
        }
    }
}
