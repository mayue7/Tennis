using TennisCalculator.Interfaces;

namespace TennisCalculator;

public class PlayerMatchScore : IPlayerMatchScore
{
    public IPlayer Player { get; set; }

    public int WonSetsScore { get; set; }


    public PlayerMatchScore(IPlayer player)
    {
        Player = player;
        WonSetsScore = 0;
    }
}
