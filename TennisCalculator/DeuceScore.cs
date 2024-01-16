using TennisCalculator.Interfaces;

namespace TennisCalculator;

public class DeuceScore : IScore
{
    public int Value
    {
        get
        {
            return 50;
        }
    }
}
