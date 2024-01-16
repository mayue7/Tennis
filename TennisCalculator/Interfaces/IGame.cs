using TennisCalculator.Interfaces;

public interface IGame
{
    bool GameEnd { get; }
    IPlayer GameWinner { get; }
    IPlayer GameLoser { get; }
    //  int MatchId { get; }
    void PlayerWinPoint(IPlayer player);
}