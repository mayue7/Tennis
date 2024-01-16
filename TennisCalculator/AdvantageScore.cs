using TennisCalculator.Interfaces;

namespace TennisCalculator;

public class AdvantageScore : IScore
{
    public int Value
    {
        get
        {
            return 60;
        }
    }
}


