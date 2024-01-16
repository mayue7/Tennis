
namespace TennisCalculator;

public class Program
{
    public static void Main()
    {
        TxtFileReader fileReader = new TxtFileReader(@"full_tournament.txt");
        var tennisResult = fileReader.ReadTxtFile();
        while (true)
        {
            Console.WriteLine("Please type query in 'Score Match <id>' or 'Games Player <Player Name>' format");
            Console.WriteLine("You can type 'exit' to quit typing");
            Console.Write("Query: ");
            string query = Console.ReadLine();

            if (query == "exit")
                break;

            ProcessQuery queryProcessor = new ProcessQuery(query, tennisResult);
            queryProcessor.Process();
        }
    }
}
