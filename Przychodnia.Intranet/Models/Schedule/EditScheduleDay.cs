using System;
using System.Collections.Generic;

namespace Przychodnia.Intranet.Models.Schedule
{
    public class EditScheduleDay
    {
        public DateTime Date { get; set; }
        public List<DateTime> Times { get; set;}
    }
}
