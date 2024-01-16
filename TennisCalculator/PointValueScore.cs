using TennisCalculator.Interfaces;

namespace TennisCalculator;

public class PointValueScore : IScore
{
    private int points;

    public PointValueScore(int points = 0)
    {
        this.points = points;
    }

    public int Value
    {
        get
        {
            return points;
        }
    }
}