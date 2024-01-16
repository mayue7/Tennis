using TennisCalculator.Interfaces;

namespace TennisCalculator.Scores;

public class PointValueScore : IPointValue
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