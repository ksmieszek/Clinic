using Przychodnia.Data.Entities;
using System.Collections.Generic;

namespace Przychodnia.Intranet.Models.Schedule
{
    public class EditScheduleMonthHours
    {
        public int UserId { get; set; }
        public string UserTitle { get; set; }
        public string UserFullName { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public List<EditScheduleDay> Days { get; set; }
        public List<Harmonogram> Times { get; set; }
    }
}
