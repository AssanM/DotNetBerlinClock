using System;

namespace BerlinClock.RowTransformers
{
    public class MinutesFirstRow : RowTransformer
    {
        public override string Transform(int minutes)
        {
            return String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}",
                GetMatchingColor(minutes, 5, 'Y'),
                GetMatchingColor(minutes, 10, 'Y'),
                GetMatchingColor(minutes, 15, 'R'),
                GetMatchingColor(minutes, 20, 'Y'),
                GetMatchingColor(minutes, 25, 'Y'),
                GetMatchingColor(minutes, 30, 'R'),
                GetMatchingColor(minutes, 35, 'Y'),
                GetMatchingColor(minutes, 40, 'Y'),
                GetMatchingColor(minutes, 45, 'R'),
                GetMatchingColor(minutes, 50, 'Y'),
                GetMatchingColor(minutes, 55, 'Y'));
        }
    }
}
