
namespace TennisCalculator;
public class ProcessQuery
{
    private readonly string query;
    private readonly TennisResult tennisResult;

    public ProcessQuery(string query, TennisResult tennisResult)
    {
        this.query = query;
        this.tennisResult = tennisResult;
    }

    public void Process()
    {
        string[] queryStrings = query.Split(' ');
        if (query.StartsWith("Score Match"))
        {
            var matchId = Int32.Parse(queryStrings[2]);
            var targetMatch = tennisResult.Matches.FirstOrDefault(x => x.MatchId == matchId);
            targetMatch.QueryMatchResults();
            Console.WriteLine();
        }
        else if (query.StartsWith("Games Player"))
        {
            var playerName = query.Substring("Game Player".Length + 1).Trim(); ;
            var targetPlayers = tennisResult.Players.Where(item => item.Name == playerName).ToList();
            var totalWonGames = targetPlayers.Sum(player => player.TotalWonGamesScore);
            var totalLostGames = targetPlayers.Sum(player => player.TotalLoseGamesScore);
            Console.WriteLine($"{totalWonGames} {totalLostGames}");
            Console.WriteLine();
        }
    }
}
