using TennisCalculator.Interfaces;
using TennisCalculator.Scores;

namespace TennisCalculator;

public class Match
{
    public int MatchId { get; set; }
    private Set currentSet;
    private IPlayerMatchScore player1MatchScore;
    private IPlayerMatchScore player2MatchScore;
    public IPlayer MatchWinner { get; private set; }
    public IPlayer MatchLoser { get; private set; }
    public bool MatchEnd => MatchWinner != null;

    public Match(int matchId, IPlayer player1, IPlayer player2)
    {
        this.MatchId = matchId;
        player1MatchScore = new PlayerMatchScore(player1);
        player2MatchScore = new PlayerMatchScore(player2);
        MatchWinner = null;
        StartNewSet();
    }

    public void PlayerWinPoint(IPlayer player)
    {
        if (MatchEnd)
        {
            return;
        }

        if (player1MatchScore.Player == player)
        {
            RoundPoint(player1MatchScore, player2MatchScore);
        }
        else if (player2MatchScore.Player == player)
        {
            RoundPoint(player2MatchScore, player1MatchScore);
        }
        else
        {
            throw new Exception("Call Match.PlayerWinPoint with Unknow player");
        }
    }

    private void RoundPoint(IPlayerMatchScore roundWinner, IPlayerMatchScore roundLoser)
    {
        currentSet.PlayerWinPoint(roundWinner.Player);

        if (currentSet.SETEnd)
        {
            CurrentMatchFinished(roundWinner, roundLoser);
        }
    }
    private void CurrentMatchFinished(IPlayerMatchScore setWinner, IPlayerMatchScore setLoser)
    {
        setWinner.WonSetsScore++;

        if (setWinner.WonSetsScore >= 2 && setLoser.WonSetsScore <= 1)
        {
            MatchWinner = setWinner.Player;
            MatchLoser = setLoser.Player;
        }
        else
        {
            StartNewSet();
        }
    }

    public void QueryMatchResults()
    {
        Console.WriteLine($"{MatchWinner.Name} defeated {MatchLoser.Name}");

        if (player1MatchScore.Player == MatchWinner)
        {
            Console.WriteLine($"{player1MatchScore.WonSetsScore} sets to {player2MatchScore.WonSetsScore}");
            return;
        }

        if (player2MatchScore.Player == MatchWinner)
        {
            Console.WriteLine($"{player2MatchScore.WonSetsScore} sets to {player1MatchScore.WonSetsScore}");
            return;
        }
    }

    private void StartNewSet()
    {
        currentSet = new Set(MatchId, player1MatchScore.Player, player2MatchScore.Player);
    }
}