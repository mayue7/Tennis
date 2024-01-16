using TennisCalculator.Interfaces;

namespace TennisCalculator;

public class Game : IGame
{
    private IPlayerScore playerScore1;
    private IPlayerScore playerScore2;
    public int MatchId { get; }

    public Game(int matchId, IPlayer player1, IPlayer player2)
    {
        this.MatchId = matchId;
        playerScore1 = new PlayerScore(player1);
        playerScore2 = new PlayerScore(player2);
    }

    public void PlayerWinPoint(IPlayer player)
    {
        if (playerScore1.Player == player)
        {
            RoundPoint(playerScore1, playerScore2);
        }
        else
        if (playerScore2.Player == player)
        {
            RoundPoint(playerScore2, playerScore1);
        }
        else
        {
            throw new Exception("Call Game.PlayerWinPoint with Unknow player");
        }
    }

    private void RoundPoint(IPlayerScore pointWinner, IPlayerScore pointLoser)
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

    public bool GameEnd => Winner != null;

    public IPlayer Winner
    {
        get
        {
            if (playerScore1.IsWinner)
            {
                playerScore1.Player.TotalWonGamesScore++;
                playerScore2.Player.TotalLoseGamesScore++;
                return playerScore1.Player;
            }

            if (playerScore2.IsWinner)
            {
                playerScore2.Player.TotalWonGamesScore++;
                playerScore1.Player.TotalLoseGamesScore++;
                return playerScore2.Player;
            }

            return null;
        }
    }

    public IPlayer Loser
    {
        get
        {
            if (playerScore1.IsWinner)
            {
                return playerScore2.Player;
            }

            if (playerScore2.IsWinner)
            {
                return playerScore2.Player;
            }

            return null;
        }
    }
}