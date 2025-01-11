using System.Text;

class Program
{
    static string path = @"D:\test\leaderboard.txt";
    static void Main()
    {
        GetScores();
        Console.WriteLine("Enter your name: ");
        var name = Convert.ToString(Console.ReadLine());
        Console.WriteLine("Enter your score: ");
        var score = Convert.ToInt32(Console.ReadLine());
        if (!File.Exists(path)){
            
            var line = $"{name} - {score}";
            File.WriteAllText(path, line);
        }
        else
        {
            var line = $"\n{name} - {score}";
            File.AppendAllText(path, line);
        }
    }
    static void GetScores()
    {
        string[] lines = File.ReadAllLines(path);
        List<(string fullLine, int score)> scoreList = new List<(string fullLine, int score)>();
        int place = 1;

        foreach (string line in lines)
        {
            string[] parts = line.Split("-"); //Split the line at the "-" to extract the score
            if (parts.Length >= 2 && int.TryParse(parts[1].Trim(), out int score)) //Ensure correct formatting
            {
                scoreList.Add((line, score)); //Add the full line and score as a tuple to the list
            }
        }
        scoreList = scoreList.OrderByDescending(item => item.score).ToList();
        Console.WriteLine("Leaderboard:");
        
        foreach (var entry in scoreList) //Display the full score line "place. name - score"
        {
            Console.WriteLine($"{place}. {entry.fullLine}");
            place++;
        }
    }
}