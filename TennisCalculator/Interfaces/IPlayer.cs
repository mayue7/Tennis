namespace TennisCalculator.Interfaces;

public interface IPlayer
{
    string Name { get; }
    int TotalWonGamesScore { get; set; }
    int TotalLoseGamesScore { get; set; }
}
