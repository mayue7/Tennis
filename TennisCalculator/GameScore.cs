using TennisCalculator.Interfaces;

namespace TennisCalculator;

public class GameScore : IGameScore
{
    public IPlayer Player { get; }

    public IPointValue PointValue { get; set; }

    public GameScore(IPlayer player)
    {
        Player = player;
        PointValue = new PointValueScore();
    }

    public void IncreaseScore()
    {
        PointValue = NextPointValueScore(PointValue);
    }

    public void WinTheGame()
    {
        PointValue = new WinnerScore();
    }

    public void DeuceScore()
    {
        PointValue = new DeuceScore();
    }

    public void TakeTheAdvantage()
    {
        PointValue = new AdvantageScore();
    }

    public void FortyScore()
    {
        PointValue = new PointValueScore(40);
    }

    private PointValueScore NextPointValueScore(IPointValue score)
    {
        return score.Value switch
        {
            0 => new PointValueScore(15),
            15 => new PointValueScore(30),
            _ => new PointValueScore(40)
        };
    }

    public bool HasLessThanFortyPoints => PointValue is PointValueScore pointValueScore && pointValueScore.Value < 40;

    public bool HasFortyPoints => PointValue is PointValueScore pointValueScore && pointValueScore.Value == 40;

    public bool HasAdvantage => PointValue is AdvantageScore;

    public bool IsWinner => PointValue is WinnerScore;

    public bool IsDeuce => PointValue is DeuceScore;
}