using TennisCalculator.Interfaces;

namespace TennisCalculator;

public class DeuceScore : IPointValue
{
    public int Value
    {
        get
        {
            return 50;
        }
    }
}
