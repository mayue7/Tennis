namespace TennisCalculator.Interfaces;

public interface IPlayerSetScore
{
    IPlayer Player { get; set; }
    int WonGamesScore { get; set; }
}
