namespace BerlinClock.RowTransformers
{
    /// <summary>
    /// Transforms the given second to 'Y' or 'O'  symbols which indicates
    /// the lamb blinking on each two second.
    /// </summary>
    public class YellowLamp : ITimeTransformer
    {
        public string Transform(int seconds)
        {
            return seconds % 2 == 0 ? "Y" : "O";
        }
    }
}
