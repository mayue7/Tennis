using TennisCalculator.Interfaces;
using TennisCalculator.Scores;

namespace TennisCalculator;

public class Game : IGame
{
    private IGameScore player1GameScore;
    private IGameScore player2GameScore;

    public Game(IPlayer player1, IPlayer player2)
    {
        player1GameScore = new GameScore(player1);
        player2GameScore = new GameScore(player2);
    }

    public void PlayerWinPoint(IPlayer player)
    {
        if (player1GameScore.Player == player)
        {
            RoundPoint(player1GameScore, player2GameScore);
        }
        else
        if (player2GameScore.Player == player)
        {
            RoundPoint(player2GameScore, player1GameScore);
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
            // Console.WriteLine($"GameFile: {pointWinner.Player.Name}, {pointWinner.IsWinner}");

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
            if (player1GameScore.IsWinner)
            {
                player1GameScore.Player.TotalWonGamesScore++;
                player2GameScore.Player.TotalLoseGamesScore++;
                return player1GameScore.Player;
            }

            if (player2GameScore.IsWinner)
            {
                player2GameScore.Player.TotalWonGamesScore++;
                player1GameScore.Player.TotalLoseGamesScore++;
                return player2GameScore.Player;
            }

            return null;
        }
    }

    public IPlayer GameLoser
    {
        get
        {
            if (player1GameScore.IsWinner)
            {
                return player2GameScore.Player;
            }

            if (player2GameScore.IsWinner)
            {
                return player2GameScore.Player;
            }

            return null;
        }
    }
}