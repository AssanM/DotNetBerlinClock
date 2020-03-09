namespace BerlinClock.RowTransformers
{
    public abstract class RowTransformer : ITimeTransformer
    {
        protected char GetMatchingColor(int value, int valueToCompare, char charWhenTrue = 'R', char charWhenFalse = 'O')
        {
            return value < valueToCompare ? charWhenFalse : charWhenTrue;
        }

        public abstract string Transform(int minutes);
    }
}