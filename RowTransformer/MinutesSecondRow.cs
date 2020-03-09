using System;

namespace BerlinClock.RowTransformers
{
    /// <summary>
    /// Represents the second row of minutes section.
    /// </summary>
    public class MinutesSecondRow : RowTransformer
    {
        public override string Transform(int minutes)
        {
            return String.Format("{3}{2}{1}{0}",
                GetMatchingColor(minutes, 4, 'Y'),
                GetMatchingColor(minutes, 3, 'Y'),
                GetMatchingColor(minutes, 2, 'Y'),
                GetMatchingColor(minutes, 1, 'Y'));
        }
    }
}
