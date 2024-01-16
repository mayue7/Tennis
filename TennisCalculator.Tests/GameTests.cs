using TennisCalculator.Interfaces;
using Xunit;

namespace TennisCalculator.Test;

public class GameTests
{
    [Fact]
    public void AGameOfTennis_Should_Run_Successfully()
    {
        IPlayer player1 = new Player("Person A");
        IPlayer player2 = new Player("Person B");

        IGame game = new Game(player1, player2);

        // Player 1 wins 1 point
        game.PlayerWinPoint(player1);

        // Player 1 wins 1 point
        game.PlayerWinPoint(player1);

        // Player 2 wins 1 point
        game.PlayerWinPoint(player2);

        // Player 1 wins 1 point
        game.PlayerWinPoint(player1);

        // Player 2 wins 1 point
        game.PlayerWinPoint(player2);

        // Player 1 wins 1 point
        game.PlayerWinPoint(player1);
        Assert.Equal("Person A", game.GameWinner.Name);
        Assert.True(game.GameEnd);
    }

    [Fact]
    public void DeuceTest()
    {
        IPlayer player1 = new Player("Person A");
        IPlayer player2 = new Player("Person B");

        IGame game = new Game(player1, player2);

        // Player 1 wins 1 point
        game.PlayerWinPoint(player1);

        // Player 1 wins 1 point
        game.PlayerWinPoint(player1);

        // Player 2 wins 1 point
        game.PlayerWinPoint(player2);

        // Player 1 wins 1 point
        game.PlayerWinPoint(player1);

        // Player 2 wins 1 point
        game.PlayerWinPoint(player2);

        // Player 2 wins 1 point
        game.PlayerWinPoint(player2);

        // Player 2 wins 1 point
        game.PlayerWinPoint(player2);

        // Player 1 wins 1 point
        game.PlayerWinPoint(player1);

        // Player 1 wins 1 point
        game.PlayerWinPoint(player1);

        // Player 1 wins 1 point
        game.PlayerWinPoint(player1);
        Assert.Equal("Person A", game.GameWinner.Name);
        Assert.True(game.GameEnd);
    }
}
