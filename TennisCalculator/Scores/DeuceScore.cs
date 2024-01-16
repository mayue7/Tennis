using TennisCalculator.Interfaces;

namespace TennisCalculator.Scores;

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
