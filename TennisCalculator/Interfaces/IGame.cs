using TennisCalculator.Interfaces;

public interface IGame
{
    bool GameEnd { get; }
    IPlayer Winner { get; }
    IPlayer Loser { get; }
    int MatchId { get; }
    void PlayerWinPoint(IPlayer player);
}