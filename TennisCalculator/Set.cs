using TennisCalculator.Interfaces;

namespace TennisCalculator;

public class Set
{
    public int MatchId { get; set; }
    private IGame currentGame;
    private IPlayerSetScore player1SetScore;
    private IPlayerSetScore player2SetScore;

    public Set(int matchId, IPlayer player1, IPlayer player2)
    {
        // this.MatchId = matchId;
        player1SetScore = new PlayerSetScore(player1);
        player2SetScore = new PlayerSetScore(player2);
        StartNewGame();
    }

    public void PlayerWinPoint(IPlayer player)
    {
        if (SETEnd)
        {
            return;
        }

        if (player1SetScore.Player == player)
        {
            RoundPoint(player1SetScore, player2SetScore);
        }
        else if (player2SetScore.Player == player)
        {
            RoundPoint(player2SetScore, player1SetScore);
        }
        else
        {
            throw new Exception("Call Set.PlayerWinPoint with Unknow player");
        }
    }

    private void RoundPoint(IPlayerSetScore roundWinner, IPlayerSetScore roundLoser)
    {
        currentGame.PlayerWinPoint(roundWinner.Player);

        if (currentGame.GameEnd)
        {
            CurrentGameAndSetFinished(roundWinner, roundLoser);
        }
    }

    private void CurrentGameAndSetFinished(IPlayerSetScore gameWinner, IPlayerSetScore gameLoser)
    {
        gameWinner.WonGamesScore++;

        if (gameWinner.WonGamesScore == 6 && gameLoser.WonGamesScore <= 5)
        {
            SETWinner = gameWinner.Player;
        }
        StartNewGame();
    }

    private void StartNewGame()
    {
        currentGame = new Game(player1SetScore.Player, player2SetScore.Player);
    }

    public IPlayer SETWinner { get; private set; }

    public bool SETEnd => SETWinner != null;
}