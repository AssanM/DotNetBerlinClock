using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BerlinClock.RowTransformers;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private readonly ITimeTransformer hoursFirstRow;
        private readonly ITimeTransformer hoursSecondRow;
        private readonly ITimeTransformer minutesFirstRow;
        private readonly ITimeTransformer minutesSecondRow;
        private readonly ITimeTransformer yellowLampRow;

        private readonly IEnumerable<int> hourDivisions;
        private readonly IEnumerable<int> minuteDivisions;

        public TimeConverter() : this(
            new HoursFirstRow(),
            new HoursSecondRow(),
            new MinutesFirstRow(),
            new MinutesSecondRow(),
            new YellowLamp())
        {
        }

        public TimeConverter(ITimeTransformer hoursFirstRow, ITimeTransformer hoursSecondRow, ITimeTransformer minutesFirstRow, ITimeTransformer minutesSecondRow, ITimeTransformer yellowLampRow)
        {
            this.hoursFirstRow = hoursFirstRow;
            this.hoursSecondRow = hoursSecondRow;
            this.minutesFirstRow = minutesFirstRow;
            this.minutesSecondRow = minutesSecondRow;
            this.yellowLampRow = yellowLampRow;
            this.hourDivisions = new List<int> { 5, 10, 15, 20 }; // we can keep these lists also in conf. file.
            this.minuteDivisions = new List<int> { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55 };
        }
        public string convertTime(string aTime)
        {
            if (string.IsNullOrWhiteSpace(aTime))
            {
                // Or here we can log it.
                Console.WriteLine("The given time-string is either null, empty or contains only white spaces.");
                return String.Empty;
            }

            string[] hms = aTime.Split(':');
            string strMinutes = hms.Length > 1 ? hms[1] : null;
            string strSeconds = hms.Length > 2 ? hms[2] : null;

            int.TryParse(hms[0], out int hours);
            int.TryParse(strMinutes, out int minutes);
            int.TryParse(strSeconds, out int seconds);

            return ConvertTime(hours, minutes, seconds);
        }
        public string ConvertTime(int hour, int minutes, int seconds)
        {
            int hoursFirstRowValue = hour;
            int hoursSecondRowValue = hour - GetBiggestMatch(hourDivisions, hour);

            int minutesFirstRowValue = minutes;
            int minutesSecondRowValue = minutes - GetBiggestMatch(minuteDivisions, minutes);

            return string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}",
                    this.yellowLampRow.Transform(seconds),
                    this.hoursFirstRow.Transform(hoursFirstRowValue),
                    this.hoursSecondRow.Transform(hoursSecondRowValue),
                    this.minutesFirstRow.Transform(minutesFirstRowValue),
                    this.minutesSecondRow.Transform(minutesSecondRowValue)
                    );
        }

        private int GetBiggestMatch(IEnumerable<int> divisionList, int value)
        {
            return divisionList.Where(x => x < value).OrderByDescending(x => x).FirstOrDefault();
        }
    }
}
