using System;

namespace TravelPlannerLogic
{
    public class TravelPlanLogic
    {
        public static string planTrip(BusSchedule [] bs, string from, string to, string start)
        {
            if (to.Equals("Linz"))
            {
                foreach (var t in bs)
                {
                    if (t.City.Equals(from) && !from.Equals("Linz"))
                    {
                        string[] split = start.Split(':');
                        int timeLeaveH = Int32.Parse(split[0]);
                        int timeLeaveM = Int32.Parse(split[1]);

                        foreach (var time in t.ToLinz)
                        {
                            string[] splitToLinz = time.Leave.Split(':');
                            if ((Int32.Parse(splitToLinz[0]) - timeLeaveH >= 0) && (Int32.Parse(splitToLinz[1]) - timeLeaveM >= 0))            //Beruht darauf das die Zeiten sortiert sind
                            {
                                string ret = "departureTime: " + time.Leave + "\narrive: Linz\narrivalTime: " + time.Arrive;
                                return ret;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (var t in bs)
                {
                    if (t.City.Equals(to))
                    {
                        string[] split = start.Split(':');
                        int timeLeaveH = Int32.Parse(split[0]);
                        int timeLeaveM = Int32.Parse(split[1]);

                        foreach (var time in t.FromLinz)
                        {
                            string[] splitFromLinz = time.Leave.Split(':');
                            if ((Int32.Parse(splitFromLinz[0]) - timeLeaveH >= 0) && (Int32.Parse(splitFromLinz[1]) - timeLeaveM >= 0))            //Beruht darauf das die Zeiten sortiert sind
                            {
                                string ret = "departureTime: " + time.Leave + "\narrive: " + to + "\narrivalTime: " + time.Arrive;
                                return ret;
                            }
                        }
                    }
                }
            }

            
            return null;
        }
    }
}
