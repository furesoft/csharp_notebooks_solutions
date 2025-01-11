class Program
{
    public static void Main()
    {
        string path = @"D:\test\logger.txt";
        if (!File.Exists(path)) //If file doesn't exist
        {
            Console.WriteLine("Enter a message...");
            var input = Convert.ToString(Console.ReadLine());
            var date = System.DateTime.Now;
            string message = $"[{date}] {input}.";
            File.WriteAllText(path, message);
        }
        else
        {
            Console.WriteLine("Enter a message...");
            var input = Convert.ToString(Console.ReadLine());
            var date = System.DateTime.Now;
            string message = $"\n[{date}] {input}.";
            File.AppendAllText(path, message);
        }
    }
}
