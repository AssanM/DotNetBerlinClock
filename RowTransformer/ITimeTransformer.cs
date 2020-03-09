namespace BerlinClock.RowTransformers
{
    public interface ITimeTransformer
    {
        string Transform(int timeUnit);
    }
}
