using System;

namespace Web.Commerce.Entity
{
    public static class Extension
    {
        public static int DifferenceTotalYears(this DateTime start, DateTime end)
        {
            // Get difference in total months.
            var months = ((end.Year - start.Year)*12) + (end.Month - start.Month);

            // subtract 1 month if end month is not completed
            if (end.Day < start.Day)
            {
                months--;
            }

            return Math.Abs(months/12);
        }
    }
}