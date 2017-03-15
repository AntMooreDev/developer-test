using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Utils
{
    public static class DateTimeUtils
    {
        public static DateTime RoundUp(DateTime dateTime, TimeSpan timeSpan)
        {
            return new DateTime(((dateTime.Ticks + timeSpan.Ticks - 1) / timeSpan.Ticks) * timeSpan.Ticks, dateTime.Kind);
        }
    }
}