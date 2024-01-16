using TennisCalculator.Interfaces;

namespace TennisCalculator;

public class Game : IGame
{
    private IGameScore playerOneGameScore;
    private IGameScore playerTwoGameScore;

    public Game(IPlayer player1, IPlayer player2)
    {
        playerOneGameScore = new GameScore(player1);
        playerTwoGameScore = new GameScore(player2);
    }

    public void PlayerWinPoint(IPlayer player)
    {
        if (playerOneGameScore.Player == player)
        {
            RoundPoint(playerOneGameScore, playerTwoGameScore);
        }
        else
        if (playerTwoGameScore.Player == player)
        {
            RoundPoint(playerTwoGameScore, playerOneGameScore);
        }
        else
        {
            throw new Exception("Call Game.PlayerWinPoint with Unknow player");
        }
    }

    private void RoundPoint(IGameScore pointWinner, IGameScore pointLoser)
    {
        if (pointWinner.HasAdvantage)
        {
            pointWinner.WinTheGame();
            return;
        }

        if (pointLoser.HasAdvantage)
        {
            pointWinner.DeuceScore();
            pointLoser.DeuceScore();
            return;
        }

        if (pointWinner.IsDeuce)
        {
            pointWinner.TakeTheAdvantage();
            pointLoser.FortyScore();
            return;
        }

        if (pointWinner.HasLessThanFortyPoints && pointLoser.HasLessThanFortyPoints)
        {
            pointWinner.IncreaseScore();
            return;
        }

        if (pointWinner.HasFortyPoints)
        {
            pointWinner.WinTheGame();
            return;
        }

        pointWinner.IncreaseScore();

        if (pointWinner.HasFortyPoints && pointLoser.HasFortyPoints)
        {
            pointWinner.DeuceScore();
            pointLoser.DeuceScore();
        }

    }

    public bool GameEnd => GameWinner != null;

    public IPlayer GameWinner
    {
        get
        {
            if (playerOneGameScore.IsWinner)
            {
                playerOneGameScore.Player.TotalWonGamesScore++;
                playerTwoGameScore.Player.TotalLoseGamesScore++;
                return playerOneGameScore.Player;
            }

            if (playerTwoGameScore.IsWinner)
            {
                playerTwoGameScore.Player.TotalWonGamesScore++;
                playerOneGameScore.Player.TotalLoseGamesScore++;
                return playerTwoGameScore.Player;
            }

            return null;
        }
    }

    public IPlayer GameLoser
    {
        get
        {
            if (playerOneGameScore.IsWinner)
            {
                return playerTwoGameScore.Player;
            }

            if (playerTwoGameScore.IsWinner)
            {
                return playerTwoGameScore.Player;
            }

            return null;
        }
    }
}