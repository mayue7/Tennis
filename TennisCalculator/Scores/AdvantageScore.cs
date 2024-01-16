using TennisCalculator.Interfaces;

namespace TennisCalculator.Scores;

public class AdvantageScore : IPointValue
{
    public int Value
    {
        get
        {
            return 60;
        }
    }
}


