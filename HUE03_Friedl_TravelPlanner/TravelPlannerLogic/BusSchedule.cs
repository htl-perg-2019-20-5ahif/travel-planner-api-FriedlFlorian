using System;
using System.Collections.Generic;
using System.Text;

namespace TravelPlannerLogic
{
    public class BusSchedule
    {
        public String City { get; set; }
        public Leave_Arrive[] ToLinz { get; set; }
        public Leave_Arrive[] FromLinz { get; set; }
    }
}
