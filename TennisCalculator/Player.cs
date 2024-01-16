using TennisCalculator.Interfaces;

namespace TennisCalculator;

public class Player : IPlayer
{
    public Player(string name)
    {
        this.Name = name;
        this.TotalWonGamesScore = 0;
        this.TotalLoseGamesScore = 0;
    }

    public string Name { get; }
    public int TotalWonGamesScore { get; set; }
    public int TotalLoseGamesScore { get; set; }
}
