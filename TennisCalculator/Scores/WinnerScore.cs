using TennisCalculator.Interfaces;

namespace TennisCalculator;

public class WinnerScore : IPointValue
{
    public int Value
    {
        get
        {
            return 70;
        }
    }
}

