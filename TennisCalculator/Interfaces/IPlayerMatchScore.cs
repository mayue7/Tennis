namespace TennisCalculator.Interfaces;

public interface IPlayerMatchScore
{
    IPlayer Player { get; set; }
    int WonSetsScore { get; set; }
}
