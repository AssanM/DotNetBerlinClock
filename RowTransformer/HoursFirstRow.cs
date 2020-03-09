using System;

namespace BerlinClock.RowTransformers
{
    public class HoursFirstRow: RowTransformer
    {
        public override string Transform(int minutes)
        {
            return String.Format("{3}{2}{1}{0}",
                GetMatchingColor(minutes, 20),
                GetMatchingColor(minutes, 15),
                GetMatchingColor(minutes, 10),
                GetMatchingColor(minutes, 5));
        }
    }
}
