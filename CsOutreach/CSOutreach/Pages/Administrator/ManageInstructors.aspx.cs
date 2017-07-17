using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Web.ModelBinding;
using DataOperations.DBEntity;
using DataOperations.DBEntityManager;

namespace CSOutreach.Pages.Administrator
{
    public partial class ManageInstructors : System.Web.UI.Page
    {
        AdminDBManager db = new AdminDBManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            ContentPlaceHolder cp = this.Master.Master.FindControl("BodyContent") as ContentPlaceHolder;
            HtmlGenericControl divsuccess = cp.FindControl("AdminContent").FindControl("divsuccess") as HtmlGenericControl;
            if (divsuccess != null)
                divsuccess.Style["display"] = "none";
        }

        protected void btnSearchApplcnt_Click(object sender, EventArgs e)
        {
            Person even = new Person();
            DataOperations.DBEntity.Instructor instruct = new DataOperations.DBEntity.Instructor();

            even.FirstName = ApplicantName.Text;
            if (!SemStarted.Text.Equals(""))
            {
                instruct.JoinedUtd = SemStarted.Text;
            }


            using (DBCSEntities entity = new DBCSEntities())
            {

                if (!(ApplicantName.Text.Equals("")) && SemStarted.Text.Equals(""))
                {
                    var query = from person in entity.People
                                join instructor in entity.Instructors on person.PersonId equals instructor.InstructorId
                                //join skill in entity.SkillSets on instructor.InstructorId equals 
                                where person.FirstName == even.FirstName && instructor.canTeach == true
                                select new { firstname = person.FirstName, lastname = person.LastName, contactnum = person.ContactNumber, hascar = instructor.hasCar, joinedUtd = instructor.JoinedUtd, instructorID = instructor.InstructorId };
                    ReviewApplcntRepeater.DataSource = query;
                    ReviewApplcntRepeater.DataBind();
                }
                else if (!(SemStarted.Text.Equals("")) && ApplicantName.Text.Equals(""))
                {
                    var query = from person in entity.People
                                join instructor in entity.Instructors on person.PersonId equals instructor.InstructorId
                                //join skill in entity.SkillSets on instructor.InstructorId equals 
                                where instructor.JoinedUtd == instruct.JoinedUtd && instructor.canTeach == true
                                select new { firstname = person.FirstName, lastname = person.LastName, contactnum = person.ContactNumber, hascar = instructor.hasCar, joinedUtd = instructor.JoinedUtd, instructorID = instructor.InstructorId };
                    ReviewApplcntRepeater.DataSource = query;
                    ReviewApplcntRepeater.DataBind();
                }
                else if (ApplicantName.Text.Equals("") && SemStarted.Text.Equals(""))
                {
                    var query = from person in entity.People
                                join instructor in entity.Instructors on person.PersonId equals instructor.InstructorId
                                //join skill in entity.SkillSets on instructor.InstructorId equals 
                                where instructor.canTeach == true
                                select new { firstname = person.FirstName, lastname = person.LastName, contactnum = person.ContactNumber, hascar = instructor.hasCar, joinedUtd = instructor.JoinedUtd, instructorID = instructor.InstructorId };
                    ReviewApplcntRepeater.DataSource = query;
                    ReviewApplcntRepeater.DataBind();
                }
                else
                {
                    var query = from person in entity.People
                                join instructor in entity.Instructors on person.PersonId equals instructor.InstructorId
                                //join skill in entity.SkillSets on instructor.InstructorId equals 
                                where person.FirstName == even.FirstName && instructor.JoinedUtd == instruct.JoinedUtd && instructor.canTeach == true
                                select new { firstname = person.FirstName, lastname = person.LastName, contactnum = person.ContactNumber, hascar = instructor.hasCar, joinedUtd = instructor.JoinedUtd, instructorID = instructor.InstructorId };
                    ReviewApplcntRepeater.DataSource = query;
                    ReviewApplcntRepeater.DataBind();
                }

            }
        }

        protected void btnReject_Click1(object sender, EventArgs e)
        {
            foreach (RepeaterItem aItem in ReviewApplcntRepeater.Items)
            {
                CheckBox chkInstructor = (CheckBox)aItem.FindControl("checkbx");
                if (chkInstructor.Checked)
                {
                    db.UpdateReviewApplicantsReject(Convert.ToInt32(chkInstructor.Attributes["value"]));
                }
            }

            ContentPlaceHolder cp = this.Master.Master.FindControl("BodyContent") as ContentPlaceHolder;
            HtmlGenericControl divsuccess = cp.FindControl("AdminContent").FindControl("divsuccess") as HtmlGenericControl;
            if (divsuccess != null)
                divsuccess.Style["display"] = "block";
        }
    }
}