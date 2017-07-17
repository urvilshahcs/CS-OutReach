using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEntity.CrossPageInformation
{
    public class CrossPageEventDetails
    {
        public CrossPageEventDetails()
        {
            AlreadyRegistered = false;
        }
        int SelectedEventID
        {
            get;
            set;
        }

        public bool AlreadyRegistered
        {
            get;
            set;
        }
    }
}
