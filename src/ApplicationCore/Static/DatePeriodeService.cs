using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Static
{
    public static class DatePeriodeService
    {
        public static (DateTime Start, DateTime End) GetMonthRange(int year, int month)
        {
            var start = new DateTime(year, month, 1).ToUniversalTime();
            var end = start.AddMonths(1);
            return (start, end);
        }

        public static List<(int Year, int Month)> GetLast12Months()
        {
            var months = new List<(int Year, int Month)>();
            var now = DateTime.UtcNow;

            for (int i = 0; i < 12; i++)
            {
                var date = now.AddMonths(-i).ToUniversalTime();
                months.Add((date.Year, date.Month));
            }

            return months.OrderBy(x => x.Year).ThenBy(x => x.Month).ToList();
        }
    }
}
