using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _01.ReturnsTheDayOfWeek
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DayOfWeekService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DayOfWeekService.svc or DayOfWeekService.svc.cs at the Solution Explorer and start debugging.
    public class DayOfWeekService : IDayOfWeekService
    {
        public string ReturnDayOfWeekOnBulgarian(DateTime date)
        {
            var culture = new System.Globalization.CultureInfo("bg-BG");
            var day = culture.DateTimeFormat.GetDayName(date.DayOfWeek);

            return day;
        }
    }
}
