﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Commerce.Business
{
    public static class Extension
    {
        public static double DifferenceTotalYears(this DateTime start, DateTime end)
        {
            // Get difference in total months.
            int months = ((end.Year - start.Year) * 12) + (end.Month - start.Month);

            // substract 1 month if end month is not completed
            if (end.Day < start.Day)
            {
                months--;
            }

            double totalyears = months / 12d;
            return totalyears;
        }
    }
}
