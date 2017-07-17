using DataOperations.DBEngine;
using DataOperations.DBEntity;
using DataOperations.DBEntityManager;
using StudentEntity.CrossPageInformation;
using StudentEntity.PageTraversal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSOutreach.Pages.Student
{


    public partial class EventDetails : StudentBasePage
    {
        private Event _event;
        private Event SelectedEvent
        {
            get
            {
                return _event;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            int EventID = int.Parse(Request.QueryString["eventid"]);
            ObjectSet<Event> AllEvents = new StudentDBManager().AllEvents;
            bool EventFound = false;
            
          
            foreach (Event EventElement in AllEvents)
            {
                if (EventElement.EventId == EventID)
                {
                    EventFound = true;
                    _event = EventElement;
                    break;
                }
            }
            if (!EventFound)
            {
                throw new ApplicationException("Invalid Event Specified");
            }
            if (!IsPostBack)
            {
                CrossPageEventDetails EventSpecifics;
                if (CrossPageInformation != null)
                {
                    EventSpecifics = (CrossPageEventDetails)this.CrossPageInformation;
                }
                else
                {
                    EventSpecifics = new CrossPageEventDetails();
                    EventSpecifics.AlreadyRegistered = false;
                }
                if(EventSpecifics.AlreadyRegistered)
                {
                    RegisterButton.Visible = false;
                }
                RenderPageElements();
                
            }


        }

        private void RenderPageElements()
        {
            LabelEventName.Text = SelectedEvent.Name;
            CourseName.Text = SelectedEvent.Course.CourseName;
            EventDescLabel.Text = SelectedEvent.Description;
            StartTimeLabel.Text = SelectedEvent.StartTime.ToString(@"hh\:mm");
            EndTimeLabel.Text = SelectedEvent.EndTime.ToString(@"hh\:mm");
            Date1.Text = SelectedEvent.StartDate.ToString("MM-dd-yyyy");
            Date2.Text = SelectedEvent.EndDate.ToString("MM-dd-yyyy");
            PopulateArtifacts();
        }
        private void PopulateArtifacts()
        {
            string ArtifactsLocation = ConfigurationSettings.AppSettings["ArtifactsDirectory"];
           string[] Artifacts=Directory.GetFiles(ArtifactsLocation,"*.pdf");
           
            DataTable ArtifactsTable=new DataTable();
            ArtifactsTable.Columns.Add("DocumentLink");
             ArtifactsTable.Columns.Add("DocumentName");
            foreach(string ArtifactName in Artifacts)
            {
                DataRow Drow=ArtifactsTable.NewRow();
                Drow[0] = new UriBuilder(ConfigurationSettings.AppSettings["URLRoot"] + "/Pages/Student/Artifacts/Materials/" + Path.GetFileName(ArtifactName));
                Drow[1]=Path.GetFileName(ArtifactName);
                ArtifactsTable.Rows.Add(Drow);
            }

            ArtifactsRepeater.DataSource = ArtifactsTable;
            ArtifactsRepeater.DataBind();
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            CrossPageEventRegistration EventInfo = new CrossPageEventRegistration();
            EventInfo.RegistrationEventID = SelectedEvent.EventId;
            this.CrossPageInformation = EventInfo;
            Response.Redirect(TraverseManager.GetPage(PageData.EventRegistration));
        }

    }
}