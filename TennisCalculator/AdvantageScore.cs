using TennisCalculator.Interfaces;

namespace TennisCalculator;

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


