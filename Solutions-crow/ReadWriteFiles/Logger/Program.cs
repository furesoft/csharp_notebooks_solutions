class Program
{
    public static void Main()
    {
        string path = @"D:\test\logger.txt";
        Console.WriteLine("Enter a message...");
        var input = Convert.ToString(Console.ReadLine());
        var date = System.DateTime.Now;
        if (!File.Exists(path)) //If file doesn't exist
        {
            string message = $"[{date}] {input}.";
            File.WriteAllText(path, message);
        }
        else
        {
            string message = $"\n[{date}] {input}.";
            File.AppendAllText(path, message);
        }
    }
}
