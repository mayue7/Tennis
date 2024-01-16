using TennisCalculator.Interfaces;
using Xunit;

namespace TennisCalculator.Test;

public class SetTests
{
    [Fact]
    public void ASetOfTennis_Should_Run_Successfully()
    {
        int matchId = 1;
        IPlayer player1 = new Player("Person A");
        IPlayer player2 = new Player("Person B");

        Set set = new Set(matchId, player1, player2);

        //Player 2 won one game
        PlayOneGame(set, player2, player1);

        //Player 1 won six games
        PlayOneGame(set, player1, player2);
        PlayOneGame(set, player1, player2);
        PlayOneGame(set, player1, player2);
        PlayOneGame(set, player1, player2);
        PlayOneGame(set, player1, player2);
        PlayOneGame(set, player1, player2);

        Assert.Equal(6, player1.TotalWonGamesScore);
        Assert.Equal(1, player1.TotalLoseGamesScore);

        Assert.Equal(1, player2.TotalWonGamesScore);
        Assert.Equal(6, player2.TotalLoseGamesScore);

        Assert.Equal("Person A", set.SETWinner.Name);
    }


    void PlayOneGame(Set set, IPlayer player1, IPlayer player2)
    {
        // Player 1 wins 1 point (15 : 0)
        set.PlayerWinPoint(player1);

        // Player 1 wins 1 point (30 : 0)
        set.PlayerWinPoint(player1);

        // Player 2 wins 1 point (30 : 15)
        set.PlayerWinPoint(player2);

        // Player 1 wins 1 point (40 : 15)
        set.PlayerWinPoint(player1);

        // Player 2 wins 1 point (40 : 30)
        set.PlayerWinPoint(player2);

        // Player 1 wins 1 point (Game finished)
        set.PlayerWinPoint(player1);
    }
}