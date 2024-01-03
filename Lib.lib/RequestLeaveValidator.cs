using System.Globalization;

namespace Exercise.Lib
{
    public class RequestLeaveValidator
    {
        public struct LeaveResult
        {
            public bool IsValid { get; set; }
            public string? Error { get; set; }
        }

        public static LeaveResult RequestLeave(string dayOff, bool requiredDayNotInThePast = true, bool requiredDayNotInTheWeekend = true)
        {
            if (string.IsNullOrEmpty(dayOff))
            {
                return new LeaveResult { IsValid = false , Error = "Date is not empty"};
            }

            if (!DateTime.TryParseExact(dayOff, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime leaveDays))
                //if (!DateTime.TryParse(dayOff, out var leaveDays))
            {
                return new LeaveResult { IsValid = false, Error = "Invalid date format. It should be format like \"dd/MM/yyyy\"" };
            }
           
            if (requiredDayNotInThePast)
            {
                if (leaveDays < DateTime.Today)
                    return new LeaveResult { IsValid = false, Error = "Date in the past" };
            }

            if (requiredDayNotInTheWeekend)
            {
                if (leaveDays.DayOfWeek == DayOfWeek.Saturday || leaveDays.DayOfWeek == DayOfWeek.Sunday)
                    return new LeaveResult { IsValid = false, Error = "Leave days cannot be Saturday or Sunday" };
            }

            return new LeaveResult { IsValid = true, Error = null };

        }
    }
}
