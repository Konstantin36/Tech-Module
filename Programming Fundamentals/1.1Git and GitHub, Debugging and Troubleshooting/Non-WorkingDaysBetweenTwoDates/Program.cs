using System;
using System.Globalization;

namespace Non_WorkingDaysBetweenTwoDates
{
    public class HolidaysBetweenTwoDates
    {
        public static void Main()
        {
            var startDate = DateTime.ParseExact(Console.ReadLine(),
              "d.M.yyyy", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(Console.ReadLine(),
                "d.M.yyyy", CultureInfo.InvariantCulture);
            var holidaysCount = 0;
            for (var date = startDate; date <= endDate; date = date.AddDays(1.00))
            {
                if (date.DayOfWeek.Equals(DayOfWeek.Saturday) ||
                    date.DayOfWeek.Equals(DayOfWeek.Sunday))
                {
                    holidaysCount++;
                }
            }

            Console.WriteLine(holidaysCount);
        }
    }
}