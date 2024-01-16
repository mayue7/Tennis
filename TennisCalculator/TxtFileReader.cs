
using TennisCalculator.Interfaces;

namespace TennisCalculator;

public class TxtFileReader
{
    private readonly string filePath;

    public TxtFileReader(string filePath)
    {
        this.filePath = filePath;
    }
    public TennisResult ReadTxtFile()
    {
        var tennisResult = new TennisResult
        {
            Matches = new List<Match>(),
            Players = new List<IPlayer>()
        };

        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                var line = "";
                IPlayer player1 = null;
                IPlayer player2 = null;
                Match match = null;
                int matchId = 0;
                while (sr.Peek() >= 0)
                {
                    line = sr.ReadLine();
                    if (line.StartsWith("Match"))
                    {
                        matchId = Int32.Parse(line.Substring("Match:".Length).Trim());

                        // Read the next line to get players
                        line = sr.ReadLine();
                        string[] players = line.Split(new[] { "vs" }, StringSplitOptions.RemoveEmptyEntries);
                        player1 = new Player(players[0].Trim());
                        player2 = new Player(players[1].Trim());


                        match = new Match(matchId, player1, player2);
                    }
                    else if (match != null && line != null && int.TryParse(line, out int score))
                    {
                        if (score == 0)
                        {
                            match.PlayerWinPoint(player1);

                        }
                        else if (score == 1)
                        {
                            match.PlayerWinPoint(player2);
                        }
                    }
                    if (match.MatchWinner != null)
                    {
                        tennisResult.Matches.Add(match);
                        tennisResult.Players.Add(player1);
                        tennisResult.Players.Add(player2);
                    };
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        return tennisResult;
    }

}
